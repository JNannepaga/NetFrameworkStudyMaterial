using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Twilio;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class TwilioSmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            TwilioRestClient twilio = new TwilioRestClient(TwilioKeys.TwilioSid, TwilioKeys.TwilioAuth);
            Twilio.Message sms = twilio.SendMessage("+919676518138", "+919985900250", message.Body);
            string status = sms.Status;

            return Task.FromResult(0);
        }
    }
}