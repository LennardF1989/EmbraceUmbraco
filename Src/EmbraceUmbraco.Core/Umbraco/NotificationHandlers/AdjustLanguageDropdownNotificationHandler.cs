using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace EmbraceUmbraco.Core.Umbraco.NotificationHandlers;

public class AdjustLanguageDropdownNotificationHandler : 
    INotificationHandler<SendingContentNotification>
{
    private readonly IContentTypeService _contentTypeService;
    private readonly IBackOfficeSecurity _backOfficeSecurity;

    private readonly Dictionary<string, string> _userGroupToLanguage = new()
    {
        { "editorDutch", "nl-NL" },
        { "editorEnglish", "en-US" },
        { "editorGerman", "de-DE" }
    };
    
    public AdjustLanguageDropdownNotificationHandler(
        IContentTypeService contentTypeService,
        IBackOfficeSecurity backOfficeSecurity 
    )
    {
        _contentTypeService = contentTypeService;
        _backOfficeSecurity = backOfficeSecurity;
    }
    
    //...
    
    public void Handle(SendingContentNotification notification)
    {
        var contentType = _contentTypeService.Get(notification.Content.ContentTypeKey);
        
        if (
            contentType == null ||
            !contentType.VariesByCulture() || 
            !notification.Content.ParentId.HasValue
        )
        {
            return;
        }

        var userGroups = _backOfficeSecurity.CurrentUser.Groups
            .Select(x => x.Alias)
            .ToHashSet();

        var cultures = _userGroupToLanguage
            .Where(x => userGroups.Contains(x.Key))
            .Select(x => x.Value)
            .ToHashSet();

        notification.Content.Variants =
            notification.Content.Variants
                .Where(x => 
                    x.Language != null && 
                    cultures.Contains(x.Language.IsoCode)
                );
    }
}