using Newtonsoft.Json;

namespace LotrExercise;

public class LotR
{
    public IEnumerable<Character> Characters;
    
    public LotR()
    {
        String file = "LotR.json";
        StreamReader sr = new StreamReader(file);
        
        // load characters from json file
        Characters = JsonConvert
            .DeserializeObject<IEnumerable<Character>>(sr.ReadToEnd());
    }
}