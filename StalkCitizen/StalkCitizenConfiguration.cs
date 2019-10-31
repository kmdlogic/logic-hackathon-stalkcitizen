using System;
using Kmd.Logic.Identity.Authorization;

namespace StalkCitizen
{
    public class StalkCitizenConfiguration
    {
        public LogicTokenProviderOptions TokenProvider { get; set; } = new LogicTokenProviderOptions();

        public AuthenticationOptions Authentication { get; set; }
        
        public SmsOptions Sms { get; set; } = new SmsOptions();
        

        public string AllowedHosts { get; set; } = string.Empty;

        public string SerilogAzureEventHubEventSource { get; set; }

        public string SerilogAzureEventHubConnectionString { get; set; }
    }

    public class AuthenticationOptions
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
    }
}
