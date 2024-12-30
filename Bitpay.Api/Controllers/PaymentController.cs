using Bitpay.Api.Mapping;
using Bitpay.Application.Repositories;
using Bitpay.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Bitpay.Api.Controllers;

public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentController(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    [HttpPost("/api/payment")]
    public async Task<IActionResult> Create([FromBody] CreatePaymentRequest request, CancellationToken token)
    {
        var payment = request.MapToPayment();
        var result = await _paymentRepository.CreateAsync(payment, token);
        if (result is true)
        {
            return Created(payment.Id.ToString(), payment);
        }
        return BadRequest("Invalid payment request");
    }
}