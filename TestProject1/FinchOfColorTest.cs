using Kisallatkereskedes;

namespace TestProject1;

[TestClass]
public class FinchOfColorTest
{
    private PossessionReader rdr;

    public FinchOfColorTest() {
        rdr = PossessionReader.Instance();
    }

    [TestMethod]
    public void NoFinchTest() {
        Owner owner = (rdr.read("correct_owner1.txt", false))!;
        Assert.IsFalse(owner.FinchOfColor(Color.WHITE));
    }

    [TestMethod]
    public void OneFinchButNotInColor() {
        Owner owner = (rdr.read("correct_owner4.txt", false))!;
        Assert.IsFalse(owner.FinchOfColor(Color.BLACK));
    }

    [TestMethod]
    public void TwoFinchInColor()
    {
        Owner owner = (rdr.read("correct_owner5.txt", false))!;
        Assert.IsTrue(owner.FinchOfColor(Color.BROWN));
    }
}
