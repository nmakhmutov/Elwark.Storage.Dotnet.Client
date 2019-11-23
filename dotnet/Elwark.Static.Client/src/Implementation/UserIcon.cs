using System.IO;
using System.Net.Http;
using Elwark.Static.Client.Abstraction;

namespace Elwark.Static.Client.Implementation
{
    internal class UserIcon : IUserIcon
    {
        private const string Section = "user";
        private readonly Image _default;

        public UserIcon(HttpClient client, string path)
        {
            _default = new Image(client, Path.Combine(path, Section, "default.png"));
        }

        public IImage Default => _default;
    }
}