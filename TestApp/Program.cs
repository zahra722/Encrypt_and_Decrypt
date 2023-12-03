

using ChustaSoft.Tools.SecureConfig;
using TestApp.Configuration;


var testApikey = "TestPrivateKey-UseItInASecureWay.20200630";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var settings = builder.SetUpSecureConfig<AppSettings>(testApikey);

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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.EncryptSettings<AppSettings>(false);

app.Run();
