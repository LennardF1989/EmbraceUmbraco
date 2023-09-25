using EmbraceUmbraco.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace EmbraceUmbraco.Core.Controller.Api;

public class TestApiController : UmbracoApiController
{
    private readonly ITestService _testService;

    public TestApiController(ITestService testService)
    {
        _testService = testService;
    }
    
    [HttpGet]
    public IActionResult Test()
    {
        return Content(_testService.Test());
    }
}