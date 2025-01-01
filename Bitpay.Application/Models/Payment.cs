using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Bitpay.Application.Models;

public class Payment
{
    [Required]
    public Guid Id { get; init; }
    [Required]
    public int SenderAccountNumber { get; set; }
    [Required] 
    public string SenderAccountType {get; set; }
    [Required]
    public string SenderName { get; set; }
    [Required]
    public string SenderSurname { get; set; }
    
    public string? SenderMiddleName  { get; set; }
    
    [Required]
    public decimal SenderAmount { get; set; }
    
    [Required]
    public string SenderAmountCurrency { get; set; }

    [Required]
    public int ReceiverAccountNumber { get; set; }
    [Required] 
    public string ReceiverAccountType {get; set; }
    [Required]
    public string ReceiverName { get; set; }
    [Required]
    public string ReceiverSurname { get; set; }
    
    public string? ReceiverMiddleName  { get; set; }
    
    [Required]
    public decimal ReceiverAmount { get; set; }
    
    [Required]
    [MaxLength(3)]
    public string ReceiverAmountCurrency { get; set; }
    public string Status { get; set; }
    public DateTime? CreatedAt { get; init; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? CanceledAt { get; set; }
}