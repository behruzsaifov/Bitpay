using Bitpay.Application;
using Bitpay.Application.Models;
using Bitpay.Contracts.Requests;

namespace Bitpay.Api.Mapping;

public static class ContractMapping
{
    public static Payment MapToPayment(this CreatePaymentRequest request)
    {
        return new Payment
        {
            Id = Guid.NewGuid(),
            AccountNumber = request.AccountNumber,
            AccountType = request.AccountType,
            Amount = request.Amount,
            Currency = request.Currency,
            Status = PaymentStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
    }
}