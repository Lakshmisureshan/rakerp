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

// CORS Policy Definition - CORRECT
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendOrigin", // Policy Name
        builder =>
        {
            // Allowed Origins
            builder.WithOrigins("http://localhost:4200", // <-- ADD THIS
                                "http://localhost:8000",
                                  "http://localhost:53925",
                                "http://frontend")
                   .AllowAnyHeader() // Allows all headers
                   .AllowAnyMethod() // Allows all HTTP methods (GET, POST, PUT, DELETE, etc.)
           .AllowCredentials(); // <-- UNCOMMENT THIS IF YOUR ANGULAR APP SENDS AUTHENTICATION HEADERS (e.g., JWT) OR COOKIES
        });
});


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

// app.UseHttpsRedirection(); // Commented out, which is good for Docker HTTP inter-container communication

// Routing Middleware - CORRECT PLACEMENT
app.UseRouting();

// CORS Middleware - CORRECT PLACEMENT (After UseRouting, Before UseAuthorization)
app.UseCors("AllowFrontendOrigin"); // Applying the named policy

// Authorization Middleware - CORRECT PLACEMENT
app.UseAuthorization();

app.MapControllers();

//var port = Environment.GetEnvironmentVariable("PORT") ?? "5000"; // This is commented out, so Kestrel will use default ports (80/443)
//app.Urls.Add("http://0.0.0.0:" + port); // This is commented out

app.UseStaticFiles();
app.Run();