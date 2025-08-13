using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Enums
{
    public enum Branch
    {
        Oslo,
        Bergen,
        Trondheim
    }

    public enum OverdraftStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public enum TransactionType
    {
        Credit,
        Debit
    }
}
