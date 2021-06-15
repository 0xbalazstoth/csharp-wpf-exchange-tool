using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Leaf.xNet;

namespace WpfApp11
{
    class scrapeCodes
    {
        public double ResVal;
        public static int countErrors;

        public scrapeCodes(double resVal)
        {
            this.ResVal = resVal;
        }

        public static List<scrapeCodes> codeDatas = new List<scrapeCodes>();
        public static scrapeCodes scodes;
        public static double convertedValue;
        public static void ScrapingCodes(string countryOne, string countryTwo, double value)
        {
            using (HttpRequest req = new HttpRequest())
            {
                try
                {
                    req.UserAgent = Http.ChromeUserAgent();
                    req.IgnoreInvalidCookie = true;
                    req.IgnoreProtocolErrors = true;
                    req.ConnectTimeout = 5000;
                    req.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

                    var html = req.Get("https://exchangerate.guru/" + countryOne + "/" + countryTwo + "/" + value).ToString();

                    string val = html.Substring(@"""> = <span class=""pretty-sum"">", "</span>").Replace(".", ",");
                    convertedValue += Convert.ToDouble(val);

                    scodes = new scrapeCodes(convertedValue);

                    codeDatas.Add(scodes);
                }
                catch (Exception)
                {
                    countErrors++;
                }
                finally
                {
                    req.Dispose();
                }
            }
        }
    }
}
