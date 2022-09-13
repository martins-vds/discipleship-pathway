using DiscipleshipPathway.Web;
using DiscipleshipPathway.Web.Services.AssessmentService;
using DiscipleshipPathway.Web.Services.StateService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IAssessmentService, AssessmentService>();
builder.Services.AddSingleton<IStateService, InMemoryReadOnceStateService>();

await builder.Build().RunAsync();
