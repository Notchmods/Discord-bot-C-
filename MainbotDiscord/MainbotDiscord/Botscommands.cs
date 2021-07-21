using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using System.Globalization;

namespace MainbotDiscord
{
    public class Botscommands : ModuleBase<SocketCommandContext>
    {
        public DateTime thedate = DateTime.Now;
        string[] Colors = new string[] { "Red", "Blue", "Green", "Orange", "Purple", "Yellow", "Lime", "Aqua", "Turquoise", "pink", "Black", "Brown" };
        public bool KSIrapefaceunlock;
        [Command("Hello")]
        public async Task Hello()
        {
            await ReplyAsync("Hello how are you?");
        }
        [Command("Hi")]
        public async Task Hi()
        {
            await ReplyAsync("Hello how are you?");
        }
        [Command("Fuck you")]
        public async Task Fuckyou()
        {
            await ReplyAsync("Haha you think I was gonna respond the same commands back to you but Fuck you too", isTTS: true);
        }
        [Command("How are you")]
        public async Task Howareyou()
        {
            await ReplyAsync("I am fine thank you now what do you need from me?");
        }

        [Command("Show me KSI Rapeface")]
        public async Task KSIRapeface()
        {
            await ReplyAsync("Here you go:https://i.redd.it/zuqwgy86xsa41.jpg");
        }
        [Command("Generate Random numbers for me")]
        public async Task Generatenumber()
        {
            Random Randnumbers = new Random();
            await ReplyAsync(Randnumbers.Next(-1000, 1000).ToString());
        }
        [Command("Generate Random colors for me")]
        public async Task GenerateColors()
        {
            Random Randomnums = new Random();
            await ReplyAsync("Here is the color " + Colors[Randomnums.Next(0, 13)].ToString(), isTTS: true);
        }
        [Command("What's the time and date")]
        public async Task Time()
        {
            await ReplyAsync(thedate.ToString(),isTTS: true);
        }
        [Command("Help")]
        public async Task Help()
        {
            await ReplyAsync("Here are the commands to use: What's the time and date,How long do you operate for,Generate Random colors for me,Generate Random numbers for me,How are you,Hello,Show me KSI Rapeface. I know these commands are limited and Notchmods is adding them");
        }
        [Command("You're a penis")]
        public async Task Youareapenis()
        {
            await ReplyAsync("No you have a little penis");
        }
        [Command("You are a penis")]
        public async Task YouRpenis()
        {
            await ReplyAsync("No you have a little penis", isTTS: true);
        }
        [Command("How long do you operate for")]
        public async Task Oper8()
        {
            await ReplyAsync("I operate when I want cupcakes", isTTS: true);
        }

        [Command("Spr")]
        public async Task Sprache()
        {
            Console.WriteLine("Type in your commands and I'll speak em");
            var Keys = Console.ReadLine();
            await ReplyAsync(Keys);
        }
    }
}
