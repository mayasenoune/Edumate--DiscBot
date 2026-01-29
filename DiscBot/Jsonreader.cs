
using Newtonsoft.Json;

namespace DiscBot
{

    internal class Jsonreader
    {
        public string token { get; set; } //stores the bot token
        public string prefix { get; set; } // stores the prefix

        public async Task readJson() { //read the Json file with the bot informations (token and prefix)
            using (StreamReader sr = new StreamReader("config.json"))
            {
                string json = await sr.ReadToEndAsync();
                Jsonstructure data = JsonConvert.DeserializeObject<Jsonstructure>(json); //convert json into a #C object


             // values from json file are assigned to this class
                this.token = data.token; 
                this.prefix = data.prefix;

            }
        }
    }
    internal sealed class Jsonstructure { // structure of the json file
    public string token { get; set; }
        public string prefix { get; set; }

}
}