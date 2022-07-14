using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Json
{
    public class JsonHelper<T>
    {
        public string Url { get; private set; }

        public JsonHelper(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Efetua execução dos métodos REST (API)
        /// </summary>
        /// <returns>Retorna o resultado da execução</returns>
        public RetornoJson<T> LerJson()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsync(Url, null).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                string strJson = response.Content.ReadAsStringAsync().Result;

                RetornoJson<T> retorno = JsonConvert.DeserializeObject<RetornoJson<T>>(strJson);

                return retorno;
            }
        }

        /// <summary>
        /// Efetua execução dos métodos REST (API)
        /// </summary>
        /// <param name="parametro">Informações que serão passadas como parametro</param>
        /// <returns>Retorna o resultado da execução</returns>
        public RetornoJson<T> LerJson(object parametro)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonContent = JsonConvert.SerializeObject(parametro);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync(Url, contentString).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                string strJson = response.Content.ReadAsStringAsync().Result;

                RetornoJson<T> retorno = JsonConvert.DeserializeObject<RetornoJson<T>>(strJson);

                return retorno;
            }
        }

        /// <summary>
        /// Efetua execução dos métodos REST (API)
        /// </summary>
        /// <param name="parametro">Informações que serão passadas como parametro</param>
        /// <param name="headers">Envia headers para requisição</param>
        /// <returns>Retorna o resultado da execução</returns>
        public RetornoJson<T> LerJson(object parametro, IDictionary<string, string> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var item in headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                var jsonContent = JsonConvert.SerializeObject(parametro);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync(Url, contentString).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                string strJson = response.Content.ReadAsStringAsync().Result;

                RetornoJson<T> retorno = JsonConvert.DeserializeObject<RetornoJson<T>>(strJson);

                return retorno;
            }
        }

        public T RetornarResultadoJson()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsync(Url, null).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                string strJson = response.Content.ReadAsStringAsync().Result;

                T retorno = JsonConvert.DeserializeObject<T>(strJson);

                return retorno;
            }
        }

        public T RetornarResultadoJson(object parametro)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonContent = JsonConvert.SerializeObject(parametro);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync(Url, contentString).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                string strJson = response.Content.ReadAsStringAsync().Result;

                T retorno = JsonConvert.DeserializeObject<T>(strJson);

                return retorno;
            }
        }

        public T RetornarResultadoJson(object parametro, IDictionary<string, string> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var item in headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                var jsonContent = JsonConvert.SerializeObject(parametro);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync(Url, contentString).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                string strJson = response.Content.ReadAsStringAsync().Result;

                T retorno = JsonConvert.DeserializeObject<T>(strJson);

                return retorno;
            }
        }
    }

}
