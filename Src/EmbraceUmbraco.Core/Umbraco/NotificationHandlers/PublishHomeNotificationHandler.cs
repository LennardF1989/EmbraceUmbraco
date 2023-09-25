using EmbraceUmbraco.Core.Models.Umbraco;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;

namespace EmbraceUmbraco.Core.Umbraco.NotificationHandlers;

public class PublishHomeNotificationHandler : 
    INotificationHandler<ContentPublishingNotification>
{
    /*private readonly ILocalizationService _localizationService;

    public PublishHomeNotificationHandler(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }*/
    
    public void Handle(ContentPublishingNotification notification)
    {
        foreach (var content in notification.PublishedEntities)
        {
            if (content.ContentType.Alias != Home.ModelTypeAlias)
            {
                continue;
            }

            var value = content.Properties["text"]?.GetValue() as string;
            
            if (!string.IsNullOrWhiteSpace(value))
            {
                continue;
            }
            
            //NOTE: Does not actually work, but you can use the localization service.
            notification.Cancel = true;
            notification.Messages.Add(new EventMessage(
                    "#homeErrorCategory",
                    "#homeErrorMessage",
                    EventMessageType.Error
                )
                {
                    IsDefaultEventMessage = true
                }
            );
        }
    }
}