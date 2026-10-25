using System;

namespace Kisallatkereskedes;

public class Shop : Owner
{
    private double markup;
    public double Markup => markup;
    private List<Owner> partners = new List<Owner>();
    public List<Owner> Partners => partners;

    public Shop(string name, string address, string IDnum, List<Animal> animals, double markup) : base(name, address, IDnum, animals){
        this.markup = markup;
    }

    public int GetRevenue(DateTime start, DateTime end) {
        if (end < start)
            throw new ArgumentException("The beginning of time period cannot be later than the end!");
        int income = 0;
        int expense = 0;
        foreach (Certificate bill in bills) {
            if (bill.Date >= start && bill.Date <= end) {
                if (bill.Buyer.IDNum == this.IDNum)
                    expense += bill.Amount;
                else
                    income += bill.Amount;
            }
        }

        return income - expense;
    }

    public override void Sell(Animal animal, Owner buyer)
    {
        if (!HasAnimal(animal))
            throw new Exception("This animal can't be sold as it is not in this owners posession!");

        animals.Remove(animal);

        int amount = (int)Math.Round(animal.accept(new ColorVisitor()) * (1 + markup));
        Certificate bill = new Certificate(buyer, this, amount, DateTime.Now, animal);
        AddPartner(buyer);
        bills.Add(bill);
        buyer.Buy(bill);
    }
    public int GetPartnerCount() { 
        return partners.Count;
    }

    public override bool IsShop()
    {
        return true;
    }

    public Tarantula? ExpensiveTarantula() { 
        Tarantula? ret = null;
        int max = 0;
        foreach (Animal a in animals) {
            if (a is Tarantula)
            {
                int price = a.accept(new ColorVisitor());
                if (price > max)
                { 
                    max = price;
                    ret = a as Tarantula;
                }
            }
        }
        return ret;
    }

    public override void Buy(Certificate bill)
    {
        base.Buy(bill);
        AddPartner(bill.Seller);
    }

    private void AddPartner(Owner partner) {
        if (!partners.Contains(partner))
            partners.Add(partner);
    }

}
