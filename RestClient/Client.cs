using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RestClient
{
    /// <summary>
    /// A basic REST client class.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// An instance of HttpClient class.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the RestClient.Client class.
        /// </summary>
        public Client()
        {
            this.httpClient = new HttpClient();
        }

        /// <summary>
        /// An HttpRequest instance.
        /// </summary>
        public HttpRequest Request { get; set; }

        /// <summary>
        /// Send a GET request.
        /// </summary>
        /// <typeparam name="T">Type of returning object.</typeparam>
        /// <returns>Return an isntance of T.</returns>
        public T Get<T>() where T : new()
        {
            var response = this.httpClient.GetAsync(this.Request.BaseAddress).Result;

            if (this.Request.Accept == "application/json")
            {
                return Serializer.DeserializeJson<T>(response.Content.ReadAsStringAsync().Result);
            }
            else if (this.Request.Accept == "application/xml")
            {
                return Serializer.DeserializeXml<T>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                throw new NotSupportedException($"The accept type {this.Request.Accept} is not supported.");
            }
        }

        /// <summary>
        /// Send a POST request.
        /// </summary>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <returns>Returns an instance of HttpResponseMessage class.</returns>
        public HttpResponseMessage Post(string content)
        {
            return this.httpClient.PostAsync(this.Request.BaseAddress, new StringContent(content)).Result;
        }

        /// <summary>
        /// Send a PUT request.
        /// </summary>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <returns>Returns an instance of HttpResponseMessage class.</returns>
        public HttpResponseMessage Put(string content)
        {
            return this.httpClient.PutAsync(this.Request.BaseAddress, new StringContent(content)).Result;
        }

        /// <summary>
        /// Send a DELETE request.
        /// </summary>
        /// <returns>Returns an instance of HttpResponseMessage class.</returns>
        public HttpResponseMessage Delete()
        {
            return this.httpClient.DeleteAsync(this.Request.BaseAddress).Result;
        }
    }
}
