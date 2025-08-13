using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public class Overdraft
    {
        private OverdraftStatus _status = OverdraftStatus.Pending;
        private decimal _amount;

        public Overdraft(decimal amount)
        {
            _amount = amount;
        }

        public OverdraftStatus Status { get { return _status; } set { _status = value; } }
        public decimal Amount { get { return _amount; } }
    }
}
