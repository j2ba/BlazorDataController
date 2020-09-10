using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;

namespace BlazorDataController.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzE2MDM5QDMxMzgyZTMyMmUzMFB2OXNDLy90aGpmSjYwNmE4UjMwa3oxTTViNzZLVFR0R056cVpDeWRQNVE9;MzE2MDQwQDMxMzgyZTMyMmUzMGtqdjV2WnlwRXlrV2htK0JsYyttbEl3RFNZRm90dXEyNnNDZzNBSzlIN0E9;MzE2MDQxQDMxMzgyZTMyMmUzMEJ3cFVqVi9YczVZWm1OSVJjd2Z6YmRFR25NZ3JyZVRhZmhTdzdhYVNjZ1k9;MzE2MDQyQDMxMzgyZTMyMmUzMEVoNWdPWjBNSm5ESjFRNnVHUWFNUHhRelJoMEw4UGRxWFo1STRPY2JSM0U9;MzE2MDQzQDMxMzgyZTMyMmUzMFEwWElNQ3VtR3NzeDhBcHZCTktkUStYUTR5djRhU1gvQWwrN3h0bk54UEE9;MzE2MDQ0QDMxMzgyZTMyMmUzMG1pbTFENTQ2NjNKSW0yMHlQZ3FLdkhhRWtkSUdsc0poT3B2OGtQMktuRDg9;MzE2MDQ1QDMxMzgyZTMyMmUzMEJlOUxDSzVLeHhXdzBIZFFNM0FFakxyc0psT2JFVVBtNGN6TmE1OGhxRGs9;MzE2MDQ2QDMxMzgyZTMyMmUzMFlQZE0rZFI5WFdTRXZnSi8zaXNWOXVMSTJuQzVpTUZZc2hVWlpaS1RXaEU9;MzE2MDQ3QDMxMzgyZTMyMmUzMFdSanQ3ZUFFZElpSmhHZlpROHJkT1pVZFFEUklnYXRydzM4Z1crcXdjQ289;NT8mJyc2IWhia31hfWN9Z2doYmF8YGJ8ampqanNiYmlmamlmanMDHmg5OSc8JjE6MmITKjI7PDx9MDw+;MzE2MDQ4QDMxMzgyZTMyMmUzMEVPSnZkSjNWZy9sVk04MndieXJQaUtnbHNBVlpCNnJjU05zRWl5aHoyRTg9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddHttpClient("BlazorDataController.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorDataController.ServerAPI"));

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
