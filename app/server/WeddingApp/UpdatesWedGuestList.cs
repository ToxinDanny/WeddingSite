using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using System;
using Azure.Identity;
using Npoi.Mapper;
using WeddingApp.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace WeddingApp
{
    public static class UpdatesWedGuestList
    {
        [FunctionName("UpdatesWedGuestList")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            try
            {
                var wedGuestToAddString = await req.ReadAsStringAsync();
                var wedGuestToAdd = JsonConvert.DeserializeObject<WedGuestListModel>(wedGuestToAddString);
                var accountUri = new Uri("https://stweddingsite.blob.core.windows.net/");
                var service = new BlobServiceClient(accountUri, new DefaultAzureCredential());
                var stream = await service.GetBlobContainerClient("wedguestinfos")
                    .GetBlobClient("23-09-16 Angelica e Daniele.xlsx")
                    .OpenReadAsync(true);
                var mapper = new Mapper(stream);
                var wedGuestInfos = mapper.Take<WedGuestListModel>().Select(row => row.Value);
                wedGuestInfos = wedGuestInfos.Append(wedGuestToAdd);
                mapper.Save(stream, wedGuestInfos, "Lista ospiti", overwrite: false);
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }

            return new OkResult();
        }
    }
}
