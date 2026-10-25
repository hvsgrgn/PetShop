using Kisallatkereskedes;
using System.Reflection.PortableExecutable;

namespace TestProject1;


[TestClass]
public class SellTest
{
    private PossessionReader rdr;
    private Owner owner1;
    private Owner owner2;
    private Shop shop;

    public SellTest() {
        rdr = PossessionReader.Instance();
        owner1 = rdr.read("correct_owner1.txt", false)!;
        owner2 = rdr.read("correct_owner2.txt", false)!;
        shop = (rdr.read("correct_owner3.txt", true) as Shop)!;
    }



    [ClassInitialize]
    public static void BeforeAllTests(TestContext context)
    {
        
    }

    [TestInitialize]
    public void Setup()
    {
        
    }

    [TestMethod]
    public void OwnerSellToOwnerTest()
    {
        Animal firstSold = owner2.Animals[0];
        owner2.Sell(firstSold, owner1);
        Assert.AreEqual(0, owner1.Bills.Count);
        Assert.AreEqual(0, owner2.Bills.Count);
        Assert.IsFalse(owner2.Animals.Contains(firstSold));
        Assert.IsTrue(owner1.Animals.Contains(firstSold));
    }

    [TestMethod]
    public void OwnerSellToShop() {
        Animal firstSold = owner2.Animals[0];
        owner2.Sell(firstSold, shop);
        Assert.AreEqual(1, owner2.Bills.Count);
        Assert.AreEqual(1, shop.Bills.Count);
        Certificate bill = shop.Bills[0];
        Assert.AreEqual(owner2.IDNum, bill.Seller.IDNum);
        Assert.AreEqual(shop.IDNum, bill.Buyer.IDNum);
        Assert.AreEqual(firstSold.Id, bill.Animal.Id);
        Assert.AreEqual(bill.Amount, firstSold.accept(new ColorVisitor()));
        Assert.IsTrue(shop.Partners.Contains(owner2));
        Assert.IsTrue(shop.Animals.Contains(firstSold));
        Assert.IsFalse(owner2.Animals.Contains(firstSold));
    }

    [TestMethod]
    public void ShopSellToOwner() {
        Animal firstSold = shop.Animals[0];
        shop.Sell(firstSold, owner1);
        Assert.AreEqual(1, owner1.Bills.Count);
        Assert.AreEqual(1, shop.Bills.Count);
        Certificate bill = shop.Bills[0];
        Assert.IsTrue(shop.Partners.Contains(owner1));
        Assert.AreEqual(shop.IDNum, bill.Seller.IDNum);
        Assert.AreEqual(owner1.IDNum, bill.Buyer.IDNum);
        Assert.AreEqual(firstSold.Id, bill.Animal.Id);
        Assert.AreEqual(bill.Amount, (int)Math.Round(firstSold.accept(new ColorVisitor()) * (1 + shop.Markup)));
        Assert.IsFalse(shop.Animals.Contains(firstSold));
        Assert.IsTrue(owner1.Animals.Contains(firstSold));
    }

    [TestMethod]
    public void SellNotInPossession() {
        Animal Aprocska = new Hamster("Aprocska", Color.WHITE, 3000, 0);
        Assert.ThrowsException<Exception>(() => { shop.Sell(Aprocska, owner2); });
    }


}
