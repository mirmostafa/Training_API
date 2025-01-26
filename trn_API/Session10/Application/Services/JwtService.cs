using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace Session10.Application.Services;

public class JwtService
{
    private const string SecretKey = "ThisIsASecretKeyWith32Chars!!Lorem ipsum dolor sit amet, consetetur sadipscing elitr";

    public string GenerateJwtToken(string username)
    {
        // ایجاد کلید امنیتی
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        // ایجاد اطلاعات امضای توکن
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // تنظیم اطلاعات توکن (Claims)
        var claims = new[]
        {
            new Claim("username", username), // اضافه کردن نام کاربر به توکن
            new Claim("role", "user"), // اضافه کردن نقش کاربر به توکن
            new Claim("expirationDate", DateTime.UtcNow.AddMinutes(30).ToString()) // اضافه کردن تاریخ انقضای توکن
        };

        // ساخت توکن
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        // بازگرداندن توکن به‌صورت رشته
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
