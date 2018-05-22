using System;
using System.IO;
using CoreConsole.Config;
using Microsoft.Extensions.Configuration;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Agent a = new Agent();
            a.Customer = null;
            Console.WriteLine("NUMBER ===> {0}", a?.Customer);
            ConfigurationAccess access = new ConfigurationAccess();

            Console.WriteLine($"ConnectionString = {access.BuilderJson["ConnectionStrings:DefaultConnection"]}");
            Console.WriteLine($"ConnectionString2 = {access.BuilderJson.GetConnectionString("DefaultConnection")}");
            Console.WriteLine($"WizardsArray = {access.BuilderJson["Wizards:1:Name"]}");

            Console.WriteLine($"LDAPServer = {access.BuilderXml["ldap:LDAPServer:value"]}");
            Console.WriteLine($"LDAPUsername = {access.BuilderXml["ldap:LDAPUsername:value"]}");

            string userSecretsId = access.BuilderUserSecrets["UserSecretsId"];
            string mySecret = access.BuilderUserSecrets["MySecret"];
            string newSecret = access.BuilderUserSecrets["new-secret"];

            Console.WriteLine($"User Secrets Id = {userSecretsId}");
            Console.WriteLine($"My Secret = {mySecret}");
            Console.WriteLine($"New Secret = {newSecret}");

        }
    }

     public class Agent
    {
        public int? Customer { get; set; }
    }
}
