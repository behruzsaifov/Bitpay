using System.ComponentModel.DataAnnotations;

namespace Bitpay.Contracts.Responses;

public class PaymentResponse
{
    [Required]
    public Guid Id { get; init; }
    
    [Required]
    public int AccountNumber { get; init; }
    
    [Required]
    public string AccountType { get; init; }
    
    [Required]
    public float Amount { get; init; }
    
    [Required]
    public string Currency { get; init; }

    [Required]
    public string status { get; init; }

    [Required]
    public DateTime? CreatedAt { get; init; }
    
    [Required]
    public DateTime? UpdatedAt { get; init; }
    
    [Required]
    public DateTime? CanceledAt { get; init; }
}