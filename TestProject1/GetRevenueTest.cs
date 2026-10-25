using Kisallatkereskedes;

namespace TestProject1;


[TestClass]
public class GetRevenueTest
{
    private PossessionReader rdr;
    private DateTime testStartTime;
    private DateTime testEndTime;
    private Owner owner;

    public GetRevenueTest() {
        rdr = PossessionReader.Instance();
        testStartTime = DateTime.Now;
        testEndTime = testStartTime.AddMinutes(1);
        owner = (rdr.read("correct_owner3.txt", true))!;
    }

    [TestMethod]
    public void TestEmpty()
    {
        Assert.AreEqual(0,(owner as Shop)!.GetRevenue(testStartTime,testEndTime));
    }

    [TestMethod]
    public void TestIncorrect()
    {
        Assert.ThrowsException<ArgumentException>(() => { (owner as Shop)!.GetRevenue(testEndTime, testStartTime); });
    }

    [TestMethod]
    public void TestCorrect() {
        Owner owner2 = (rdr.read("correct_owner2.txt", false))!;
        Animal soldFirst = owner.Animals[0];
        Animal soldSecond = owner2.Animals[0];
        owner.Sell(soldFirst, owner2);
        owner2.Sell(soldSecond, owner);
        Assert.AreEqual(owner.Bills[0].Amount - owner.Bills[1].Amount, (owner as Shop)!.GetRevenue(testStartTime, testEndTime));
    }

    [TestMethod]
    public void TestOutOfWindow() { 
        Owner owner2 = (rdr.read("correct_owner2.txt", false))!;
        Animal soldFirst = owner.Animals[0];
        Animal soldSecond = owner2.Animals[0];
        owner.Sell(soldFirst, owner2);
        
        System.Threading.Thread.Sleep(1000);

        owner2.Sell(soldSecond, owner);

        Assert.AreEqual(owner.Bills[0].Amount, (owner as Shop)!.GetRevenue(testStartTime, testStartTime.AddSeconds(0.5)));
    }
}
