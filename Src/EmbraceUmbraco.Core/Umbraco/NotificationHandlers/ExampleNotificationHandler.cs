using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace EmbraceUmbraco.Core.Umbraco.NotificationHandlers;

public class ExampleNotificationHandler : 
    INotificationHandler<ContentSavingNotification>,
    INotificationAsyncHandler<ContentSavingNotification>
{
    private readonly ILogger<ExampleNotificationHandler> _logger;

    public ExampleNotificationHandler(
        ILogger<ExampleNotificationHandler> logger
    )
    {
        _logger = logger;
    }
    
    public void Handle(ContentSavingNotification notification)
    {
        foreach (var content in notification.SavedEntities)
        {
            _logger.LogInformation("Saving content {Name}", content.Name);
        }
    }

    public Task HandleAsync(ContentSavingNotification notification, CancellationToken cancellationToken)
    {
        foreach (var content in notification.SavedEntities)
        {
            _logger.LogInformation("Saving content {Name}", content.Name);
        }
        
        return Task.CompletedTask;
    }
}