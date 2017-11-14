﻿using System.Net.Http;

namespace CalcDesktopClient.ServerCalculator
{
    public class ServerCalc : IServerCalc
    {
        public string Url { get; }
        private HttpClient _httpClient;

        public ServerCalc() : this("http://localhost:8370/") { }
        public ServerCalc(string url)
        {
            this.Url = url;
            _httpClient = new HttpClient();
        }


        public string Calculate(string num1, string num2, string opr)
        {
            return _httpClient.GetStringAsync($"{this.Url}?num1={num1}&num2={num2}&opr={opr}").GetAwaiter().GetResult();
        }
    }
}