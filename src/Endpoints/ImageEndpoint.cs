using System.Net.Http;
using Elwark.Storage.Client.Abstraction;
using Elwark.Storage.Client.Implementation;
using Elwark.Storage.Client.Model;

namespace Elwark.Storage.Client.Endpoints
{
    internal class ImageEndpoint : IImageEndpoint
    {
        private const string Section = "images";
        private readonly HttpClient _client;

        public ImageEndpoint(HttpClient client) =>
            _client = client;

        public IImage GetRandom(ImageOrientation orientation) =>
            new Image(_client, $"{Section}/random?orientation={orientation.ToString().ToLower()}");

        public IImage GetRandom(ImageResolution resolution, ImageOrientation orientation) =>
            new Image(_client,
                $"{Section}/random/{resolution.ToString().ToLower()}?orientation={orientation.ToString().ToLower()}");

        public IImage GetRandom(uint width, uint height) =>
            new Image(_client, $"{Section}/random/{width}/{height}");
    }
}