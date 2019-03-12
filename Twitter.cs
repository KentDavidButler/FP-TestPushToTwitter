using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Twitter
    {
        public string OAuthConsumerSecret { get; set; }
        public string OAuthConsumerKey { get; set; }
        //GET 
        //https://api.twitter.com/1.1/favorites/list.json?count=2&screen_name=episod

        //public async Task<IEnumerable<string>> GetLikes(string userName, string accessToken = null)
        //public async Task<IEnumerable<dynamic>> GetLikes(string userName, string accessToken = null)
        public async Task<List<string>> GetLikes(string userName, string accessToken = null)
        {
            List<string> stringData = new List<string>{ };
            if (accessToken == null)
            {
                accessToken = await GetAccessToken();
            }

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/users/lookup.json?user_id={0}&trim_user=1&exclude_replies=1", userName));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            var serializer = new JavaScriptSerializer();
            dynamic json = serializer.Deserialize<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var enumerableTweets = (json as IEnumerable<dynamic>);
            

            if (enumerableTweets == null)
            {
                return null;
            }
            else
            {
                dynamic firstTweet = enumerableTweets.First();
                stringData.Add(firstTweet["id"].ToString());
                stringData.Add(firstTweet["favourites_count"].ToString());
                stringData.Add(firstTweet["statuses_count"].ToString());
                stringData.Add(firstTweet["status"]["text"].ToString());
            }

            //Console.WriteLine(enumerableTweets.First().form["id"]);
            //stringData.Add(enumerableTweets.First().First().id.ToString());
            //returnData = enumerableTweets.ToList();
            //return enumerableTweets.Select(t => (string)(t["text"].ToString()));

            return stringData;
            //return enumerableTweets;
        }

        public async Task<IEnumerable<string>> GetTweets(string userName, int count, string accessToken = null)
        {
            if (accessToken == null)
            {
                accessToken = await GetAccessToken();
            }

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count={0}&screen_name={1}&trim_user=1&exclude_replies=1", count, userName));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            var serializer = new JavaScriptSerializer();
            dynamic json = serializer.Deserialize<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var enumerableTweets = (json as IEnumerable<dynamic>);

            if (enumerableTweets == null)
            {
                return null;
            }
            return enumerableTweets.Select(t => (string)(t["text"].ToString()));
        }

        public async Task<string> GetAccessToken()
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token ");
            var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
            request.Headers.Add("Authorization", "Basic " + customerInfo);
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            //HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

            string json = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(json);
            return item["access_token"];
        }


    }


}