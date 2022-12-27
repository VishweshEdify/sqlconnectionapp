using sqlconnectionapp.DBService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IdbConnectionService, dbConnectionService>();

var connectionString = "Endpoint=https://appconfigvish.azconfig.io;Id=rKz8-l6-s0:XdCLFMDYp+ooEZhOLaj1;Secret=zsv50i1w6IzXcdwkBzSV5zzdOAGIYb77M1QQUOURjFw=";

builder.Host.ConfigureAppConfiguration(x=> x.AddAzureAppConfiguration(connectionString));

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

app.Run();
