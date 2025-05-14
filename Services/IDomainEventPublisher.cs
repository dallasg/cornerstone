namespace CornerstoneCRM.Services;

public interface IDomainEventPublisher
{
    Task Publish<TEvent>(TEvent domainEvent) where TEvent : class;
}
