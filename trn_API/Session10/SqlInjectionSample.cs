namespace Session10;

public class SqlInjectionSample
{
    public void Risky()
    {
        var module = "Supply";
        var sql = $"SELECT * FROM Infra.Module WHERE [name] LIKE '%{module}%'";
        
        var hackedModule = "Supply%' SELECT * FROM [AspNetUsers] --%'";
        sql = $"SELECT * FROM Infra.Module WHERE [name] LIKE '%{module}%'";
    }
}
