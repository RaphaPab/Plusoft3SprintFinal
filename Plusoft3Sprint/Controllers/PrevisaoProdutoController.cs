using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

namespace Plusoft3Sprint.Controllers
{
    public class DadosProduto
    {
        [LoadColumn(0)] public string NomeProduto { get; set; }
        [LoadColumn(1)] public string Categoria { get; set; }
        [LoadColumn(2)] public float Preco { get; set; }
        [LoadColumn(3)] public string SexoCliente { get; set; }
        [LoadColumn(4)] public string Tamanho { get; set; }
        [LoadColumn(5)] public string EstacaoAno { get; set; }
        [LoadColumn(6)] public string CorProduto { get; set; }
    }

    public class PrevisaoNomeProduto
    {
        [ColumnName("NomeProdutoPrevisto")]
        public string NomeProdutoPrevisto { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoProdutoController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloProduto.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "dados_treinamento.csv");
        private readonly MLContext mlContext;

        public PrevisaoProdutoController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
                Console.WriteLine($"Diretório criado: {pastaModelo}");
            }

            // Carregar dados de treinamento
            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosProduto>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            // Pipeline de treinamento para previsão do NomeProduto
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(DadosProduto.NomeProduto))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("CategoriaEncoded", nameof(DadosProduto.Categoria)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("SexoClienteEncoded", nameof(DadosProduto.SexoCliente)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("EstacaoAnoEncoded", nameof(DadosProduto.EstacaoAno)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("CorProdutoEncoded", nameof(DadosProduto.CorProduto)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("TamanhoEncoded", nameof(DadosProduto.Tamanho))) // Codifica Tamanho
                .Append(mlContext.Transforms.Concatenate("Features", "CategoriaEncoded", nameof(DadosProduto.Preco), "SexoClienteEncoded",
                    "TamanhoEncoded", "EstacaoAnoEncoded", "CorProdutoEncoded")) // Atualiza Features
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("NomeProdutoPrevisto", "PredictedLabel")); // Converte PredictedLabel para string

            // Treinamento do modelo
            var modelo = pipeline.Fit(dadosTreinamento);

            // Salvar o modelo treinado em um arquivo .zip
            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
            Console.WriteLine($"Modelo treinado e salvo em: {caminhoModelo}");
        }

        [HttpPost("prever")]
        public ActionResult<PrevisaoNomeProduto> PreverProduto([FromBody] DadosProduto dados)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            // Carregar o modelo salvo
            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

            // Criar o engine de previsão
            var enginePrevisao = mlContext.Model.CreatePredictionEngine<DadosProduto, PrevisaoNomeProduto>(modelo);

            // Realizar a previsão
            var previsao = enginePrevisao.Predict(dados);

            // Verificar se há uma previsão e retornar o nome do produto previsto
            if (previsao == null || string.IsNullOrEmpty(previsao.NomeProdutoPrevisto))
            {
                return Ok(new PrevisaoNomeProduto { NomeProdutoPrevisto = "Produto não encontrado" });
            }

            return Ok(previsao);
        }
    }
}
