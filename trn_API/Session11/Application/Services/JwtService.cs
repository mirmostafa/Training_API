using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace Session11.Application.Services;

public class JwtService
{
    private const string SecretKey = "ThisIsASecretKeyWith32Chars!!Lorem ipsum dolor sit amet, consetetur sadipscing elitr";
    private const string Issuer = "SRM 2.0"; // ✅ مقدار Issuer تنظیم شد
    private const string Audience = "MyUsers"; // ✅ مقدار Audience تنظیم شد

    public string GenerateJwtToken(string username)
    {
        // ایجاد کلید امنیتی
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        // ایجاد اطلاعات امضای توکن
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // تنظیم اطلاعات توکن (Claims)
        var claims = new[]
        {
            new Claim(ClaimTypes.Role, "User") // ✅ نقش کاربر
        };

        // ساخت توکن
        var token = new JwtSecurityToken(
            issuer: Issuer, // ✅ مقدار Issuer اضافه شد
            audience: Audience, // ✅ مقدار Audience اضافه شد
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials);

        // بازگرداندن توکن به‌صورت رشته
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}