using System;
using System.Configuration;
using System.Collections.Specialized;

namespace MagicEight
{
    class Program
    {
        static void Main(string[] args)
        {
            string id = ConfigurationManager.AppSettings.Get("id");
            string secret = ConfigurationManager.AppSettings.Get("secret");
            string token = ConfigurationManager.AppSettings.Get("token");

            MagicEight magic = new MagicEight(id, secret, token);
            magic.Run();

        }
    }
}
