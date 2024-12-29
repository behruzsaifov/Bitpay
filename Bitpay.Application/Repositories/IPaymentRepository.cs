using Bitpay.Application.Models;

namespace Bitpay.Application.Repositories;

public interface IPaymentRepository
{
   Task<bool> CreateAsync(Payment payment, CancellationToken token = default);
}