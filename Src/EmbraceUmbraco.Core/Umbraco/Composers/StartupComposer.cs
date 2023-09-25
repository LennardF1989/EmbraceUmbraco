using EmbraceUmbraco.Core.Services;
using EmbraceUmbraco.Core.Umbraco.Components;
using EmbraceUmbraco.Core.Umbraco.Filters;
using EmbraceUmbraco.Core.Umbraco.NotificationHandlers;
using EmbraceUmbraco.Core.Umbraco.Options;
using EmbraceUmbraco.Core.Umbraco.Overrides;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Extensions;

namespace EmbraceUmbraco.Core.Umbraco.Composers;

public class StartupComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        //Example
        builder.AddNotificationHandler<
            ContentSavingNotification, ExampleNotificationHandler
        >();
        builder.AddNotificationAsyncHandler<
            ContentSavingNotification, ExampleNotificationHandler
        >();
        
        //Hiding properties
        builder.AddNotificationHandler<
            SendingContentNotification, HidePropertyNotificationHandler
        >();
        
        //Adjusting the language dropdown
        builder.AddNotificationHandler<
            SendingContentNotification, AdjustLanguageDropdownNotificationHandler
        >();
        
        //Server Variables
        builder.AddNotificationHandler<
            ServerVariablesParsingNotification,
            ServerVariablesNotificationHandler
        >();
        
        //Translated Properties
        builder.AddNotificationHandler<
            ContentPublishingNotification,
            PublishHomeNotificationHandler
        >();
        
        //Dependency injection
        builder.Services.AddTransient<ITestService, TestService>();
        builder.Services.AddScoped<ITestService, TestService>();
        builder.Services.AddSingleton<ITestService, TestService>();
        
        //Extending Examine
        builder.Components().Append<ExamineComponent>();
        builder.Services.ConfigureOptions<ExamineIndexOptions>();
        
        //Filters and Middleware
        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new TestPipelineFilter());
        });
        
        //Extending an internal service
        var originalUserService = builder.Services
            .First(x => x.ServiceType == typeof(IUserService))
            .ImplementationType!;

        /*builder.Services.AddUnique<IUserService>(provider =>
            new ProxyUserService(
                (IUserService)provider.CreateInstance(originalUserService)
            )
        );*/
        
        builder.Services.AddUnique<IUserService>(provider =>
            new MyUserService(
                (IUserService)provider.CreateInstance(originalUserService)
            )
        );
    }
}