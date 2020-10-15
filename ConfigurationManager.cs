namespace WebAPIAssignment
{
    internal class ConfigurationManager<T>
    {
        private object p;
        private OpenIdConnectConfigurationRetriever openIdConnectConfigurationRetriever;
        private HttpDocumentRetriever httpDocumentRetriever;

        public ConfigurationManager(object p, OpenIdConnectConfigurationRetriever openIdConnectConfigurationRetriever, HttpDocumentRetriever httpDocumentRetriever)
        {
            this.p = p;
            this.openIdConnectConfigurationRetriever = openIdConnectConfigurationRetriever;
            this.httpDocumentRetriever = httpDocumentRetriever;
        }
    }
}