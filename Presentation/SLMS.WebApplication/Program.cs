using SLMS.WebApplication;
using SLMS.WebApplication.Components;
using SLMS.WebApplication.Services;
using SLMS.WebApplicationComponents.Services.Api.Media;
using SLMS.WebApplicationComponents.Services.Api.Media.Interface;
using SLMS.WebApplicationComponents.Services.Base;
using SLMS.WebApplicationComponents.Services.Base.Interfaces;
using SLMS.WebApplicationComponents.Services.Upload;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddApiClients(builder.Configuration);
builder.Services.AddScoped<SearchStateService>();
builder.Services.AddScoped<FeedStateService>();
builder.Services.AddScoped<IMediaUploadClientService, MediaUploadClientService>();
builder.Services.AddSingleton<IMediaUrlResolver, MediaUrlResolver>();


builder.Services.AddServerSideBlazor().AddHubOptions(options =>
{
    options.MaximumReceiveMessageSize = 512 * 1024 * 1024; // 512MB
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
