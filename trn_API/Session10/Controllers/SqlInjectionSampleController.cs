using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Session10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SqlInjectionSampleController : ControllerBase
{
    [HttpGet("risky/{module}")]
    public IActionResult Risky(string module)
    {
        // کوئری آسیب‌پذیر که ورودی کاربر مستقیماً در آن قرار داده شده است
        var sql = $"SELECT * FROM Infra.Module WHERE [name] LIKE '%{module}%'";

        using var connection = new SqlConnection("Data Source=.;Initial Catalog=MesInfra;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        using var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        var result = new List<object>();

        while (reader.Read())
        {
            // خواندن و ذخیره نتیجه
            result.Add(new
            {
                Id = reader[0],
                Name = reader[1],
                Description = reader[2]
            });
        }
        reader.NextResult();
        while (reader.Read())
        {
            // خواندن و ذخیره نتیجه
            result.Add(new
            {
                Id = reader[0],
                Name = reader[1],
                Description = reader[2]
            });
        }

        return Ok(result); // بازگرداندن نتیجه به کاربر
    }

    [HttpGet("safe/{module}")]
    public IActionResult Safe(string module)
    {
        // کوئری امن با استفاده از پارامترهای امن
        var sql = "SELECT * FROM Infra.Module WHERE [name] LIKE @module";

        using var connection = new SqlConnection("Data Source=.;Initial Catalog=MesInfra;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        using var command = new SqlCommand(sql, connection);

        // استفاده از پارامتر برای جلوگیری از SQL Injection
        command.Parameters.AddWithValue("@module", $"%{module}%");

        connection.Open();

        using var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        var result = new List<object>();

        while (reader.Read())
        {
            // خواندن و ذخیره نتیجه
            result.Add(new
            {
                Id = reader[0],
                Name = reader[1],
                Description = reader[2]
            });
        }

        return Ok(result); // بازگرداندن نتیجه به کاربر
    }
}
