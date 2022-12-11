// See https://aka.ms/new-console-template for more information
using Classes;

var account = new BankAccount("smth", 1000);
account.MakeWithdrawal(500, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, "Friend paid me back");
Console.WriteLine(account.GetAccountHistory());






