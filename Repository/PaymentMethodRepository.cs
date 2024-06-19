using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class PaymentMethodRepository : IPaymentMethodRepository
{
    public async Task<List<PaymentMethod>> GetAllPaymentMethod()
    {
        return await PaymentMethodDAO.Instance.GetAllPaymentMethod();
    }

    public async Task<PaymentMethod?> GetPaymentMethodById(int paymentMethodId)
    {
        return await PaymentMethodDAO.Instance.GetPaymentMethodById(paymentMethodId);
    }

    public async Task AddPaymentMethodAsync(PaymentMethod paymentMethod)
    {
        await PaymentMethodDAO.Instance.AddPaymentMethodAsync(paymentMethod);
    }

    public async Task AddRangePaymentMethodAsync(List<PaymentMethod> payments)
    {
        await PaymentMethodDAO.Instance.AddRangePaymentMethodAsync(payments);
    }
}