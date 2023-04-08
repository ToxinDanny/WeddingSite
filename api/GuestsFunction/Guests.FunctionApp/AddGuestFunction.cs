using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Guests.FunctionApp;

public static class AddGuestFunction
{
    [FunctionName("Guest")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        [Table("Guests", Connection = "StWeddingSiteConnectionString")] IAsyncCollector<Guest> guestCollector,
        ILogger log)
    {
        try
        {
            var guest = await JsonSerializer.DeserializeAsync<Guest>(req.Body, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            await guestCollector.AddAsync(guest);
            return new OkObjectResult(guest);
        }
        catch (Exception e)
        {
            log.LogError(e, e.Message);
            return new BadRequestResult();
        }
    }
}