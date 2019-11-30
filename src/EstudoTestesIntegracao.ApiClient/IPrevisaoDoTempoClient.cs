using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstudoTestesIntegracao.ApiClient.Models;
using Refit;

namespace EstudoTestesIntegracao.ApiClient
{
    public interface IPrevisaoDoTempoClient
    {
        [Get("/previsao-tempo")]
        Task<IEnumerable<WeatherForecast>> GetPrevisoes();
    }
}
