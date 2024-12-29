using Bitpay.Application.Models;

namespace Bitpay.Application.Repositories;

public class PaymentRepository : IPaymentRepository
{
    public Task<bool> CreateAsync(Payment payment, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}