//ei saanud tööle päris nii nagu tahtsin

string folderPath = @"C:\Users\annle\Desktop\data\";
string heroFile = "Heroes.txt";
string villainFile = "Villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "a sword", "a polearm", "a catalyst", "a claymore", "a bow" };


string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = CharacterHP(villain);
Console.WriteLine($"Today {villain} ({villainHP}) with {villainWeapon} wants to take over the world,");

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = CharacterHP(hero);
int heroStrikeStrenght = heroHP;
int villainStrikeStrenght = villainHP;
Console.WriteLine($"Will {hero} ({heroHP}) with {heroWeapon} save the day?");


while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrenght);
    Console.WriteLine($"{hero} remaining HP:{heroHP}");
    villainHP = villainHP - Hit(hero, heroStrikeStrenght);
    Console.WriteLine($"{villain} remaining HP:{villainHP}");

}

Console.WriteLine($"{hero} remaining HP:{heroHP}");
Console.WriteLine($"{villain} remaining HP:{villainHP}");

if(heroHP > 0)
{
    Console.WriteLine($"{hero} has saved the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"{villain} has taken over the world!");
}
else
{
    Console.WriteLine("It's a draw!");
}
static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random(); 
    int randomIndex = rnd.Next(0, someArray.Length );
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int CharacterHP(string characterName)
{
    if (characterName.Length < 5)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target! Remaining HP {characterHP}");
    }
    else if (strike == characterHP - 3)
    {
        Console.WriteLine($"{characterName} launched a critical hit");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} took a light hit, remaining HP {characterHP}");
    }
    else if (characterHP < strike)
    {
        Console.WriteLine($"{characterName} has fallen");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }
    return strike;

}


