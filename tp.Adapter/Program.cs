using System;

namespace tp.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new XMLConfigurationAdapter(new XMLConfigurationExternalService());
            var value = configuration.GetValue("host-name");

            Console.WriteLine(value);
        }
    }

    interface IConfiguration
    {
        string GetValue(string name);
    }

    class XMLConfigurationAdapter : IConfiguration
    {
        private readonly IXMLConfiguration xmlConfiguration;
        public XMLConfigurationAdapter(IXMLConfiguration xmlConfiguration)
        {
            this.xmlConfiguration = xmlConfiguration;
        }
        public string GetValue(string name) => this.xmlConfiguration.GetAttributeValue(name);
    }

    interface IXMLConfiguration
    {
        string GetAttributeValue(string name);
    }

    class XMLConfigurationExternalService : IXMLConfiguration
    {
        public string GetAttributeValue(string name) => "fake-host";
    }
}
