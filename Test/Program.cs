using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using web_api_queryhelper;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DoStuff();
            Console.ReadKey();
        }

        private static async void DoStuff()
        {
            try
            {
                var returnvalue = await JSONQueryHelper.GetAPIResultAsync<string>("https://lending-dev.shared-interest.com", "/Core/api/dev/base/ReturnTest", 5);

                Console.WriteLine(returnvalue);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
