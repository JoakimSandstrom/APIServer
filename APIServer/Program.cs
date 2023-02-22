WebApplication app = WebApplication.Create();

app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

List<Superhero> heroes = new();
Superhero hero = new();

heroes.Add(new Superhero("Superman",9000,true));

app.MapGet("/", () =>
{
    return "Hello\n'../NameOfHero' => returns hero of that name\n'../add/string NameOfHero,int powerLevel,bool underwearOnTheOutside' => adds a new hero to the list\n'/list' => returns a list of all heroes";
});

app.MapGet("/hero/{name}/" , (string name) =>
{
    Superhero hero = heroes.Find(x => x.Name == name);
    if (hero != null)
    {
        return Results.Ok(hero);
    }
    else return Results.NotFound();
});

app.MapGet("/add/{name},{power},{underwearOnTheOutside}/", (string name, int power, bool underwearOnTheOutside) =>
{
    Superhero hero = heroes.Find(x => x.Name == name);
    if (hero == null)
    {
        heroes.Add(new Superhero(name,power,underwearOnTheOutside));
        return name+" has been added to the list";
    }
    else return "That heroes is already in the list";
});

app.MapGet("/list/", () =>
{
    return heroes;
});

app.MapPost("/add/", (Superhero h) => 
{
    heroes.Add(h);
    Console.WriteLine($"Added hero {h.Name} to the list");
});

app.MapDelete("/hero/{num}", (int num) =>
{
    if (num >= 0 && num < heroes.Count)
    {
        heroes.Remove(heroes[num]);
    }
});

app.Run();
