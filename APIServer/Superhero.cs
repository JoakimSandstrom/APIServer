using System;

public class Superhero
{
    public string Name { get; set; }
    public int Power { get; set; } 
    public bool UnderwearOnTheOutside { get; set; }
    public Superhero(string name, int power, bool underwearOnTheOutside)
    {
        Name = name;
        Power = power;
        UnderwearOnTheOutside = underwearOnTheOutside;
    }
    public Superhero()
    {
        Name = "";
    }
}
