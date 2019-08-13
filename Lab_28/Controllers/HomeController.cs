using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_28.Models;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;


namespace Lab_28.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("http://deckofcardsapi.com/");

            var response = await client.GetAsync("/api/deck/new/shuffle/?deck_count=1");
            var content = await response.Content.ReadAsAsync<CardDeck>();

            return View(content);
        }

        public async Task<IActionResult> About()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("http://deckofcardsapi.com/");

            //CardDeck cardDeck = new CardDeck();

            //var url = cardDeck.deck_Id;

            var nextResponse = await client.GetAsync("/api/deck/new/draw/?count=5");

            var nextContent = await nextResponse.Content.ReadAsAsync<CardList>();

            return View(nextContent);

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
