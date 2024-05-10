using WooliesScraper.Helpers;

namespace WooliesScraper
{
    internal class Program
    {
        public static bool printMode = false;
        static async Task Main(string[] args)
        {
            var apiHandler = new WooliesAPIHelper();
            await apiHandler.InitializeSession();

            Random random = new Random();

            while (true)
            {
                int pID = random.Next(999999);
                await apiHandler.ProcessProduct(pID);
            }
        }
    }
}
