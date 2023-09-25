using EmbraceUmbraco.Core.Middleware;
using Microsoft.AspNetCore.Builder;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace EmbraceUmbraco.Core.Umbraco.Filters;

public class TestPipelineFilter : UmbracoPipelineFilter
{
    public TestPipelineFilter() 
        : base(nameof(TestPipelineFilter))
    {
        PrePipeline = builder =>
        {
            builder.UseMiddleware<TestMiddleware>();
        };
    }
}