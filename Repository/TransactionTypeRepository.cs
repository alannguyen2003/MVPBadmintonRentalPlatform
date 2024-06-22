using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class TransactionTypeRepository : ITransactionTypeRepository
{
    public async Task<List<TransactionType>> GetAllTransactionType()
    {
        return await TransactionTypeDAO.Instance.GetAllTransactionTypes();
    }

    public async Task AddNewTransactionType(TransactionType transactionType)
    {
        await TransactionTypeDAO.Instance.AddNewTransactionType(transactionType);
    }

    public async Task AddRangeTransactionType(List<TransactionType> transactionTypes)
    {
        await TransactionTypeDAO.Instance.AddRangeTransactionType(transactionTypes);
    }
}