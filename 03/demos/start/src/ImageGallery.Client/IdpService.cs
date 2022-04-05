using System.Net.Http;

namespace ImageGallery.Client
{
    public class IdpService: HttpClient
    {
        private HttpClient httpClient;

        public IdpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
