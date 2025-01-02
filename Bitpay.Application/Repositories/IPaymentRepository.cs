using Bitpay.Application.Models;
using Bitpay.Contracts.Responses;

namespace Bitpay.Application.Repositories;

public interface IPaymentRepository
{
   Task<bool> CreateAsync(Payment payment, CancellationToken token = default);
   
   Task<bool> ApproveAsync(Guid id, CancellationToken token = default);
   
   Task<Payment> GetByIdAsync(Guid id, CancellationToken token = default);
   Task<IEnumerable<Payment>> GetAllAsync(CancellationToken token = default);
}