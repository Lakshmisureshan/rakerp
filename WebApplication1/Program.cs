using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Repositories.Implementation;
using WebApplication1.Repositories.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ExcelPackage.License.SetNonCommercialPersonal("lakshmi");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>

{

    options.UseSqlServer(builder.Configuration.GetConnectionString("CodePlusConnectionStrings"));
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddEntityFrameworkStores<ApplicationDBContext>()
       .AddDefaultTokenProviders();



builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("trading").AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})

.AddUserManager<UserManager<ApplicationUser>>()
.AddEntityFrameworkStores<ApplicationDBContext>();



builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDBContext>();





builder.Services.Configure<IdentityOptions>(options => {

    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 4;

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options => {
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});
app.UseAuthorization(); 

app.MapControllers(); 
//var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
//app.Urls.Add("http://0.0.0.0:" + port);

app.UseStaticFiles();
app.Run();
