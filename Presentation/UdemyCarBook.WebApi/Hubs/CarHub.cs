using Microsoft.AspNetCore.SignalR;
using System.Net.Http;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.WebUI.Hubs
{
    public class CarHub:Hub
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public CarHub(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        private readonly IStatisticsRepository statisticsRepository;

        public CarHub(IStatisticsRepository statisticsRepository)
        {
            this.statisticsRepository = statisticsRepository;
        }

        //public async Task SendCarCount()
        //{
        //    var client=_httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:7277/api/Statistics/GetCarCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiverCarCount", value);
        //}

        public async Task SendCarCount()
        {
            var value = statisticsRepository.GetCarCount();
            await Clients.All.SendAsync("ReceiverCarCount", value);
        }
    }
}
