using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace EmbraceUmbraco.Core.Umbraco.NotificationHandlers;

public class ServerVariablesNotificationHandler : 
    INotificationHandler<ServerVariablesParsingNotification>
{
    public void Handle(ServerVariablesParsingNotification notification)
    {
        notification.ServerVariables["mydashboard"] = new Dictionary<string, string>
        {
            { "somekey", "somevalue" }
        };
    }
}