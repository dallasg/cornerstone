namespace CornerstoneCRM.Billing;

public interface IStripeService
{
    Task HandleWebhookAsync(HttpRequest request);
}
