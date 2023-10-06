#region

using BlazorWasm.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NATS.Client.Hosting;

#endregion

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddNats(configureOpts: opt => opt with { Url = "ws://localhost:4280", Name = "BlazorClient" });

await builder.Build().RunAsync();
