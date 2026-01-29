using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Reflection;
using System.Threading.Tasks;


public  class Commands : BaseCommandModule
{
  //test command
[Command("Test")] 
public async Task MyFirstCommand(CommandContext ctx)
    {
        await ctx.Channel.SendMessageAsync($"Hello {ctx.User.Username}");
    }

   
   

  //sends today's date inside a embed  
   [Command("date")]
        public async Task Date(CommandContext ctx)
    {
        DateTime utc = DateTime.UtcNow;
     var message = new DiscordEmbedBuilder //to build an embed
     {
       Title= "Today's date",
       Description = $"{utc:yyyy-MM-dd} This command was executed by {ctx.User.Username}",
       Color = DiscordColor.HotPink
     };

     await ctx.Channel.SendMessageAsync(embed:message); //sends the message to the discord message channel

    }
    }
