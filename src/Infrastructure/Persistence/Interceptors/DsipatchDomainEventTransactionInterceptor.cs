using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace CleanArchitecture.Infrastructure.Persistence.Interceptors;

public class DsipatchDomainEventTransactionInterceptor : DbTransactionInterceptor
{
    public override Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
    {
        return base.TransactionCommittedAsync(transaction, eventData, cancellationToken);
    }

    public override void TransactionCommitted(DbTransaction transaction, TransactionEndEventData eventData)
    {
        base.TransactionCommitted(transaction, eventData);
    }
}
