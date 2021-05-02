using AnimeCharacterBirthdayApi.DataParse.ResponseModels;
using AnimeCharacterBirthdayApi.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace AnimeCharacterBirthdayApi.DataParse.Services
{
    public class DataParseService : IDataParseService
    {
        public DataParseService() { }

        public ApiResponse<List<Character>> GetCharacterList() {

            return null;
        }

        public ApiResponse<List<Character>> GetCharacterList(int date, string month)
        {
            var url = $"https://www.animecharactersdatabase.com/birthdays.php?theday={date}&themonth={month}";

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            var a = result;

            return null;
        }

        public string GetCharacterHTML(int date, Months month)
        {
            var url = $"https://www.animecharactersdatabase.com/birthdays.php?theday={date}&themonth={month}";

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            string[] lines = result.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );

            string[] newList = lines[0].Split("\n");
            var nl = newList.ToList();

            foreach (var i in newList)
            {
                //if (!i.Contains("<A href=\"characters.php ? id = ") && !i.Contains("<IMG style=") && !i.Contains("tile1bottom"))
                //{
                //    nl.Remove(i);
                //}

                nl.Where(x => x == i).ToList();


                if (i.Contains("<A href=\"characters.php ? id = "))
                {
                    
                }
                else if (i.Contains("<IMG style="))
                {
                    nl.Remove(i);
                }
                else if (i.Contains("tile1bottom"))
                {
                    nl.Remove(i);
                }
                else
                {
                    nl.Remove(i);
                }
            }

            List<Character> characters = new List<Character>();
            foreach (var i in nl)
            {
                characters.Add(new Character
                {
                    CharacterId = 2,
                    Name = "",
                    ImageUrl = "",
                    LoadUrl = "",
                    Birthday = new DateTime(1900, (int)month, date)
                });
            }

            return result;
        }
    }

    public enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5, 
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
