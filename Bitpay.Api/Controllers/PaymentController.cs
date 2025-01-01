using Bitpay.Api.Mapping;
using Bitpay.Application.Repositories;
using Bitpay.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Bitpay.Api.Controllers;

[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentController(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    [HttpPost(ApiEndpoints.Payments.Create)]
    public async Task<IActionResult> Create([FromBody] CreatePaymentRequest request, CancellationToken token = default)
    {
        var payment = request.MapToPayment();
        var result = await _paymentRepository.CreateAsync(payment, token);
        if (result is true)
        {
            return Created(payment.Id.ToString(), payment);
        }
        return BadRequest("Invalid payment request");
    }
    
    [HttpPut(ApiEndpoints.Payments.Approve)]
    public async Task<IActionResult> Update([FromRoute] Guid id,
        CancellationToken token = default)
    { var result = await _paymentRepository.ApproveAsync(id, token);
        if (result is true)
        {
            return Ok();
        }
        return NotFound();
    }
}