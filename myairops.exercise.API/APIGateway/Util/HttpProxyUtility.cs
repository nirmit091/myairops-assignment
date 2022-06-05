using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static APIGateway.Util.Emuns;

namespace APIGateway.Util
{
    public sealed class HttpProxyUtility
    {
        /// <summary>
        /// Process the HTTP request
        /// </summary>
        /// <typeparam name="T">object to be return</typeparam>
        /// <param name="restRequestParameters">Rest request parameters</param>
        /// <returns>T object</returns>
        public T ProcessRestRequest<T>(RestRequestParameters restRequestParameters)
        {
            using (var httpClient = new HttpClient())
            {
#if DEBUG
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                
#endif

                //set the time out
                if (restRequestParameters.TimeOut > 0)
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(restRequestParameters.TimeOut);
                }

                //process request
                Task<HttpResponseMessage> response;
                if (restRequestParameters.IsGetRequest)
                {
                    using (response = httpClient.GetAsync(restRequestParameters.RequestUrl, HttpCompletionOption.ResponseContentRead))
                    {
                        return ProcessResponse<T>(response);
                    }
                }

                if (restRequestParameters.IsDeleteRequest)
                {
                    using (response = httpClient.DeleteAsync(restRequestParameters.RequestUrl))
                    {
                        return ProcessResponse<T>(response);
                    }
                }

                HttpContent content;
                if (restRequestParameters.ContentType == ContentTypeEnum.FormEncoded)
                {
                    var dict = restRequestParameters.PostData.ToStringDictionary();
                    content = new FormUrlEncodedContent(dict);
                }
                else
                {
                    var jsonData = JsonConvert.SerializeObject(restRequestParameters.PostData);
                    content = string.IsNullOrWhiteSpace(jsonData) ? null : new StringContent(jsonData, Encoding.UTF8, "application/json");
                }

                if (restRequestParameters.IsPutRequest)
                {
                    using (response = httpClient.PutAsync(restRequestParameters.RequestUrl, content))
                    {
                        return ProcessResponse<T>(response);
                    }
                }

                using (response = httpClient.PostAsync(restRequestParameters.RequestUrl, content))
                {
                    return ProcessResponse<T>(response);
                }
            }
        }

        /// <summary>
        /// De-serialize the Jason response.
        /// </summary>
        /// <typeparam name="TResult">T object</typeparam>
        /// <param name="responseMessage">response message</param>
        /// <returns>T Generic object</returns>
        private TResult ProcessResponse<TResult>(Task<HttpResponseMessage> responseMessage)
        {
            var json = responseMessage.Result;

            switch (json.StatusCode)
            {
                case HttpStatusCode.Created:
                case HttpStatusCode.OK:
                    {
                        return JsonConvert.DeserializeObject<TResult>(json.Content.ReadAsStringAsync().Result);

                    }
                default:
                    {
                        throw new Exception(Convert.ToString(json.StatusCode + json.ReasonPhrase));
                    }
            }
        }
    }
}
