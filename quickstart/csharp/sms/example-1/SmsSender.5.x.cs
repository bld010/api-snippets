using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Quickstart
{
    class SmsSender
    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            const string accountSid = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            const string authToken = "your_auth_token";

            // Initialize the Twilio client
            TwilioClient.Init(accountSid, authToken);

            // make an associative array of people we know, indexed by phone number
            var people = new Dictionary<string, string>() {
                {"+14158675309", "Curious George"},
                {"+14158675310", "Boots"},
                {"+14158675311", "Virgil"}
            };

            // Iterate over all our friends
            foreach (var person in people)
            {
                // Send a new outgoing SMS by POSTing to the Messages resource
                MessageResource.Create(
                    from: new PhoneNumber("555-555-5555"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber(person.Key), // To number, if using Sandbox see note above
                    // Message content
                    body: $"Hey {person.Value} Monkey Party at 6PM. Bring Bananas!");

                Console.WriteLine($"Sent message to {person.Value}");
            }
        }
    }
}