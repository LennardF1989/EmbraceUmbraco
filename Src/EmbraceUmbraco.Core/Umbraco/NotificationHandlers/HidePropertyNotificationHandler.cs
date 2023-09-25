using EmbraceUmbraco.Core.Models.Umbraco;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace EmbraceUmbraco.Core.Umbraco.NotificationHandlers;

public class HidePropertyNotificationHandler : INotificationHandler<SendingContentNotification>
{
    private static readonly HashSet<string> _hideProperties = new()
    {
        "hideTest"
    };
    
    public void Handle(SendingContentNotification notification)
    {
        if (notification.Content.DocumentType?.Alias != Home.ModelTypeAlias)
        {
            return;
        }
        
        notification.Content.Variants = notification.Content.Variants.Select(x =>
        {
            x.Tabs = x.Tabs.Select(y =>
            {
                y.Properties = y.Properties?
                    .Where(z => !_hideProperties.Contains(z.Alias));

                return y;
            });

            x.Tabs = x.Tabs
                .Where(t => t.Properties != null && t.Properties.Any());

            return x;
        });
    }
}