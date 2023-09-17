using System.Net.Http;

namespace Atomicy.App.Services
{
    public partial class AtomicyManagementAPIClient : IAtomicyManagementAPIClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
