using ILogger = FenXsData.Infrastructure.Logger.ILogger;
using FenXs.HTTPResponseMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<ILogger, FenXsData.Infrastructure.Logger.LoggerFile>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseHTTPResponseMiddleware();

app.MapRazorPages();

app.Run();
