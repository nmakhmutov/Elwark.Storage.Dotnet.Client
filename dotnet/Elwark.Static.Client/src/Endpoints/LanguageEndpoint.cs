using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Elwark.Static.Client.Abstraction;
using Elwark.Static.Client.Model;

namespace Elwark.Static.Client.Endpoints
{
    internal class LanguageEndpoint : ILanguageEndpoint
    {
        private const string Section = "language";
        private readonly HttpClient _client;

        public LanguageEndpoint(HttpClient client)
        {
            _client = client;
        }

        public async Task<IReadOnlyCollection<Language>> GetPrimariesAsync(CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(Section, cancellationToken);

            return await response.Convert<Language[]>();
        }

        public async Task<IReadOnlyCollection<Language>> GetFullAsync(CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync($"{Section}/full", cancellationToken);

            return await response.Convert<Language[]>();
        }

        public async Task<Language> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync($"{Section}/code/{code}", cancellationToken);

            return await response.Convert<Language>();
        }
    }
}