using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using ZLogger;

class Program
{
    static async Task Main(string[] args)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddZLoggerFile("C:\\Users\\Alicavad\\Desktop\\Shabnam\\CodeAcademy\\LoggingExample\\logs\\log.txt")
                .SetMinimumLevel(LogLevel.Information) 
                .AddZLoggerConsole(); 
        });

        ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

        string connectionString = "server=DESKTOP-E55K0K2\\SQLEXPRESS;database=northwind;trusted_connection=true;trustservercertificate=true;"; // Replace with your actual connection string

        try
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            logger.LogInformation("database connection is successful");
        }
        catch (SqlException ex)
        {
            logger.LogError(ex.Message);

        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }
}
