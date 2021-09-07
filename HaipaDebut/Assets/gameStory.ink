EXTERNAL state(int i)
EXTERNAL va(int i)
{state(0)}{va(0)}
Hey you also like that drink huh? Um I just wanted to tell you that you have a nice outfit!


* Oh, thank you, thats so nice.. You look really unique as well! I was just too embarassed to approach you.. #you
    {state(3)}
    Oh you're approaching me now??
    {va(1)}
    ** [...]
* Thanks I guess #you


-I see you're wearing an ahegao hoodie, I have one as well hehe. Do you watch anime?
    {state(2)}{va(2)}

* Yeah I do! What are your favorites? #you
* I do ocasionally, the hoodie is just for the meme. #you
 
-Oh Im really into JoJo especially Part 4, just waiting for Part 6 anime and then Ill read Part 7
{va(3)}
   * [...]
        I also really enjoyed for ex. Maid Dragon, Wotakoi, Death Note, SK8 etc
        As you can see I watch a lot of genres
        {va(4)}
-
* Oh I also like these! #you
    We have similar taste then! Do you play games by any chance?
    {va(5)}
* Pretty cool #you
    Yeah, do you play games by any chance?
    {va(6)}
* Trash taste! #you
    {state(1)}
    Oh well.. do you play games?
    {va(7)}
-
* Of course #you
    Cool, if you wanna play together; my favorites Id like to stream are:..
    {va(8)}
-
*Wait did you say "stream"?? #you
    {state(8)}
    Did I really spill that?
    {va(9)}
    ** [...]
        {state(1)}
        Um yeah.. Im actually a VTuber, I hope you're trustworthy..
        {va(10)}
-
*Damn thats so cool! So what games did you want to play?? #you
    {state(2)}
    ->games
*Bruh, thats kinda cringe.. #you
    {state(4)}
    Hey dont judge me! I think its a really cool way to express yourself, connect with other people and have fun!
        {va(11)}
    ** Yeah you're right.. So go on. #you
    {state(1)}
    ->games

==games==
Oh yeah, I play mainly Dead by Daylight, osu, Minecraft, Terraria, Factorio, Space Engineers, Path of Exile. But I'd also like to try Stardew Valley for ex. but I do not own the game yet
    {va(12)}
    * [...]
    
-Whats your music taste?
{va(13)}

*I am quite into JPop and JRock #you
    {state(2)}
    Same here!
    I mainly love TUYU, Eve, Polkadot Stingray
    {va(14)}
*Mostly just the viral stuff #you
    Oh Im more into JPop, JRock etc like TUYU, Eve, Polkadot Stingray. Ever heard of them?
    {va(15)}
*I listen to Disco Polo and Polish Rap :)) #you
    Man, dont even talk to me.
    {state(5)}{va(16)}
- 
* [...]

- I actually have to get ready for my debut, so I'll get going, you know where to find me, bye!
    {state(9)}{va(17)}
    -> END