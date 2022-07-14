using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.ORM
{
    public static class Conectar
    {
        private static IConfigurationRoot Configuration
        {
            get
            {
                var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");

                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environmentName}.json", true)
                    .AddEnvironmentVariables();

                return config.Build();
            }
        }

        public static string BuscarConexao(string parametroConexao)
        {
            var arquivo = Configuration.GetSection(parametroConexao).Value;

            if (!File.Exists(arquivo))
            {
                throw new Exception($"O arquivo de conexão do parametro {parametroConexao} não foi encontrado.");
            }

            string connCripto = File.ReadAllText(arquivo);

            string conn = Criptografia.Descriptografar(connCripto);

            return conn;
        }
    }
}
