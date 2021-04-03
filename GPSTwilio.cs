using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Company.Function.Models;
using System.Net;
using System.Net.Http;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Text;

namespace Company.Function
{
    public static class GPSTwilio
    {
        [FunctionName("GPSTwilio")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            try{
                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Coordinates data = JsonConvert.DeserializeObject<Coordinates>(requestBody);

                var coordinates = data.coordinates;
                var mapsapi_key = Environment.GetEnvironmentVariable("GOOGLEMAPS_APIKEY");

                var client = new HttpClient();

                var mapsapi_url=$"https://maps.googleapis.com/maps/api/geocode/json?latlng={coordinates}&key={mapsapi_key}";

                var mapsapi_content=await client.GetStringAsync(mapsapi_url);
                MapsAPIResponse mapsapi_response= JsonConvert.DeserializeObject<MapsAPIResponse>(mapsapi_content);

                var address = mapsapi_response.results[0].formatted_address;

                var twilio_accountsid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNTSID");
                var twilio_authtoken = Environment.GetEnvironmentVariable("TWILIO_AUTHTOKEN");
                
                TwilioClient.Init(twilio_accountsid,twilio_authtoken);

                var message = MessageResource.Create (
                    to: new Twilio.Types.PhoneNumber(Environment.GetEnvironmentVariable("TO_NUMBER")),
                    from: new Twilio.Types.PhoneNumber(Environment.GetEnvironmentVariable("TWILIO_PHONENO")),
                    body: $"Hey there. I am not feeling safe. Please find me here:\nAddress = {address}\nCoordinates = {coordinates}"
                );

                log.LogInformation($"Message SID: {message.Sid}");

                var res = JsonConvert.SerializeObject(message);

                return new HttpResponseMessage(HttpStatusCode.OK) {
                    Content = new StringContent(res, Encoding.UTF8, "application/json")
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent("", Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
