using DomainModel.RestClients.Queries;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RestClients
{
    public class NetClient : INetClient
    {
        protected RestClient client;
        ContentType contentType = ContentType.JSON;
        public NetClient()
        {
            client = new RestClient();
        }
        public NetClient(string token, string url)
        {
            client = new RestClient(url);
        }
        public IWebProxy Proxy
        {
            get { return client.Proxy; }
            set { client.Proxy = value; }
        }

        static NetClient()
        {
            // use SSL v3
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

        }

        protected async Task<T> Execute<T>(RestRequest request, RequestModel query = null) where T : new()
        {
            request.AddHeader("Content-Type", contentType.Name);
            //request.AddHeader("Accept", contentType.Name);
            request.RequestFormat = contentType.Format;
            if (query != null)
                request.AddJsonBody(query);
            var response = await client.ExecuteAsync<T>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return response.Data;
        }
    }
}
