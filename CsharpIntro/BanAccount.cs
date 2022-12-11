namespace Classes;

public class BankAccount
{
    private List<Transiction> allTransictions = new List<Transiction>();
    private static int accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public int Balance { 
	get
	{
	    int total =0;
	    foreach(Transiction item in allTransictions)
		total+=item.Amount;
	    return total;
	}
	}
    public BankAccount(string name,int InitialBalance)
    {
	    this.Owner = name;
	    this.Number = accountNumberSeed.ToString();
	    accountNumberSeed++;
	    MakeDeposit(InitialBalance,"InitialBalance");
    }
    public void MakeDeposit(int amount, string note)
    {
	if(amount<=0){
	    throw new ArgumentOutOfRangeException(nameof(amount),"Amount of Deposit must be Postive");
	}
	Transiction deposit = new Transiction(amount,note);
	allTransictions.Add(deposit);
    }

    public void MakeWithdrawal(int amount, string note)
    {
	if(amount>this.Balance){
	    throw new ArgumentOutOfRangeException(nameof(amount),"Amount Of Whitdrawl is more than Balance");
	}
	Transiction whitdrawl = new Transiction(-amount,note);
	allTransictions.Add(whitdrawl);
    }
       public string GetAccountHistory()
	{
	    var report = new System.Text.StringBuilder();

	    decimal balance = 0;
	    report.AppendLine("Date\t\tAmount\tBalance\tNote");
	    foreach (var item in this.allTransictions)
	    {
		balance += item.Amount;
		report.AppendLine($"{item.date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
	    }

	return report.ToString();
	}     
}
