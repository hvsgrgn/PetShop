using System.Drawing;

namespace Kisallatkereskedes;

public abstract class Animal
{
    private string id;
    public string Id => id;

    private Color color;

    public Color Color => color;

    private int value;

    public int Value => value;

    private int age;
    public int Age => age;

    public Animal(string name, Color color, int value, int age) { 
        this.id = name;
        this.color = color;
        this.value = value;
        this.age = age;
    }

    public abstract int accept(IValueVisitor visitor);

    public override string ToString()
    {
        return id;
    }
}

public class Tarantula : Animal {
    public Tarantula(string name, Color color, int value, int age) : base(name, color, value, age) {}

    public override int accept(IValueVisitor visitor) { 
        return visitor.visit(this);
    }
}

public class Hamster : Animal
{
    public Hamster(string name, Color color, int value, int age) : base(name, color, value, age) {}

    public override int accept(IValueVisitor visitor)
    {
        return visitor.visit(this);
    }
}

public class Finch : Animal
{
    public Finch(string name, Color color, int value, int age) : base(name, color, value, age) { }

    public override int accept(IValueVisitor visitor)
    {
        return visitor.visit(this);
    }
}
