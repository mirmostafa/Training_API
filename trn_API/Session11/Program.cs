using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Session11.Application.Services;

namespace Session11;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ✅ اضافه کردن Authentication و JWT Bearer
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "SRM 2.0",
                    ValidAudience = "MyUsers",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyWith32Chars!!Lorem ipsum dolor sit amet, consetetur sadipscing elitr"))
                };
            });

        builder.Services.AddAuthorization(); // ✅ اضافه کردن Authorization

        builder.Services.AddControllers();

        builder.Services.AddTransient<JwtService>();

        var app = builder.Build();

        // ✅ ترتیب اجرای Middlewareها مهم است!
        app.UseAuthentication(); // 🚀 این خط اضافه شده است
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
