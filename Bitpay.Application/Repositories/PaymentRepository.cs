using Bitpay.Application.Database;
using Bitpay.Application.Models;
using Bitpay.Contracts.Responses;
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
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();

        try
        {
            var result = await connection.ExecuteAsync(
                new CommandDefinition("""
                                      INSERT INTO payments (
                                          "id", 
                                          "senderAccountNumber", 
                                          "senderAccountType", 
                                          "senderName", 
                                          "senderSurname", 
                                          "senderMiddleName", 
                                          "senderAmount", 
                                          "senderAmountCurrency", 
                                          "receiverAccountNumber", 
                                          "receiverAccountType", 
                                          "receiverName", 
                                          "receiverSurname", 
                                          "receiverMiddleName", 
                                          "receiverAmount", 
                                          "receiverAmountCurrency", 
                                          "status", 
                                          "createdAt"
                                      )
                                      VALUES (
                                          @Id, 
                                          @SenderAccountNumber, 
                                          @SenderAccountType, 
                                          @SenderName, 
                                          @SenderSurname, 
                                          @SenderMiddleName, 
                                          @SenderAmount, 
                                          @SenderAmountCurrency, 
                                          @ReceiverAccountNumber, 
                                          @ReceiverAccountType, 
                                          @ReceiverName, 
                                          @ReceiverSurname, 
                                          @ReceiverMiddleName, 
                                          @ReceiverAmount, 
                                          @ReceiverAmountCurrency, 
                                          @Status, 
                                          @CreatedAt
                                      )
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

    public async Task<bool> ApproveAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();
        var result = await connection.ExecuteAsync(
            new CommandDefinition(
                """
                UPDATE payments 
                SET status = 'Approved' 
                WHERE id = @Id
                AND status <> 'Approved'
                """,
                new { Id = id },
                cancellationToken: token
            )
        );

        if (result > 0)
        {
            transaction.Commit();
            return true; // Indicate success
        }
        else
        {
            transaction.Rollback();
            return false;
        }
    }

    public async Task<Payment?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var payment = await connection.QuerySingleOrDefaultAsync<Payment>(new CommandDefinition("""
            SELECT *
            FROM payments
            WHERE id = @Id
            """, new { id }, cancellationToken: token));
        if (payment is null)
        {
            return null;
        }
        return payment;
    }

    public async Task<IEnumerable<Payment>> GetAllAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var payments = await connection.QueryAsync<Payment>(new CommandDefinition("""
            SELECT * FROM
            payments
            """, cancellationToken: token));
        return payments;
    }

    public async Task<bool> CancelAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();
        var result = await connection.ExecuteAsync(
            new CommandDefinition(
                """
                UPDATE payments 
                SET status = 'Cancelled',
                "cancelledAt" = NOW() + INTERVAL '5 hours'
                WHERE id = @Id
                AND status <> 'Cancelled'
                """,
                new { Id = id },
                cancellationToken: token
            )
        );

        if (result > 0)
        {
            transaction.Commit();
            return true;
        }
        else
        {
            transaction.Rollback();
            return false;
        }
    }
}