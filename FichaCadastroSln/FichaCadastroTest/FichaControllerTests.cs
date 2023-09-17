using FichaCadastroApi.DTO.Ficha;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace FichaCadastroTest
{
    public class FichaControllerTests
    {
        private const string URL = "http://localhost:50009";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            var application = new WebApplicationFactory<Program>();
            application.ClientOptions.BaseAddress = new Uri(URL);
            client = application.CreateClient();

        }

        [Test]
        public async Task POST_SUCCESS()
        {

            //Arrange
            FichaCreateDTO body = new()
            {
                NomeCompleto = "NOME EXEMPLO",
                EmailInformado = "email@teste.com.br",
                DataDeNascimento = new DateTime(1984, 9, 9)
            };
            
            var contentString = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            //Act
            var returns = await client.PostAsync("/api/ficha", contentString);

            //Assert
            Assert.True(returns.IsSuccessStatusCode, "Erro ao comunicar com a api");

            var response = await returns.Content.ReadAsStringAsync();
            FichaReadDTO fichaReadDTO = JsonConvert.DeserializeObject<FichaReadDTO>(response);

            Assert.AreNotEqual(0, fichaReadDTO.Id);
        }

        [Test]
        public async Task POST_SUCCESS_ERROR()
        {

            //Arrange
            FichaCreateDTO body = new()
            {
                NomeCompleto = "NOME EXEMPLO",
                EmailInformado = "",
                DataDeNascimento = new DateTime(1984, 9, 9)
            };

            var contentString = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            //Act
            var returns = await client.PostAsync("/api/ficha", contentString);

            //Assert
            Assert.False(returns.IsSuccessStatusCode, "Comunicação feita com sucesso na api");
        }
    }
}