namespace CornerstoneCRM.Billing;

public static class StripeWebhookEndpoints
{
    public static void MapStripeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/stripe/webhook", async (IStripeService stripeService, HttpRequest request) =>
        {
            await stripeService.HandleWebhookAsync(request);
            return Results.Ok();
        });
    }
}
