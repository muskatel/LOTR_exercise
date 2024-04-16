// See https://aka.ms/new-console-template for more information

using LotrExercise;
using Newtonsoft.Json;

Console.WriteLine("Hello, Middle-Earth!\n");

LotR lotr = new LotR();
// foreach (Character character in lotr.Characters)
// {
//     Console.WriteLine(character.name);
// }

// Using LINQ or lambda statements find the following:
// ✅/❌
// [✅] 1) Find all characters with 'white' hair

IEnumerable<Character> res1 =
    lotr.Characters.Where(
        c => c.hair
            .ToLower()
            .Contains("white"));

// [✅] 2) Find all characters that are not dead

IEnumerable<Character> res2 =
    lotr.Characters
        .Where(c => c.death == "")
        // union with characters that are immortal
        .Union(
            lotr.Characters
                .Where(c => c.death.ToLower().Contains("immortal"))
            );

// [❌] 3) Find all the hobbits
// [❌] 4) Find all the 'four main' hobbits 
// [❌] 5) List all the realms (that are not "" <- empty string)
// [❌] 6) Find all the married female characters
// [❌] 7) Find all the female elves characters with golden hair
// [❌] 8) Final all characters who's firstname ends with an 'o'
// [❌] 9) How many of (8) are not Hobbits...
// [❌] 10) What is the most common first (Probably very difficult - maybe dont use LINQ)

IEnumerable<String> distinctNames =
    lotr.Characters
        .Select(c => c.name.Split(' ').First())
        //.Distinct()
        .OrderBy(c => c);

// [❌] 11) What is the most common lastname (Probably very difficult - maybe dont use LINQ)
// [❌] 12) Are there any blonde dwarves?

// Bonus Question: Remove characters who's name starts with "user:" from the data (and SAVE IT)
// IEnumerable<Character> charactersToKeep=
//     lotr.Characters
//         .Where(c => !c.name.ToLower().StartsWith("user:"))
//         .Where(c => c.name != "MINOR_CHARACTER");
//         
// foreach (Character character in charactersToKeep)
// {
//     Console.WriteLine(character.name);
// }
//
// string data = JsonConvert.SerializeObject(charactersToKeep,Formatting.Indented);
// StreamWriter sw = new StreamWriter("lotr.json");
// sw.Write(data);
// sw.Close();