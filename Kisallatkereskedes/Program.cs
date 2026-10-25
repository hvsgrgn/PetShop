namespace Kisallatkereskedes
{
    public class Program
    {
        static void Main(string[] args)
        {
            PossessionReader rdr = PossessionReader.Instance();
            Owner? partner1 = rdr.read("correct_owner4.txt", false);
            Owner? partner2 = rdr.read("correct_owner4.txt", false);
            Owner? partner3 = rdr.read("correct_owner3.txt", false);
            Shop? bolt = rdr.read("correct_owner2.txt", true) as Shop;
            if (partner1 is null || partner2 is null || partner3 is null || bolt is null)
            {
                Console.WriteLine("Sikertelen beolvasas");
                return;
            }


            foreach(Animal a in bolt.Animals)
            {
                Console.WriteLine($"Bolt allata(i) az eladasok elott: {a.Id}");
            }
            bolt.Sell(bolt.Animals[0], partner1);
            partner1.Sell(partner1.Animals[0], partner2);
            partner2.Sell(partner2.Animals[0], bolt);
            partner3.Sell(partner3.Animals[0], bolt);
            foreach (Animal a in bolt.Animals)
            {
                Console.WriteLine($"Bolt allata(i): {a.Id}");
            }
            foreach (Certificate bill in bolt.Bills)
            {
                Console.WriteLine($"Bolt szamlai: {bill.Animal.Id}");
            }
        }
    }
}
