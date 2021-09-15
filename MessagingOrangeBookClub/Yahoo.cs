using System.Net.Http;
using System.Threading.Tasks;
using LaYumba.Functional;
using static System.Console;

namespace MessagingOrangeBookClub
{
    public static class Yahoo
    {
        public static Task<decimal> GetRate(string ccyPair)
        {
            WriteLine($"Fetching rate for {ccyPair} ...");
            return from body in new HttpClient().GetStringAsync(QueryFor(ccyPair))
                select decimal.Parse(body.Trim());
        }

        static string QueryFor(string ccyPair)
            => $"http://finance.yahoo.com/d/quotes.csv?f=l1&s={ccyPair}=X";
    }
}