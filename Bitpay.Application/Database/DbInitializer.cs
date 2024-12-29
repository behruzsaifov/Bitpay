using Dapper;

namespace Bitpay.Application.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    public async Task InitializerAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync("""
                                          CREATE TABLE IF NOT EXISTS payments (
                                              "id" UUID PRIMARY KEY,
                                              "accountNumber" INTEGER NOT NULL,
                                              "accountType" TEXT NOT NULL,
                                              "amount" DECIMAL NOT NULL,
                                              "currency" TEXT NOT NULL,
                                              "status" TEXT NOT NULL,
                                              "createdAt" TIMESTAMP NOT NULL,
                                              "updatedAt" TIMESTAMP,
                                              "cancelledAt" TIMESTAMP
                                          );
                                      """);
    }
}