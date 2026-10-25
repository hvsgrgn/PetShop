using Kisallatkereskedes;
namespace TestProject1;


[TestClass]
public class ColorVisitorTest
{
    [TestMethod]
    public void CalculateTarantulaValueTest() {
        Tarantula tarantula = new Tarantula("Tarantula", Color.BLACK, 20000, 3);
        Assert.AreEqual(20000, tarantula.accept(new ColorVisitor()));
    }

    [TestMethod]
    public void CalculateOthersValueTest(){
        Finch finch = new Finch("finch", Color.WHITE, 3000, 0);
        Assert.AreEqual(12000, finch.accept(new ColorVisitor()));
        Hamster hamster = new Hamster("hamster", Color.GREY, 2000, 1);
        Assert.AreEqual(4000, hamster.accept(new ColorVisitor()));
    }
}
