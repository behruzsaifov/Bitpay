using System.ComponentModel.DataAnnotations;

namespace Bitpay.Contracts.Responses;

public class PaymentsResponse
{
    [Required]
    public IEnumerable<PaymentResponse> Items { get; init; } = [];
}