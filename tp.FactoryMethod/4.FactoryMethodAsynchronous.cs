using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tp.FactoryMethod
{
    class LaptopAsynchronous
    {
        public string Processor;
        public int StorageInGB;
        public HPLaptopModel Model;
        public decimal Price;

        private LaptopAsynchronous(string processor, int storageInGB, HPLaptopModel model)
        {
            Processor = processor ?? throw new ArgumentNullException(nameof(processor));
            StorageInGB = storageInGB;
            Model = model;
        }

        public static async Task<LaptopAsynchronous> NewEnvyLaptopAsync(string processor, int storageInTB)
        {
            var result = new LaptopAsynchronous(processor, storageInTB * 1024, HPLaptopModel.envy);
            return await result.InitEnvyPriceAsync();
        }

        private async Task<LaptopAsynchronous> InitEnvyPriceAsync()
        {
            await Task.Delay(3000);
            this.Price = 1000m; // = await priceService.GetEnvyPriceAsync();
            return this;
        }
    }
}
