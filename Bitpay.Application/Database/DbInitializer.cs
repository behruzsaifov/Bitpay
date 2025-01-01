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
                                              "senderAccountNumber" INTEGER NOT NULL,
                                              "senderAccountType" TEXT NOT NULL,
                                              "senderName" TEXT NOT NULL,
                                              "senderSurname" TEXT NOT NULL,
                                              "senderMiddleName" TEXT,
                                              "senderAmount" DECIMAL NOT NULL,
                                              "senderAmountCurrency" TEXT NOT NULL,
                                              "receiverAccountNumber" INTEGER NOT NULL,
                                              "receiverAccountType" TEXT NOT NULL,
                                              "receiverName" TEXT NOT NULL,
                                              "receiverSurname" TEXT NOT NULL,
                                              "receiverMiddleName" TEXT,
                                              "receiverAmount" DECIMAL NOT NULL,
                                              "receiverAmountCurrency" TEXT NOT NULL,
                                              "status" TEXT NOT NULL,
                                              "createdAt" TIMESTAMP NOT NULL,
                                              "updatedAt" TIMESTAMP,
                                              "cancelledAt" TIMESTAMP
                                          );
                                      """);
    }
}