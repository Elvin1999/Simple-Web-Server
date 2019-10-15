using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Server;

namespace WB
{
    class Program
    {
        static void Main(string[] args)
        {

            var server =new AwesomeWebServer();
            Console.WriteLine("Running . . .");
            server.Run();
        }
    }
}
