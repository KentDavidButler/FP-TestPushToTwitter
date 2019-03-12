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
            GetTwitterInfo.Twitter user = new GetTwitterInfo.Twitter();
            var twitter = new Twitter
            {
                OAuthConsumerKey = "put keys here",
                OAuthConsumerSecret = "put keys here"
            };


            bool selection = Validator.OneOrTwo();
           
            if(selection == true)
            {
                Console.WriteLine("What would you like to write to Twitter?");
                string temp = Console.ReadLine();

                if (temp.Length < 280 && temp.Length > 0)
                {
                    PostToTwitter.Message(temp);
                }

                Console.WriteLine("You posted to twitter.");
            }
            else if (selection == false)
            {
                //IEnumerable<dynamic> tweets = twitter.GetLikes("1103777662433144832").Result;
                List<string> tweetAnalytics = twitter.GetLikes("1103777662433144832").Result;
                foreach (string items in tweetAnalytics)
                {
                    Console.WriteLine(items);
                }
                Console.ReadKey();
            }
            //else if(selection == false)
            //{
            //    IEnumerable<string> tweets = twitter.GetTweets("GCSocialMediaT1", 10).Result;
            //    foreach (var t in tweets)
            //    {
            //        Console.WriteLine(t + "\n");
            //    }
            //    Console.ReadKey();
            //}

        }
    }
}
