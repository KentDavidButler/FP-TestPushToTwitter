using RestSharp;
using RestSharp.Authenticators;
using Json.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to write to Twitter?");
            string temp = Console.ReadLine();

            if(temp.Length < 280 && temp.Length > 0)
            {
                PostToTwitter.Message(temp);
            }

            Console.WriteLine("You posted to twitter.");

        }
    }
}
