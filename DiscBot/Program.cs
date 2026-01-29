using System.ComponentModel.Design;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DiscBot;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;



namespace DISCBOT
{
    internal class MyBot
    {
        //handles connection to discord
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }

        static async Task Main(string[] args) // json to keep informations externally ?
        {
            var jsonReader = new Jsonreader();
            await jsonReader.readJson();

            

        
            // How the bot connects on discord
            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All, //Subscribe to discord events
                Token = jsonReader.token, //Takes the bot token from the json file
                TokenType = TokenType.Bot,  
                AutoReconnect = true // Reconnect if connection drops

            };
// creating a DiscordClient object
            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;
//configuring commandsNext
             var commandsConfig = new CommandsNextConfiguration()
            {
            StringPrefixes = new string [] {jsonReader.prefix},
             EnableMentionPrefix = true,
             EnableDms = true, // allow commands in dm
             EnableDefaultHelp = false //disable default help commands 
            };

            Commands = Client.UseCommandsNext(commandsConfig);
          // Register commands from Commands class
            Commands.RegisterCommands<Commands>();

            await Client.ConnectAsync(); //connects the bot to discord
            await Task.Delay(-1); //
        }

        //Method that runs when bot is ready to use
        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}