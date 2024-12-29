using System.ComponentModel.DataAnnotations;

namespace Bitpay.Application.Models;

public class Payment
{
    [Required]
    public Guid Id { get; init; }
    
    [Required]
    public int AccountNumber { get; set; }
    
    [Required]
    public string AccountType { get; set; }
    
    [Required]
    public float Amount { get; set; }
    
    [Required]
    public string Currency { get; set; }

    public string Status { get; set; }
    
    public DateTime? CreatedAt { get; init; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? CanceledAt { get; set; }
}