namespace Classes;

public class Transiction{
    public DateTime date{get;init;}
    public int Amount{get;}
    public string? Note{get;set;}
    public Transiction(int amount,string note)
    {
	this.Amount =amount;
	this.Note = note;
	this.date = DateTime.UtcNow;
    }
}

