/*
 * File name: RESTService.cs
 * Description: REST service for REST clients
 * Name: Gonzalo Ramos Zúñiga
 * Revision History:
 *      2016/10/13: Cleaned up
 *      2016/10/10: Created
 */

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GRRESTClient
{
    /// <summary>
    /// Class to provide http methods for REST clients
    /// </summary>
    class RESTService
    {
        /// <summary>
        /// Field
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseAddress">Base URL requests will be sent to</param>
        public RESTService(string baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }

        /// <summary>
        /// Sends a GET request
        /// </summary>
        /// <param name="URL">URL the request is sent to</param>
        /// <returns>Response from server</returns>
        public string GET(string URL)
        {
            string result = "";
            Task.Run(async () =>
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(URL);
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException err)
                {
                    result = err.Message;
                }
            }
            ).Wait();

            return result;
        }

        /// <summary>
        /// Sends a POST request
        /// </summary>
        /// <param name="URL">URL the request is sent to</param>
        /// <param name="body">Content to send in request</param>
        /// <returns>Response from server</returns>
        public string POST(string URL, string body)
        {
            string result = "";
            Task.Run(async () =>
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync(URL,
                        new StringContent(body));
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException err)
                {
                    result = err.Message;
                }
            }
            ).Wait();

            return result;
        }

        /// <summary>
        /// Sends a PUT request
        /// </summary>
        /// <param name="URL">URL the request is sent to</param>
        /// <param name="body">Content to send in request<</param>
        /// <returns>Response from server</returns>
        public string PUT(string URL, string body)
        {
            string result = "";
            Task.Run(async () =>
            {
                try
                {
                    HttpResponseMessage ourResponse = await client.PutAsync(URL,
                        new StringContent(body));
                    ourResponse.EnsureSuccessStatusCode();
                    result = await ourResponse.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException err)
                {
                    result = err.Message;
                }
            }
            ).Wait();

            return result;
        }

        /// <summary>
        /// Sends a DELETE request
        /// </summary>
        /// <param name="URL">URL the request is sent to</param>
        /// <returns>Response from server</returns>
        public string DELETE(string URL)
        {
            string result = "";
            Task.Run(async () =>
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(URL);
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException err)
                {
                    result = err.Message;
                }
            }
            ).Wait();

            return result;
        }
    }
}