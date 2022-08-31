using Azure;
using Azure.Messaging.EventGrid;
using System;
using System.Threading.Tasks;

public class Program {
    private const string topicEndpoint = "https://hrtopictim.eastus-1.eventgrid.azure.net/api/events";
    private const string topicKey = "SJ0D//GAkSGSXsusCiNlLNVVrJrN7nebMuYpkDZzLU4=";

    public static async Task Main(string[] args) {
        Uri endpoint = new Uri(topicEndpoint);
        AzureKeyCredential credential = new AzureKeyCredential(topicKey);
        EventGridPublisherClient client = new EventGridPublisherClient(endpoint, credential);

        EventGridEvent firstEvent = new EventGridEvent(
            subject: $"Salut c Squeezie",
            eventType: "Employees.Registration.New",
            dataVersion: "1.0",
            data: new {
                FullName = "Squeezie",
                Address = "1 rue de tutube"
            }
        );

        EventGridEvent secondEvent = new EventGridEvent(
            subject: $"Salut c Mista V",
            eventType: "Employees.Registration.New",
            dataVersion: "1.0",
            data: new {
                FullName = "Mista V",
                Address = "2 rue de tutube"
            }
        );

        await client.SendEventAsync(firstEvent);
        Console.WriteLine("First event published");
        await client.SendEventAsync(secondEvent);
        Console.WriteLine("Second event published");

    }
}