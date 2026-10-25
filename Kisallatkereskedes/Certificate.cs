namespace Kisallatkereskedes;

public class Certificate
{
    private Owner buyer;
    private Owner seller;
    private int amount;
    private DateTime date;
    private Animal animal;

    public Owner Buyer => buyer;
    public Owner Seller => seller;
    public int Amount => amount;
    public DateTime Date => date;
    public Animal Animal => animal;

    public Certificate(Owner buyer, Owner seller, int amount, DateTime date, Animal animal)
    {
        this.buyer = buyer;
        this.seller = seller;
        this.amount = amount;
        this.date = date;
        this.animal = animal;
    }
}
