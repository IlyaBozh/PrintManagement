using Microsoft.AspNetCore.Mvc;

namespace PrintManagement.Api.Extentions;

public static class ControllerExtention
{
    public static string GetUrl(this ControllerBase controller) =>
       $"{controller.Request?.Scheme}://{controller.Request?.Host.Value}{controller.Request?.Path.Value}";
}
