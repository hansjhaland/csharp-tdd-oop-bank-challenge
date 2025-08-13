﻿using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete.Accounts
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(Branch branch) : base(branch)
        {
        }
    }
}
