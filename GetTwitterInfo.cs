using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace ConsoleApp1
{
    class GetTwitterInfo
    {

        public class Twitter
        {
            public string OAuthConsumerSecret { get; set; }
            public string OAuthConsumerKey { get; set; }

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



        public static void StatusInfo()
        {

            //OAuthTokens tokens = new OAuthTokens();

            //tokens.ConsumerKey = "ZKQO3mOrtZSvgD0YPDnyZ4iOf";
            //tokens.ConsumerSecret = "NNvgVh8sFBEroWqk3gPF775hTQ3mNGtBNQhdrXEX3MIDiub39C";
            //tokens.AccessToken = "1103777662433144832-5KmCUZbNaQW30Oi9lPkniPLc0WyUJs";
            //tokens.AccessTokenSecret = "rzqFLMHq03Xg6Tcv7BObSHYUIoEEIgcU4CHVuqNHtKqKe";

            //TwitterStatusCollection homeTimeline = TwitterStatus.GetHomeTimeline(tokens);


            //******************Try Two
            //var client = new RestClient("https://api.twitter.com/1.1/users/lookup.json?user_id=1103777662433144832");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Postman-Token", "33777c54-f350-474b-8ae0-ce98897d8f84");
            //request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Authorization", "OAuth oauth_consumer_key=\"ZKQO3mOrtZSvgD0YPDnyZ4iOf\",oauth_token=\"1103777662433144832 - 5KmCUZbNaQW30Oi9lPkniPLc0WyUJs\",oauth_signature_method=\"HMAC - SHA1\",oauth_timestamp=\"1552316615\",oauth_nonce=\"TeCz0D50abt\",oauth_version=\"1.0\",oauth_signature=\"9L68Ml % 2FCnJFWlOO94Qr34c % 2BegAM % 3D\"");
            //IRestResponse response = client.Execute(request);


            //*****************Try One
            //var oauth_token = "1103777662433144832-5KmCUZbNaQW30Oi9lPkniPLc0WyUJs";
            //var oauth_token_secret = "rzqFLMHq03Xg6Tcv7BObSHYUIoEEIgcU4CHVuqNHtKqKe";
            //var oauth_consumer_key = "ZKQO3mOrtZSvgD0YPDnyZ4iOf";
            //var oauth_consumer_secret = "NNvgVh8sFBEroWqk3gPF775hTQ3mNGtBNQhdrXEX3MIDiub39C";

            //var oauth_version = "1.0";
            //var oauth_signature_method = "HMAC-SHA1";

            //var oauth_nonce = Convert.ToBase64String(
            //                                  new ASCIIEncoding().GetBytes(
            //                                       DateTime.Now.Ticks.ToString()));
            //var timeSpan = DateTime.UtcNow
            //                                  - new DateTime(1970, 1, 1, 0, 0, 0, 0,
            //                                       DateTimeKind.Utc);
            //var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();
            //var resource_url = "https://api.twitter.com/users/lookup.json?user_id=1103777662433144832";

            //var baseFormat = "oauth_consumer_key={0}&oauth_token={1}&oauth_signature_method={2}" +
            //    "&oauth_timestamp={3}&oauth_nonce={4}&oauth_version={5}";

            //var baseString = string.Format(baseFormat,
            //                            oauth_consumer_key,
            //                            oauth_token,
            //                            oauth_signature_method,
            //                            oauth_timestamp,
            //                            oauth_nonce,
            //                            oauth_version
            //                            );

            //baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url),
            //             "&", Uri.EscapeDataString(baseString));

            //var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
            //            "&", Uri.EscapeDataString(oauth_token_secret));

            //string oauth_signature;
            //using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            //{
            //    oauth_signature = Convert.ToBase64String(
            //        hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            //}

            //var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
            //       "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
            //       "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
            //       "oauth_version=\"{6}\"";

            //var authHeader = string.Format(headerFormat,
            //                        Uri.EscapeDataString(oauth_nonce),
            //                        Uri.EscapeDataString(oauth_signature_method),
            //                        Uri.EscapeDataString(oauth_timestamp),
            //                        Uri.EscapeDataString(oauth_consumer_key),
            //                        Uri.EscapeDataString(oauth_token),
            //                        Uri.EscapeDataString(oauth_signature),
            //                        Uri.EscapeDataString(oauth_version)
            //                );

            ////var postBody = "status=" + Uri.EscapeDataString(status);

            //ServicePointManager.Expect100Continue = false;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            //request.Headers.Add("Authorization", authHeader);
            //request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            ////using (Stream stream = request.GetRequestStream())
            ////{
            ////    byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
            ////    stream.Write(content, 0, content.Length);
            ////}
            //WebResponse response = request.GetResponse();

            //Console.WriteLine(response.ToString());
            //response.Close();
        }
    }
}
