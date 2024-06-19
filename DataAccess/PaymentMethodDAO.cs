using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class PaymentMethodDAO
{
    private readonly AppDbContext _context;
    private static PaymentMethodDAO instance;
    
    public PaymentMethodDAO()
    {
        _context = new AppDbContext();
    }

    public static PaymentMethodDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PaymentMethodDAO();
            }
            return instance;
        }
    }

    public async Task<List<PaymentMethod>> GetAllPaymentMethod()
    {
        return await _context.PaymentMethods.ToListAsync();
    }

    public async Task<PaymentMethod?> GetPaymentMethodById(int paymentMethodId)
    {
        return await _context.PaymentMethods.FindAsync(paymentMethodId);
    }

    public async Task AddPaymentMethodAsync(PaymentMethod paymentMethod)
    {
        await _context.PaymentMethods.AddAsync(paymentMethod);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangePaymentMethodAsync(List<PaymentMethod> payments)
    {
        await _context.PaymentMethods.AddRangeAsync(payments);
        await _context.SaveChangesAsync();
    }
}