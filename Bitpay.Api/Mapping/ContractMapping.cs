using Bitpay.Application;
using Bitpay.Application.Models;
using Bitpay.Contracts.Requests;
using Bitpay.Contracts.Responses;

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

    public static PaymentResponse MapToResponse(this Payment payment)
    {
        return new PaymentResponse()
        {
            Id = payment.Id,
            SenderAccountNumber = payment.SenderAccountNumber,
            SenderAccountType = payment.SenderAccountType,
            SenderName = payment.SenderName,
            SenderSurname = payment.SenderSurname,
            SenderMiddleName = payment.SenderMiddleName,
            SenderAmount = payment.SenderAmount,
            SenderAmountCurrency = payment.SenderAmountCurrency,
            ReceiverAccountNumber = payment.ReceiverAccountNumber,
            ReceiverAccountType = payment.ReceiverAccountType,
            ReceiverName = payment.ReceiverName,
            ReceiverSurname = payment.ReceiverSurname,
            ReceiverMiddleName = payment.ReceiverMiddleName,
            ReceiverAmount = payment.ReceiverAmount,
            ReceiverAmountCurrency = payment.ReceiverAmountCurrency,
            Status = PaymentStatus.Pending,
            CreatedAt = payment.CreatedAt,
            UpdatedAt = payment.UpdatedAt,
            CancelledAt = payment.CancelledAt
        };
    }

    public static PaymentsResponse MapToResponse(this IEnumerable<Payment> payment)
    {
        return new PaymentsResponse()
        {
            Items = payment.Select(MapToResponse).ToList()
        };
    }
}