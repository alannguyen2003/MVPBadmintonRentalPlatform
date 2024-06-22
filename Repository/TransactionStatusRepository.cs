using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class TransactionStatusRepository : ITransactionStatusRepository
{
    public async Task<List<TransactionStatus>> GetAllTransactionStatus()
    {
        return await TransactionStatusDAO.Instance.GetAllTransactionStatus();
    }

    public async Task AddNewTransactionStatus(TransactionStatus transactionStatus)
    {
        await TransactionStatusDAO.Instance.AddNewTransactionStatus(transactionStatus);
    }

    public async Task AddRangeTransactionStatus(List<TransactionStatus> transactionStatusList)
    {
        await TransactionStatusDAO.Instance.AddRangeTransactionStatus(transactionStatusList);
    }
}