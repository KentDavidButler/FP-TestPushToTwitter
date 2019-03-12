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


        public TwitObject(string text, string likes)
        {
            this.Text = text;
            this.Likes = likes;
        }

        public TwitObject()
        {
            this.Text = "***Something Went Wrong***";
            this.Likes = "-1";
        }

        override public string ToString()
        {
            return ("Twitter Post: " + Text + " Amount of Likes: " + Likes);
        }
    }
}
