using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Options;
using Twilio.Clients;


namespace astech_DAO.Service
{
    public class SMessengerService
    {
        private readonly ITwilioRestClient _twilioRestClient;
        private readonly TwilioSettings _twilioSettings;

        public SMessengerService(ITwilioRestClient twilioRestClient, TwilioSettings twilioSettings)
        {
            _twilioRestClient = twilioRestClient;
            _twilioSettings = twilioSettings;
        }

        public async Task SendMessageAsync(string toNumber, string message)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber($"whatsapp:{toNumber}"))
            {
                From = new PhoneNumber($"whatsapp:{_twilioSettings.PhoneNumber}"),
                Body = message
            };

            await MessageResource.CreateAsync(messageOptions, _twilioRestClient);
        }
    }
}
