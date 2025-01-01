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
            SenderAccountNumber = request.SenderAccountNumber,
            SenderAccountType = request.SenderAccountType,
            SenderName = request.SenderName,
            SenderSurname = request.SenderSurname,
            SenderMiddleName = request.SenderMiddleName,
            SenderAmount = request.SenderAmount,
            SenderAmountCurrency = request.SenderAmountCurrency,
            ReceiverAccountNumber = request.ReceiverAccountNumber,
            ReceiverAccountType = request.ReceiverAccountType,
            ReceiverName = request.ReceiverName,
            ReceiverSurname = request.ReceiverSurname,
            ReceiverMiddleName = request.ReceiverMiddleName,
            ReceiverAmount = request.ReceiverAmount,
            ReceiverAmountCurrency = request.ReceiverAmountCurrency,
            Status = PaymentStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
    }
}