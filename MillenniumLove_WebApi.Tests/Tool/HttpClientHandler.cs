﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MillenniumLove.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace MillenniumLove_WebApi.Tests
{
    public class HttpClientTool
    {
        private HttpClient _client = new HttpClient();

        public  HttpResponseMessage Get(string url)
        {
            return GetAsync(url).Result;
        }

        public  HttpResponseMessage Post(string url, HttpContent content)
        {
            return PostAsync(url, content).Result;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }
    }
}
