using static APIGateway.Util.Emuns;

namespace APIGateway.Util
{
    public class RestRequestParameters
    {
        /// <summary>
        /// Get or sets the request URL.
        /// </summary>
        /// <value>The request URL.</value>
        public string RequestUrl { get; set; }

        /// <summary>
        /// Get or sets the IsGetRequest.
        /// </summary>
        /// <value>The IsGetRequest.</value>
        public bool IsGetRequest { get; set; }

        /// <summary>
        /// Get or sets the PostData.
        /// </summary>
        /// <value>The PostData.</value>
        public object PostData { get; set; }

        /// <summary>
        /// Get or sets the IsDeleteRequest.
        /// </summary>
        /// <value>The IsDeleteRequest.</value>
        public bool IsDeleteRequest { get; set; }

        /// <summary>
        /// Get or sets the IsPutRequest.
        /// </summary>
        /// <value>The IsPutRequest.</value>
        public bool IsPutRequest { get; set; }

        /// <summary>
        /// Get or sets the TimeOut.
        /// </summary>
        /// <value>The TimeOut.</value>
        public int TimeOut { get; set; }

        /// <summary>
        /// Get or sets the request URL.
        /// </summary>
        /// <value>The request URL.</value>
        public string Token { get; set; }

        /// <summary>
        /// Get or sets the Language identifier.
        /// </summary>
        /// <value>The Language identifier.</value>
        public int LanguageId { get; set; }

        /// <summary>
        /// Get or sets the Content Type.
        /// </summary>
        /// <value>The Content Type.</value>
        public ContentTypeEnum ContentType { get; set; }
    }
}
