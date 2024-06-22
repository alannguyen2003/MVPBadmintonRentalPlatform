using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class TransactionStatusService : ITransactionStatusService
{
    private readonly ITransactionStatusRepository _transactionStatusRepository;

    public TransactionStatusService(ITransactionStatusRepository transactionStatusRepository)
    {
        _transactionStatusRepository = transactionStatusRepository;
    }
    public async Task<List<TransactionStatus>> GetAllTransactionStatus()
    {
        return await _transactionStatusRepository.GetAllTransactionStatus();
    }

    public async Task AddNewTransactionStatus(TransactionStatus transactionStatus)
    {
        await _transactionStatusRepository.AddNewTransactionStatus(transactionStatus);
    }

    public async Task AddRangeTransactionStatus(List<TransactionStatus> transactionStatusList)
    {
        await _transactionStatusRepository.AddRangeTransactionStatus(transactionStatusList);
    }
}