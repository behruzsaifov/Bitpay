using System.ComponentModel.DataAnnotations;

namespace Bitpay.Contracts.Requests;

public class CreatePaymentRequest
{
    [Required]
    public int SenderAccountNumber { get; init; }

    [Required]
    public string SenderAccountType { get; init; }

    [Required]
    public string SenderName { get; init; }

    [Required]
    public string SenderSurname { get; init; }

    public string? SenderMiddleName { get; init; }

    [Required]
    public decimal SenderAmount { get; init; }

    [Required]
    public string SenderAmountCurrency { get; init; }

    [Required]
    public int ReceiverAccountNumber { get; init; }

    [Required]
    public string ReceiverAccountType { get; init; }

    [Required]
    public string ReceiverName { get; init; }

    [Required]
    public string ReceiverSurname { get; init; }

    public string? ReceiverMiddleName { get; init; }

    [Required]
    public decimal ReceiverAmount { get; init; }

    [Required]
    public string ReceiverAmountCurrency { get; init; }
}