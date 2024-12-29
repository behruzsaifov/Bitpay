using System.Transactions;
using Bitpay.Application.Database;
using Bitpay.Application.Models;
using Dapper;

namespace Bitpay.Application.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public PaymentRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<bool> CreateAsync(Payment payment, CancellationToken token = default)
    {
        if (payment == null) throw new ArgumentNullException(nameof(payment));

        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();
    
        try
        {
            var result = await connection.ExecuteAsync(
                new CommandDefinition("""
                                      INSERT INTO payments (id, "accountNumber", "accountType", amount, currency, status, "createdAt")
                                      VALUES (@Id, @AccountNumber, @AccountType, @Amount, @Currency, @Status, @CreatedAt)
                                      """, 
                    payment, 
                    cancellationToken: token
                )
            );

            if (result > 0)
            { 
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result > 0;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            // Log the exception (e.g., using ILogger)
            throw new ApplicationException("Failed to insert payment into the database.", ex);
        }
    }
}