namespace Kisallatkereskedes;

public interface IValueVisitor
{
    public int visit(Tarantula tarantula);

    public int visit(Finch finch);

    public int visit(Hamster hamster);

}

public class ColorVisitor : IValueVisitor {
    public int visit(Tarantula tarantula) { 
        return tarantula.Value;
    }

    public int visit(Finch finch) {
        return (int)Math.Round(finch.Value * finch.Color.Mul);
    }

    public int visit(Hamster hamster)
    {
        return (int)Math.Round(hamster.Value * hamster.Color.Mul);
    }
}