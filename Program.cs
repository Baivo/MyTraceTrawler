using System;
using WooliesScraper.Helpers;

namespace WooliesScraper
{
    internal class Program
    {
        public static bool printMode = false;
        static async Task Main(string[] args)
        {
            var apiHelper= new WooliesAPIHelper();
            await apiHelper.InitializeSession();

            Random random = new Random();

            while (true)
            {
                int pID = random.Next(999999);
                await apiHelper.ProcessProduct(pID);
            }
        }
        static async Task IndexAllSavedProductsAsync(WooliesAPIHelper apiHelper)
        {
            int totalProducts = 1000000;
            int batchSize = 1000;

            for (int startIndex = 0; startIndex < totalProducts; startIndex += batchSize)
            {
                var tasks = new List<Task>();

                for (int i = startIndex; i < startIndex + batchSize && i < totalProducts; i++)
                {
                    int index = i;
                    tasks.Add(Task.Run(async () =>
                    {
                        await apiHelper.IndexExistingProductFromIDAsync(index);
                    }));
                }
                Console.Write
                        ($"\rIndexing {startIndex}/{totalProducts}");
                await Task.WhenAll(tasks);

            }
        }
    }
}
