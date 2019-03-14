using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TwitObject
    {
        public string Text { get; set; }
        public string Likes { get; set; }
        public string Retweets { get; set; }
        public List<string> HashTags { get; set; }
        public string URL { get; set; }


        public TwitObject(string text, string likes)
        {
            this.Text = text;
            this.Likes = likes;
            this.Retweets = "0";
            this.HashTags = new List<string>() { };
            this.URL = "Empty";
        }

        public TwitObject(string text, string likes, string retweets, string url)
        {
            this.Text = text;
            this.Likes = likes;
            this.Retweets = retweets;
            this.HashTags = new List<string>() { };
            this.URL = url;
        }

        public TwitObject(string text, string likes, string retweets)
        {
            this.Text = text;
            this.Likes = likes;
            this.Retweets = retweets;
            this.HashTags = new List<string>() { };
            this.URL = "Empty";
        }

        public TwitObject(string text, string likes, string retweets,List<string> hastags, string url)
        {
            this.Text = text;
            this.Likes = likes;
            this.Retweets = retweets;
            this.HashTags = hastags;
            this.URL = url;
        }

        public TwitObject(string text, string likes, string retweets, List<string> hastags)
        {
            this.Text = text;
            this.Likes = likes;
            this.Retweets = retweets;
            this.HashTags = hastags;
            this.URL = "Empty";
        }

        public TwitObject()
        {
            this.Text = "***Something Went Wrong***";
            this.Likes = "-1";
        }

        override public string ToString()
        {
            return ("Twitter Post: " + Text + System.Environment.NewLine +
                "Amount of Likes: " + Likes + System.Environment.NewLine +
                "What Hashtags used: " + HashTags.ToString() + System.Environment.NewLine +
                "TThe URL of post: " + URL);
        }
    }
}
