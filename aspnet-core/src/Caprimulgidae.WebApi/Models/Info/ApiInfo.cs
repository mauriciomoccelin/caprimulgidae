using Antilopes.WebApi.Info;

namespace Caprimulgidae.WebApi.Models.Info
{
    public sealed class ApiInfo : IApiInfo
    {
        internal ApiInfo() { }

        public string Version { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactUrl { get; set; }

        public string LicenseType { get; set; }

        public string LicenseUrl { get; set; }

        public string GetDescriptionDropDown() => $"{Title} | {Version}";
    }
}
