using System.Net.Http;

namespace Atomicy.App.Services
{
    public partial interface IAtomicyManagementAPIClient
    {
        public HttpClient HttpClient { get; }

    }
}
