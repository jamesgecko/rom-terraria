# RomTerraria

## Disclaimer

I am not the author of RomTerraria. This is merely a mirror. It is officially unsupported because [Michael Russell has end-of-lifed it](http://romsteady.blogspot.com/2012/11/romterraria-end-of-support.html). You can read more over on [Michael's blog](http://romsteady.blogspot.com/search/label/RomTerraria). This being said, you should feel free to fork and update it. :-)

## FAQ

**What is RomTerraria?**

RomTerraria is a launcher for [Terraria](http://www.terraria.org/), an indie game being distributed via Steam.

**How does RomTerraria work?**

RomTerraria takes advantage of a feature of the .NET Framework where every .NET executable is also a class. When RomTerraria is launched, it instantiates a copy of the game class inside Terraria.exe, modifies some internal variables inside the class using either direct access or reflection, and then fires the appropriate methods once you hit the launch button. It also uses the [GameComponent](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.gamecomponent.aspx) architecture inside of XNA games to hook into the Update events, but because of where [base.Draw(GameTime)](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.game.draw.aspx) is called inside Terraria, an alternate solution had to be used for where I'm doing rendering.

**Why does RomTerraria have to be in the same folder as Terraria.exe?**

The way I'm currently binding to Terraria.exe demands it. For awhile, I was working on separating the two, but given recent interactions with the community, I'm binding it tighter to the original game executable and to Steam. 

**Why did you release the source code?**

I wanted to show that you could modify the game without cracking the executable, decompiling it, modifying the disassembled code, then illegally distributing their code. (Note: The source is occasionally one or two minor bug-fix updates behind.)

**Why do fewer enemies spawn during gameplay when I'm using widescreen resolutions?**

Terraria uses the screen dimensions to determine where to spawn enemies. For stock spawn rates, launch a local multiplayer server, then connect to that server.

**When will the new HUD be complete?**

No current estimate. The air conditioning in my apartment went out, and even with a 20" box fan blasting my box, it still gets too hot if I use it for long periods of time. Replacement parts have been ordered, but are backordered. My A/C should be fixed by June 4.

**What does "Enable Pony" do?**

I've been asked this from nineteen separate countries. First, read this thread over at [Shacknews](http://www.shacknews.com/chatty?id=25946001#itemanchor_25946001). Second, realize that had been a horrible day. Third, epic troll is epic.

**I'm using a pirated version of Terraria, and your launcher won't work.**

Boo hoo. Buy the game. Even if I was to grant the asinine assertion that piracy for evaluation purposes was acceptable (which I'm not), the moment you start looking for enhancements, evaluation time is over. 

**The launcher is crashing. What should I do?**

First, make sure that you have the latest version of the launcher. Second, make sure all the files are in the same folder as Terraria.exe. Third, make sure Steam is running. If all of those conditions are met, the launcher should pop up a stack trace on the screen. Hit Control-C, reply to this post, and then hit Control-V to paste the stack trace into the comment.

**I turned on Infinite Goblin Invasion. After turning it off, they're still coming. What should I do?**

The Infinite Goblin Invasion option keeps firing the trigger to bring on new invasions. Each invasion contains at least 100 goblins. Unfortunately, that means you'll have to kill to the end of the current invasion. Good luck.
