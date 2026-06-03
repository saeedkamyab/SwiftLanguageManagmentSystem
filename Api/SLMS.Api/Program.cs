
using Microsoft.Extensions.FileProviders;
using SLMS.Api.Exceptions;
using SLMS.Application;
using SLMS.Infrastructure;
using SLMS.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(op =>
{
    op.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title="Language Managment System Api",
        Version="v1",
        Description="The api is for SLMS App"
        

    });
});
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);



var app = builder.Build();

//upload files directory
string uploadsPath = builder.Configuration["FileStorage:UploadFolder"] ?? @"C:\SlmsUploads"; // یا یک مسیر مطلق مثل @"C:\MyProjectUploads"
if(!Directory.Exists(uploadsPath)) Directory.CreateDirectory(uploadsPath);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api V1");
});
app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions{
    FileProvider=new PhysicalFileProvider(uploadsPath),
    RequestPath= "/cdn"
});

app.UseAuthorization();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.MapControllers();

app.Run();
