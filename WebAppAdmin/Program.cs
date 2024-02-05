using WebAppAdmin.Repository;
using WebAppAdmin.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<APIRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
    //name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//test partage