using Kisallatkereskedes;
namespace TestProject1;


[TestClass]
public class PossessionReaderTest
{
    private PossessionReader rdr;

    public PossessionReaderTest() {
        rdr = PossessionReader.Instance();
    }


    [TestMethod]
    public void TestEmpty()
    {
        Assert.IsNull(rdr.read("empty.txt", false));     
    }

    [TestMethod]
    public void TestPartiallyIncorrect()
    {
        Owner? owner = rdr.read("partially_incorrect_owner.txt", false);
        Assert.IsNotNull( owner );
        Assert.AreEqual("1111", owner.IDNum);
        Assert.AreEqual("Laci", owner.Name);
        Assert.AreEqual("pipacskorut7", owner.Address);
        Assert.AreEqual("Cirmi, Pipi", string.Join(", ", owner.Animals));
        Assert.AreEqual(0, owner.Animals[0].Age);
        Assert.AreEqual(10000, owner.Animals[1].Value);
    }

    [TestMethod]
    public void TestNonExistent()
    {
        Assert.IsNull(rdr.read("non_existent.txt", false));
    }

    [TestMethod]
    public void TestNoAnimals() {
        Owner? owner = rdr.read("correct_owner1.txt", false);
        Assert.IsNotNull(owner);
        Assert.AreEqual("Pityu", owner.Name);
        Assert.AreEqual("5678", owner.IDNum);
        Assert.AreEqual("kisallatutca63", owner.Address);
        Assert.AreEqual("", string.Join(", ", owner.Animals));
    }

    [TestMethod]
    public void TestIncorrectOwnerData() {
        Assert.IsNull(rdr.read("incorrect_owner_data.txt", false));
    }

    [TestMethod]
    public void TestShop() {
        Owner? owner = rdr.read("correct_owner2.txt", true);
        Assert.IsNotNull(owner);
        Assert.AreEqual("Feri", owner.Name);
        Assert.AreEqual("5656", owner.IDNum);
        Assert.AreEqual("kisallatutca13", owner.Address);
        Assert.AreEqual("Ham", string.Join(", ", owner.Animals));
        Assert.IsNotNull((owner as Shop));
        Assert.IsTrue(owner.IsShop());        
    }
}