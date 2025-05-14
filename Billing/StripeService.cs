namespace CornerstoneCRM.Billing;

public class StripeService : IStripeService
{
    public async Task HandleWebhookAsync(HttpRequest request)
    {
        // Read event payload, validate signature
        // Update Subscription status in DB
        Console.WriteLine("[Stripe] Webhook received");
        await Task.CompletedTask;
    }
}
