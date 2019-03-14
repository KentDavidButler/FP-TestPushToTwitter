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

            
            var twitter = new Twitter
            {
                OAuthConsumerKey = "<TOMMY DO STUFF HERE>",
               OAuthConsumerSecret = "<TOMMY DO STUFF HERE>"
            };

            //const string facebookApiId = "1222201867957460";
            //const string facebookApiSecret = "KQrqMPlY5_9i4QfAruapy6GdDn4";
            int selection = Validator.NumValidation();
            Console.Clear();

            switch (selection)
            {
                case 1:
                    Console.WriteLine("What would you like to write to Twitter?");
                    string temp = Console.ReadLine();

                    if (temp.Length < 280 && temp.Length > 0)
                    {
                        Twitter.Message(temp);
                    }

                    Console.WriteLine("You posted to twitter.");
                    break;
                case 2:
                    IEnumerable<string> tweets = twitter.GetTweets("GCSocialMediaT1", 10).Result;
                    foreach (var t in tweets)
                    {
                        Console.WriteLine(t + "\n");
                    }

                    break;
                case 3:
                    List<string> tweetAnalyticRecent = twitter.GetMostRecentPostData("1103777662433144832").Result;
                    foreach (string items in tweetAnalyticRecent)
                    {
                        Console.WriteLine(items);
                    }
                    break;
                case 4:
                    List<TwitObject> tweetAnalyticTopNum = twitter.GetTopRecentPostData("GCSocialMediaT1", 20).Result;
                    foreach (TwitObject items in tweetAnalyticTopNum)
                    {
                        Console.WriteLine(items.ToString());
                    }

                    break;
                case 5:
                    Console.WriteLine("What Twitter Handle would you like to look at?");
                    string twitHandle = Console.ReadLine();

                    List<TwitObject> tweetAnalyticTopNum2 = twitter.GetSpecificUserPost(twitHandle).Result;
                    foreach (TwitObject items in tweetAnalyticTopNum2)
                    {
                        Console.WriteLine(items.ToString());
                    }

                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
