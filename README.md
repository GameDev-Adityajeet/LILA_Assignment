🚚 Delivery Rush
> A fast-paced arcade delivery game built for the **Lila Games Game
> Designer Assignment**.
![Unity](https://img.shields.io/badge/Engine-Unity-000000?logo=unity)
![Platform](https://img.shields.io/badge/Platform-WebGL-blue)
![Genre](https://img.shields.io/badge/Genre-Arcade-success)
---
🎮 Play the Game
🌐 Play in Browser  
https://gamedev-adityajeet.itch.io/delivery-rush
---
📖 Overview
Delivery Rush is a fast-paced arcade delivery prototype where the
player races against the clock to pick up and deliver packages across a
small city.
Every successful delivery rewards the player with money and additional
time, creating a satisfying gameplay loop centered around efficiency,
quick decision-making, and high-score chasing.
The prototype intentionally uses simple placeholder assets to focus on
gameplay, progression, and player motivation.
---
✨ Features
📦 Package Pickup & Delivery
⏱️ Time-Based Gameplay
💰 Money & Upgrade System
🛒 Mid-Run Upgrade Shop
⚡ Dash Ability
🚀 Speed Upgrade
🏆 High Score System
🎮 Camera-Relative Controls
🌐 WebGL Browser Build
---
🎮 Controls
Action            Key
---
Move              WASD
Pick Up Package   E
Deliver Package   E
---
🛠️ Built With
Unity
C#
Visual Studio
Claude AI (Design Discussion & Development Assistance)
---
📑 Assignment Submission
Question #1: Delivery Dash --- Playable Prototype Writeup
Play in browser: [add itch.io link] Code: [add GitHub link]
Gameplay video: [add link]
---
The Pitch
Delivery Dash is a small arcade delivery game --- drive around a tiny
town, grab packages, drop them off before the clock runs out. Every
delivery gives you a bit of money and a bit more time, so the whole run
is really one long negotiation with a timer that's never quite on your
side. There's no story, no ending, just a score you're trying to beat
next time.
It's built for people who want a quick hit, not a commitment. Something
you open for four minutes while waiting for something else --- closer to
Crazy Taxi or Paperboy than a driving sim. The appeal is simple: you
always know exactly what to do, you're just not sure you can pull it off
in time.
Core Loop and First Session
In the first couple of minutes you spawn in, see an arrow pointing at
your first pickup, drive over, hit E, then drive to the delivery point
and hit E again. That's the whole loop, repeated. What makes it land is
the feedback on each delivery --- a burst of particles, a bit of camera
shake, a sound, a money popup, a time popup. None of it is complicated
on its own, but together it turns a three-second interaction into a
small win instead of just a number changing.
What actually brings someone back isn't a feature, it's the score. The
game over screen either tells you "new best" or exactly how much money
short you fell. That comparison does most of the retention work --- it's
a clear target with a memory of what you did last time, which matters
more than adding new content would at this stage.
Progression and Metagame
The hook I built is that high score system, plus a small shop --- Speed,
Dash, and an Extra Time upgrade, all bought with the same money you're
racing to earn. The shop adds a real decision mid-run: do I bank this
delivery's money, or spend it now and risk running dry before the next
payout. It's small, but it's the start of an actual metagame instead of
just a leaderboard.
If I wanted this to hold someone's attention for months, the current
build isn't enough on its own, and it's not supposed to be yet. What I'd
add next: a separate currency that persists between runs so cosmetics
and unlocks don't reset after a bad run, daily modifiers (fog, rush
hour, double pickups) to give people a reason to check back in, and a
leaderboard, which is close to free since the whole loop already
revolves around one comparable number.
Money
I'd monetize this through cosmetics and convenience, not power. Vehicle
skins, trail effects, maybe a simple pass-style track for unlocking them
over time. The one system I'd actually build for monetization is an
optional rewarded ad --- watch one, get 15 seconds back when the timer
hits zero. Always skippable, never forced.
What I wouldn't do is sell the Speed or Dash upgrades for real money,
even though it'd be the easiest thing to add. The whole point of the
score is that it reflects how you drove and what you chose to buy ---
selling that directly kind of ruins the reason the score means anything.
AI
I treated AI as a development partner rather than a shortcut. Throughout
the project I used Claude to brainstorm mechanics, challenge design
decisions, review gameplay systems, and help debug implementation
issues. Instead of asking it to generate complete features, I used it
much like I would work with another developer or designer---I'd describe
a problem, discuss possible approaches, then choose, implement, and test
the solution myself. That workflow let me iterate much faster while
still making every design decision based on playtesting rather than
accepting AI suggestions at face value.
I deliberately kept AI out of the gameplay for this prototype. The goal
of this assignment was to answer one question first: is the core
delivery loop actually fun? Before introducing AI-driven systems, I
wanted to validate that players enjoyed navigating the map, managing the
timer, and making upgrade decisions. If the foundation isn't engaging,
adding AI doesn't solve the real problem.
That said, I think AI could add meaningful value if this prototype
evolved into a full game. The area I'd explore first isn't generating
content---it's adapting the experience to individual players. Instead of
using fixed difficulty rules, an AI-driven dispatch system could learn
from how someone plays and adjust future delivery jobs accordingly. A
player who consistently finishes with plenty of time might start
receiving longer routes, tighter deadlines, or higher-value deliveries,
while someone struggling would receive shorter, safer routes that help
them improve without making the game feel unfair.
Another direction I'd explore is AI-generated daily delivery scenarios.
Rather than relying on a fixed pool of handcrafted missions, AI could
create combinations of weather, traffic conditions, delivery priorities,
and map events that encourage different strategies every day. That keeps
the experience feeling fresh while still working within the same core
mechanics.
For me, the most interesting use of AI in games isn't replacing
designers---it's creating systems that respond intelligently to each
player while preserving the designer's intended experience. I think AI
is at its best when it makes a game feel more personal, not more
complicated.
Reference Games
I pulled apart Crazy Taxi mostly for the feel of it --- clear
destinations, a big obvious timer, and that trick where the clock always
seems about to run out but keeps getting extended by your own good play.
Paperboy was the closer reference for the actual structure: delivery
under time pressure, and obstacles that slow you down through navigation
rather than combat. I also looked at how mobile games write their
upgrade shops --- short, blunt, numbers you can read in two seconds,
which is why my three upgrades are one line each instead of a stat tree.
What I did differently: most of those games lean on chaos --- traffic,
crashes, other cars --- for tension. I stripped almost all of that out
and let the tension come from route efficiency and the clock alone. I
also ended up changing the controls partway through. I started with a
top-down car controller like my original design doc called for, but
early testing showed the momentum-based steering was confusing more than
it was skill-expressive --- turning first, then having "forward" mean
something different depending on which way I was already facing, kept
catching me off guard mid-play. I switched to a third-person,
camera-relative scheme instead, where input maps directly to what you
see on screen. It's a bigger change from my own spec than I planned on,
but it came out of actually playing it and hitting a wall, not from
second-guessing the plan on paper.
---
Question #2: Gameplay Insights & Strategy
The genre I'd pick isn't one that's failed to find a hit --- it's one
that already has, several times over, and hasn't moved an inch since.
Base-building attack strategy: Clash of Clans, Boom Beach, Rise of
Kingdoms, State of Survival, the list goes on. These games print money.
Clash of Clans alone has been a top grosser for over a decade. By
revenue, this genre is "cracked" many times over. But revenue isn't the
same as solved, and I think this genre has been coasting on a formula
nobody wants to touch, because touching it is scary, not because there's
nothing left to improve.
Why It's Stuck
Once a studio finds a build-timer-plus-gem-skip loop that reliably
converts whales, there's almost no reason to change it. Every version of
this genre for the last decade has the same bones: build buildings,
wait, attack other bases, usually not in real time, usually against a
static replica while the actual player is offline, win resources,
repeat. The PvP is mostly theater. You're not fighting a person reacting
to you in the moment, you're solving a puzzle that happens to have
someone else's name attached to it, and once you're done, they get a
shield so you can't even be retaliated against properly. There's no real
tension because there's no real opponent in the room.
The base-building side has the same problem. On paper it should be a
spatial puzzle: where do I put my defenses, how do I funnel attackers,
what do I sacrifice for what. In practice, once you strip away the
skins, it mostly comes down to whoever has the higher numbers. Two bases
at the same level with different owners usually play out the same raid
regardless of layout skill, because raw troop and building levels do
more work than clever design ever will. The strategic layer is thinner
than it looks the first few times you play, and once you notice that,
every reskin of this genre starts to feel like the same game.
What It Would Take
Stop treating the multiplayer layer as decoration. Make attacks
real-time, or at minimum give players a genuine skill ladder with
matchmaking, replays, something worth bragging about, the way MOBAs and
battle royales built actual competitive identities around themselves.
Make base design something with a visible skill ceiling, where a smart
layout can meaningfully beat a bigger but sloppier one, instead of
numbers just winning by default. And take monetization off the timer.
Right now the business model in this genre is selling patience, pay to
skip the wait, which means the core loop and the monetization loop are
quietly working against each other: the game is more fun the less you
spend, and it makes more money the more bored you get. A version of this
genre that monetized cosmetics, seasonal content, and expression instead
of "wait less" could keep the addictive base-building loop everyone
already likes without punishing the players who are actually good at it.
Nobody's touched this formula because it works well enough as is, and
messing with something that reliably makes money is a genuinely hard
thing to greenlight. But "reliably profitable" and "actually good" have
quietly drifted apart in this genre, and whoever closes that gap first
has a real shot at redefining it instead of just cloning it again.
---
Question #3: Design Specification
Feature: Adaptive Mutation System
Feature Summary
The Adaptive Mutation System is a progression feature where every
upgrade the player chooses permanently influences the future upgrade
pool for the current run. Instead of every level presenting completely
random upgrades, the game gradually learns the player's build and
increases the chance of offering upgrades that naturally evolve it,
while still preserving meaningful randomness.
Why I Chose This Feature
One of the biggest frustrations in survivor-like games is losing because
the upgrades you wanted never appeared. Randomness creates
replayability, but excessive randomness makes failure feel unfair. This
system keeps the excitement of random upgrades while rewarding player
decisions and creating a stronger sense of ownership over every build.
Design Goals
Preserve replayability.
Reduce RNG frustration.
Reward strategic commitment.
Make every run feel unique.
Player Experience
Early Game
The player starts with a neutral upgrade pool.
Fire Orb
Ice Spear
Lightning Bolt
Choosing Fire Orb slightly increases the chance of Fire-related upgrades
appearing later.
Mid Game
Upgrade choices begin reflecting previous decisions.
Fire Explosion
Burn Aura
Shock Pulse
The player begins to feel that their build is evolving naturally.
Late Game
By the end of the run, each player's build is different because their
choices shaped future upgrade options.
Fully Detailed Section -- Upgrade Evolution System
Every upgrade category has a hidden affinity score.
Category    Affinity
---
Fire        0
Ice         0
Lightning   0
Poison      0
Physical    0
Choosing a Fire upgrade increases Fire affinity and slightly decreases
the probability of unrelated upgrades. Future upgrade screens are
weighted toward the player's preferred build but always include at least
one unexpected option to preserve variety.
This approach rewards planning without removing the excitement of
randomness.
Benefits
Higher player agency.
Reduced RNG frustration.
Better replayability.
Encourages experimentation.
Balancing
Affinity bonuses are capped.
Legendary upgrades ignore affinity.
One wildcard upgrade always appears.
Wireframe 1
``` text
LEVEL UP!

🔥 Fire Orb
❄ Ice Spear
⚡ Lightning Bolt
```
Wireframe 2
``` text
LEVEL UP!

🔥 Burn Aura
🔥 Fire Explosion
⚡ Shock Pulse
```
Wireframe 3
``` text
Current Build

Fire        ████████░░
Lightning   ██░░░░░░░░
Ice         █░░░░░░░░░
```
Why This Feature Fits
Instead of removing randomness, the Adaptive Mutation System makes
randomness respond to player decisions. Every run feels intentionally
shaped by the player's choices while still remaining unpredictable.
---
📂 Project Structure
``` text
Assets
├── Audio
├── Materials
├── Prefabs
├── Resources
├── Scenes
├── Scripts
│   ├── Managers
│   ├── Player
│   ├── Systems
│   └── UI
├── UI
└── Settings
```
---
🚀 Future Improvements
Dynamic traffic system
Smarter delivery generation
Daily challenges
Cosmetic vehicle unlocks
Leaderboards
AI-driven adaptive dispatch
Mobile optimization
---
👨‍💻 Author
Adityajeet Yadav
Game Developer • Game Designer
Portfolio: https://gamedev-adityajeet.github.io/Portfolio/
GitHub: https://github.com/GameDev-Adityajeet
LinkedIn: https://www.linkedin.com/in/adityajeet-yadav/
---
⭐ Thank you for taking the time to review my submission!
