namespace Kisallatkereskedes;
public class Color
{
    public static readonly Color WHITE = new Color("WHITE", 4.0);
    public static readonly Color BLACK = new Color("BLACK", 1.0);
    public static readonly Color BROWN = new Color("BROWN", 1.0);
    public static readonly Color GREY = new Color("GREY", 2.0);

    private readonly string name;
    private readonly double mul;

    public string Name => name;

    private Color(string name, double mul)
    {
        this.name = name;
        this.mul = mul;
    }

    public double Mul => mul;
    public override string ToString() => name;

    public static Color FromString(string colorName)
    {
        return colorName.ToUpper() switch
        {
            "WHITE" => WHITE,
            "BLACK" => BLACK,
            "BROWN" => BROWN,
            "GREY" => GREY,
            _ => throw new ArgumentException($"Unknown color: {colorName}")
        };
    }
}
