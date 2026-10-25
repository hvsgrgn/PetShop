namespace Kisallatkereskedes;

public class Owner
{
    private string name;
    private string address;
    private string IDnum;
    protected List<Animal> animals;
    protected List<Certificate> bills = new List<Certificate>();

    public string Name => name;
    public string Address => address;
    public string IDNum => IDnum;

    public List<Animal> Animals => animals;

    public List<Certificate> Bills => bills;

    public Owner(string name, string address, string iDnum, List<Animal> animals)
    {
        this.name = name;
        this.address = address;
        IDnum = iDnum;
        this.animals = animals;
    }

    public int BillsFromShop(Shop shop) {
        int count = 0;
        foreach (Certificate bill in bills) { 
            if(bill.Buyer.IDNum == shop.IDNum || bill.Seller.IDNum == shop.IDNum)
                count++;
        }
        return count;
    }

    public bool FinchOfColor(Color color) { 
        foreach (Animal a in animals) {
            if (a is Finch && color.Name == a.Color.Name)
                return true;
        }
        return false;
    }

    public virtual void Sell(Animal animal, Owner buyer) {
        if (!HasAnimal(animal))
            throw new Exception("This animal can't be sold as it is not in this owners possession!");

        animals.Remove(animal);

        if (buyer.IsShop())
        {
            int amount = animal.accept(new ColorVisitor());
            Certificate bill = new Certificate(buyer, this, amount, DateTime.Now, animal);
            bills.Add(bill);
            buyer.Buy(bill);
        }
        else {
            buyer.Buy(animal);
        }
    }

    public void Buy(Animal animal){
        animals.Add(animal);
    }

    public virtual void Buy(Certificate bill) { 
        bills.Add(bill);
        animals.Add(bill.Animal);
    }

    public bool HasAnimal(Animal animal) {
        foreach (Animal a in animals)
        {
            if (a.Id == animal.Id)
                return true;
        }
        return false;
    }

    public virtual bool IsShop() {
        return false;
    }

    public int HowManyHamsters() {
        int count = 0;
        foreach (Animal a in animals) { 
            if(a is Hamster)
                count++;
        }
        return count;
    }
}
