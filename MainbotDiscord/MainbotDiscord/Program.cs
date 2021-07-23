using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace MainbotDiscord
{
    class Program
    {
        public Botscommands Commands;
        //Declare variables socket client
        private DiscordSocketClient Socketclients;
        //Declaring framework provider for building Discord Commands
        private CommandService CS;
        //Declaring mechanism for retrieving a service object
        private IServiceProvider ISP;
        //Run methods when the bot is online;
        static void Main(string[] args) => new Program().Runbotasync().GetAwaiter().GetResult();
        //When the bot is runned these functions are performed
        public async Task Runbotasync()
        {
            //Declare the variables above
            Socketclients = new DiscordSocketClient();
            CS = new CommandService();
            ISP = new ServiceCollection()
                // Make sure one instance of these commands are running
                .AddSingleton(Socketclients)
                .AddSingleton(CS)
                //Creates IServiceProvider from IServiceCollection
                .BuildServiceProvider();
            //Declaring the discord tokens into a string    
            Console.WriteLine("Enter your bot tokens");
            var Tokenstring1 = Console.ReadLine();
            string Tokens = Tokenstring1;
            Socketclients.Log += Socketclients_Log;
            await Registercommandsasync();
            await Socketclients.LoginAsync(Discord.TokenType.Bot, Tokens);
            //Start the socket clients of the bot
            await Socketclients.StartAsync();
            //Delay the task
            await Task.Delay(-1);
        }

        private Task Socketclients_Log(Discord.LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        //Register the commands once online.
        public async Task Registercommandsasync()
        {
            //If message received Discord websocket clients is gonna Handle the Commands
            Socketclients.MessageReceived += HandleCommandasync;
            await CS.AddModulesAsync(Assembly.GetEntryAssembly(),ISP);
        }
            
        private async Task HandleCommandasync(SocketMessage arg)
        {
            //Set SocketUserMessage as messagges
            var messagess = arg as SocketUserMessage;
            //Declare SocketCommandContext;
            var context = new SocketCommandContext(Socketclients,messagess);
            int argPos = 0;
            //If the author is bot then don't respond at all
            if(messagess.Author.IsBot == true)
            {
                return;
            }
            //If the users queries contain MB then the bot will respond to its questions
            if (messagess.HasStringPrefix("?", ref argPos))
            {
                var results = await CS.ExecuteAsync(context, argPos, ISP);
                if (!results.IsSuccess) 
                {
                    Console.WriteLine(results.ErrorReason);
                }
            }
            if(messagess.Content == "K")
            {
                while (true)
                {
                    Console.WriteLine("Type in your commands and I'll speak em");
                    var Keys = Console.ReadLine();
                    if (Keys == "Users")
                    {
                        
                    }else
                    {
                        await messagess.Channel.SendMessageAsync(Keys);
                    }
                }
            }   
        }
    }
}
