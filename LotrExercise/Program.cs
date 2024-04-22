// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
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
            .Contains("white")
        );

// foreach (Character character in res1)
// {
//     Console.WriteLine(character.name + ": " + character.hair);
// }

// [✅] 2) Find all characters that are not dead

IEnumerable<Character> res2 =
    lotr.Characters
        .Where(c => 
            c.death == "" || 
            c.death.ToLower().Contains("immortal")
            );
    
        // union with characters that are immortal
        // .Union(
        //     lotr.Characters
        //         .Where(c => c.death.ToLower().Contains("immortal"))
        //     );

// foreach (Character character in res2)
// {
//     Console.WriteLine(character.name + ": " + character.death);
// }

// [✅] 3) Find all the hobbits

        IEnumerable<Character> res3 =
            lotr.Characters
                .Where(x => x.race == "Hobbit");

// foreach (Character character in res3)
// {
//     Console.WriteLine(character.name + ": " + character.race);
// }

// [✅] 4) Find all the 'four main' hobbits 

IEnumerable<Character> res4 =
    lotr.Characters
        .Where(c => 
            c.name == "Frodo Baggins" || 
            c.name == "Peregrin Took" ||
            c.name == "Samwise Gamgee" ||
            c.name == "Meriadoc Brandybuck"
            );

// foreach (Character character in res4)
// {
//     Console.WriteLine(character.name);
// }
// [✅] 5) List all the realms (that are not "" <- empty string)

IEnumerable<String> res5 =
    lotr.Characters
        .Where(r => r.realm != "NaN" && r.realm != "")
        .Select(c => new String(c.realm))
        .Distinct();
        

// foreach (string s in res5)
// {
//     Console.WriteLine(s);
// }

// [✅] 6) Find all the married female characters

IEnumerable<Character> res6 =
    lotr.Characters // Separate Where for each statement
        .Where(c => c.gender == "Female")
        .Where(x => x.spouse != "")
        .Where(x => x.spouse != "None")
        .Where(x => x.spouse != "NaN");


// [✅] 7) Find all the female elves characters with golden hair
IEnumerable<Character> res7 =
    lotr.Characters // combines statements into single where
        .Where(c =>
            c.gender == "Female" &&
            c.race == "Elf" &&
            c.hair.ToLower().Contains("gold")
        );


// [✅] 8) Find all characters who's firstname ends with an 'o'

IEnumerable<Character> res8 =
    lotr.Characters
        .Where(c => c.name.Split(' ')[0].EndsWith("o"));

// [✅] 9) How many of (8) are not Hobbits...
int res9 =
    lotr.Characters
        .Where(c => c.race != "Hobbit")
        .Where(c => c.name.Split(' ')[0].EndsWith("o")).Count();

// [✅] 10) What is the most common firstname (Probably very difficult - maybe dont use LINQ)

String res10 =
    lotr.Characters
        .GroupBy(c => c.name.Split(" ")[0])
        .Select(g => new
        {
            Name = g.Key,
            Count = g.Count()
        })
        .OrderBy(r => r.Count)
        .Last().Name;

// [✅] 11) What is the most common lastname (Probably very difficult - maybe dont use LINQ)

String res11 =
    lotr.Characters
        .GroupBy(c => c.name.Split(" ").Last())
        .Select(g => new
        {
            LastName = g.Key,
            Count = g.Count()
        })
        .OrderBy(r => r.Count)
        .Last()
        .LastName;
            
// [✅] 12) Are there any blonde dwarves?

bool res12 =
    lotr.Characters
        .Where(c => c.race == "Dwarf")
        .Where(c => c.hair.ToLower().Contains("blonde"))
        .Count() > 0;

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

int i= 0;