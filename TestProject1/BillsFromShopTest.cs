using Kisallatkereskedes;
namespace TestProject1;


[TestClass]
public class BillsFromShopTest
{
    private PossessionReader rdr;

    public BillsFromShopTest() {
        rdr = PossessionReader.Instance();
    }


    [TestMethod]
    public void NoBillsAtAllTest() {
        Owner owner = rdr.read("correct_owner2.txt", false)!;
        Shop shop = ((rdr.read("correct_owner1.txt", true)) as Shop)!;
        Assert.AreEqual(0, owner.BillsFromShop(shop));
    }

    [TestMethod]
    public void NoBillsFromShopTest()
    {
        Owner owner = (rdr.read("correct_owner2.txt", false))!;
        Shop shop1 = ((rdr.read("correct_owner1.txt", true)) as Shop)!;
        Shop shop2 = ((rdr.read("correct_owner3.txt", true)) as Shop)!;
        owner.Sell(owner.Animals[0], shop1);
        Assert.AreEqual(0, owner.BillsFromShop(shop2));
    }

    [TestMethod]
    public void HasBillsFromShopTest()
    {
        Owner owner = (rdr.read("correct_owner2.txt", false))!;
        Shop shop2 = ((rdr.read("correct_owner3.txt", true)) as Shop)!;
        owner.Sell(owner.Animals[0], shop2);
        shop2.Sell(shop2.Animals[0], owner);
        Assert.AreEqual(2, owner.BillsFromShop(shop2));
    }
}
