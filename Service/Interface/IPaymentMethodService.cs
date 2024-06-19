using BusinessObject;

namespace Service.Interface;

public interface IPaymentMethodService
{
    public Task<List<PaymentMethod>> GetAllPaymentMethod();
    public Task<PaymentMethod?> GetPaymentMethodById(int paymentMethodId);
    public Task AddPaymentMethodAsync(PaymentMethod paymentMethod);
    public Task AddRangePaymentMethodAsync(List<PaymentMethod> payments);
}