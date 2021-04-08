namespace IdentityServer.Web.Configurations
{
    public class BaseUrlConfiguration
    {
        public const string CONFIG_NAME = "baseUrls";

        public string ApiBase { get; set; }
        public string IdentityServerBase { get; set; }
    }
}
