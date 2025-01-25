using atFrameWork2.BaseFramework.LogTools;
using ATframework3demo.BaseFramework;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics;

if(args != default)
    EnvironmentSettings.AppArgs = args.ToList();
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredModal();
var currentProcFilePath = new FileInfo(Process.GetCurrentProcess().MainModule.FileName);
builder.Environment.WebRootPath = Path.Combine(currentProcFilePath.DirectoryName, "wwwroot");
builder.Environment.ContentRootPath = currentProcFilePath.DirectoryName;
Environment.CurrentDirectory = currentProcFilePath.DirectoryName;
Log.WriteHtmlHeader(Log.commonLogPath);
Log.Info(">>>>New session started<<<<");
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
