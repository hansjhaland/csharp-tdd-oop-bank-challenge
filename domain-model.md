# Domain Model

## Core
|Class|Methods/Properties|Scenario|Output|
|-----|------------------|--------|------|
|CurrentAccount (BankAccount)|CurrentAccount constructor|Create a current account|New current account object|
|SavingsAccount (BankAccount)|SavingsAccount constructor|Create a savings account|New savings account object|
|Transaction|Transaction Constructor|Create a transaction|New transaction object|
|BankAccount|AddTransaction(decimal,decimal)|Add transaction to bank account|The resulting account balance|

## Extension
|Class|Methods/Properties|Scenario|Output|
|-----|------------------|--------|------|
|BankAccount|CalculateBalance|Calculate account balance based on transaction history|The account balance|
|BankAccount|Branch|Associate account with specific branch|Name of associated branch|
|CurrentAccount|RequestOverdraft(decimal)|Add overdraft to account|Overdraft object with status "pending"|
|CurrentAccount|ProcessOverdraftRequest(bool)|Approve or reject pending overdraft request|bool|
|BankAccount|SendStatementsAsMessage|Send statement as message to phone|bool|