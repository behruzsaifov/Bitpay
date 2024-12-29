using System.ComponentModel.DataAnnotations;

namespace Bitpay.Contracts.Requests;

public class CreatePaymentRequest
{
    [Required]
    public int AccountNumber { get; init; }
    
    [Required]
    public string AccountType { get; init; }
    
    [Required]
    public float Amount { get; init; }
    
    [Required]
    public string Currency { get; init; }
}