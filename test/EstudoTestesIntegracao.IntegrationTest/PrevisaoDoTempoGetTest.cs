using Xunit;
using EstudoTestesIntegracao.Api;
using FluentAssertions;
using System.Threading.Tasks;
using System.Net;
using EstudoTestesIntegracao.ApiClient;
using System.Linq;

namespace EstudoTestesIntegracao.IntegrationTest
{
    public class PrevisaoDoTempoGetTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public PrevisaoDoTempoGetTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Resultado_Deve_Ser_Ok()
        {
            // arrange
            var client = _factory.CreateClient();
            // act
            var result = await client.GetAsync("/previsao-tempo");
            // assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Resultado_Deve_Ter_5_Itens()
        {
            // arrange
            var client = _factory.CreateClient();
            var service = Refit.RestService.For<IPrevisaoDoTempoClient>(client);
            // act
            var result = await service.GetPrevisoes();
            // assert
            result.Count().Should().Be(5);
        }

    }
}
