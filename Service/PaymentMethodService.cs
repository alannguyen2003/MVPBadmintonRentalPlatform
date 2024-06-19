using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
    }
    public async Task<List<PaymentMethod>> GetAllPaymentMethod()
    {
        return await _paymentMethodRepository.GetAllPaymentMethod();
    }

    public async Task<PaymentMethod?> GetPaymentMethodById(int paymentMethodId)
    {
        return await _paymentMethodRepository.GetPaymentMethodById(paymentMethodId);
    }

    public async Task AddPaymentMethodAsync(PaymentMethod paymentMethod)
    {
        await _paymentMethodRepository.AddPaymentMethodAsync(paymentMethod);
    }

    public async Task AddRangePaymentMethodAsync(List<PaymentMethod> payments)
    {
        await _paymentMethodRepository.AddRangePaymentMethodAsync(payments);
    }
}