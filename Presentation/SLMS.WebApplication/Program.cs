using SLMS.WebApplication;
using SLMS.WebApplication.Components;
using SLMS.WebApplication.Services;
using SLMS.WebApplicationComponents.Services.Base;
using SLMS.WebApplicationComponents.Services.SocialNetwork;
using SLMS.WebApplicationComponents.Services.SocialNetwork.Interface;
using SLMS.WebApplicationComponents.Services.Users;
using SLMS.WebApplicationComponents.Services.Users.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<SearchStateService>();
builder.Services.AddHttpClient<BaseApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7218");
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
