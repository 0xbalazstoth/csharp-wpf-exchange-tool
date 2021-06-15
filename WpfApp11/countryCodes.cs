using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp11
{
    class countryCodes
    {
        public string CountryCode;

        public countryCodes(string countryCode)
        {
            this.CountryCode = countryCode;
        }

        public static List<countryCodes> datas = new List<countryCodes>();
        public static countryCodes codes;

        public static void Codes()
        {
            StreamReader readFile = new StreamReader("countryCodes.txt");
            while (!readFile.EndOfStream)
            {
                string[] split = readFile.ReadLine().Split(':');
                string countryCode = split[0];

                codes = new countryCodes(countryCode);

                datas.Add(codes);
            }
        }
    }
}
