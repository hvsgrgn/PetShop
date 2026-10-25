using System.Text;

namespace Kisallatkereskedes;

public class PossessionReader
{
    private static PossessionReader? instance = null;

    public static PossessionReader Instance() {
        if (instance == null)
            instance = new PossessionReader();
        return instance;
    }

    private PossessionReader() {
    }

    public Owner? read(string filename, bool returnShop)
    {
        try {
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            if (lines.Length == 0)  //ha nincsenek is allatai, legalabb az allatarto adatai szerepeljenek az elso sorban
                throw new InvalidDataException();

            string[] ownerData = lines[0].Split(" ");
            if(ownerData.Length != 3)
                throw new InvalidDataException();
            List<Animal> animals = new List<Animal>();

            for (int i = 1; i < lines.Length; i++)
            {
                try
                {
                    string[] animalData = lines[i].Split(" ");
                    if (animalData.Length != 5)
                        throw new InvalidDataException($"Animal number {i} did not have all the required data to register");
                    bool b1 = int.TryParse(animalData[3], out int value);
                    bool b2 = int.TryParse(animalData[4], out int age);
                    if (!b1 || !b2)
                        throw new InvalidDataException($"Animal number {i} did not have integer values for value or age variables");
                    if(value < 0 || age < 0)
                        throw new InvalidDataException("Animal age and/or value should not be negative");
                    Color color = Color.FromString(animalData[2]);
                    switch (animalData[0])
                    {
                        case "Tarantula":
                            animals.Add(new Tarantula(animalData[1], color, value, age));
                            break;
                        case "Hamster":
                            animals.Add(new Hamster(animalData[1], color, value, age));
                            break;
                        case "Finch":
                            animals.Add(new Finch(animalData[1], color, value, age));
                            break;
                        default:
                            throw new InvalidDataException($"There is no species in the database for {animalData[0]}");
                    }
                }
                catch (Exception e) when (e is InvalidDataException || e is ArgumentException)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            if(!returnShop)
                return new Owner(ownerData[0], ownerData[1], ownerData[2], animals);
            return new Shop(ownerData[0], ownerData[1], ownerData[2], animals, new Random().NextDouble());
        }
        catch (Exception e) when (e is InvalidDataException || e is IOException)
        { 
            Console.WriteLine(e.Message);
            return null;
        }
    }

}
