
---

# Prototype

🎮 **Play the Prototype**  
https://gamedev-adityajeet.itch.io/delivery-rush

💻 **GitHub Repository**  
https://github.com/GameDev-Adityajeet/LILA_Assignment

---

# Question 1 – Delivery Dash: Playable Prototype Writeup

## The Pitch

Delivery Dash is a small arcade delivery game — drive around a tiny town, grab packages, drop them off before the clock runs out. Every delivery gives you a bit of money and a bit more time, so the whole run is really one long negotiation with a timer that's never quite on your side. There's no story, no ending, just a score you're trying to beat next time.

It's built for people who want a quick hit, not a commitment. Something you open for four minutes while waiting for something else — closer to Crazy Taxi or Paperboy than a driving sim. The appeal is simple: you always know exactly what to do, you're just not sure you can pull it off in time.

---

## Core Loop and First Session

In the first couple of minutes you spawn in, see an arrow pointing at your first pickup, drive over, hit **E**, then drive to the delivery point and hit **E** again.

That's the whole loop, repeated.

What makes it land is the feedback on each delivery — a burst of particles, a bit of camera shake, a sound, a money popup, and a time popup. None of it is complicated on its own, but together it turns a three-second interaction into a small win instead of just a number changing.

What actually brings someone back isn't a feature, it's the score. The game over screen either tells you **"New Best"** or exactly how much money short you fell. That comparison does most of the retention work — it's a clear target with a memory of what you did last time, which matters more than adding new content would at this stage.

---

## Progression and Metagame

The hook I built is that high score system, plus a small shop — **Speed**, **Dash**, and an **Extra Time** upgrade, all bought with the same money you're racing to earn.

The shop adds a real decision mid-run:

> Do I bank this delivery's money, or spend it now and risk running dry before the next payout?

It's small, but it's the start of an actual metagame instead of just a leaderboard.

If I wanted this to hold someone's attention for months, the current build isn't enough on its own, and it's not supposed to be yet.

What I'd add next:

- A separate currency that persists between runs.
- Cosmetics and permanent unlocks.
- Daily modifiers (fog, rush hour, double pickups).
- Online leaderboard.

---

## Monetization

I'd monetize this through cosmetics and convenience, not power.

Examples include:

- Vehicle skins
- Trail effects
- Cosmetic progression pass

The only gameplay-related monetization I'd consider is an optional rewarded advertisement:

> Watch one ad to gain **15 extra seconds** after the timer reaches zero.

It would always be optional.

What I wouldn't do is sell gameplay upgrades like Speed or Dash for real money. The whole point of the score is that it reflects player skill and decision-making. Selling power would undermine the competitive integrity of the game.

---

## AI Usage

I treated AI as a development partner rather than a shortcut.

Throughout development I used Claude to:

- Brainstorm mechanics
- Challenge design decisions
- Review gameplay systems
- Debug implementation issues

Instead of asking it to generate complete features, I used it much like another developer or designer—I'd describe a problem, discuss possible approaches, then choose, implement, and test the solution myself.

That workflow allowed me to iterate much faster while still making every design decision through playtesting rather than blindly accepting AI suggestions.

I deliberately kept AI out of the gameplay for this prototype.

The goal of this assignment was to answer one question first:

> Is the core delivery loop actually fun?

If the foundation isn't engaging, adding AI doesn't solve the real problem.

If expanded into a full game, I'd explore AI-driven dispatch systems that learn from player performance and dynamically adjust delivery jobs, deadlines, and route difficulty.

I'd also experiment with AI-generated daily delivery scenarios that remix weather, traffic, delivery priorities, and map events while preserving the core gameplay loop.

For me, AI works best when it helps create more personalized player experiences rather than replacing designers.

---

## Reference Games

The biggest inspirations were:

- **Crazy Taxi**
- **Paperboy**

From Crazy Taxi I borrowed:

- Clear destinations
- Visible countdown timer
- Rewarding players with additional time

From Paperboy I borrowed:

- Delivery-focused gameplay
- Navigation under time pressure

Unlike those games, I intentionally removed most environmental chaos such as traffic and collisions.

Instead, the tension comes almost entirely from:

- Route optimization
- Time management
- Efficient decision-making

One major change during development was switching from a top-down vehicle controller to a third-person, camera-relative controller after playtesting showed that the original controls were unnecessarily confusing.

---

# Question 2 – Gameplay Insights & Strategy

The genre I'd pick isn't one that's failed to find a hit — it's one that already has, several times over, and hasn't moved an inch since.

Base-building attack strategy:

- Clash of Clans
- Boom Beach
- Rise of Kingdoms
- State of Survival

These games print money.

Clash of Clans alone has remained one of the highest-grossing mobile games for over a decade.

Revenue, however, doesn't mean the genre has stopped evolving.

---

## Why It's Stuck

Most games in this genre still revolve around the same formula:

- Build structures
- Wait for timers
- Attack offline bases
- Collect resources
- Repeat

The multiplayer is often only an illusion.

You're solving a puzzle that happens to use another player's base rather than competing against someone actively reacting to your decisions.

Similarly, base layouts often matter less than raw troop or building levels.

The strategic depth appears large on the surface, but once players understand the systems, most encounters become heavily influenced by numerical progression rather than intelligent base design.

---

## What It Would Take

I believe the genre could evolve by making multiplayer genuinely competitive.

Some ideas include:

- Real-time attacks
- Skill-based matchmaking
- Replay systems
- Ranked progression
- Greater emphasis on layout strategy

I also believe monetization should move away from selling time.

Rather than encouraging players to pay to skip waiting, monetization could focus on:

- Cosmetics
- Seasonal progression
- Player expression

This preserves the addictive strategy loop while rewarding player skill instead of patience.

The formula continues to generate significant revenue, but I believe there is still room to redefine the genre by focusing more heavily on competition, strategy, and player expression.

---

# Question 3 – Feature Proposal

# Adaptive Build Affinity System

## Feature Summary

The **Adaptive Build Affinity System** is a progression feature that allows the game's upgrade pool to gradually adapt based on the player's decisions during a run.

Instead of every level presenting completely random upgrade options, the system tracks the player's build preferences and dynamically adjusts future upgrade probabilities. This helps players naturally develop coherent builds while preserving the unpredictability that makes survivor-like games exciting.

The objective is **not to eliminate randomness**, but to make randomness **react to player choices**, creating a stronger sense of ownership, strategy, and replayability.

---

## Design Rationale

One of the most common frustrations in survivor-like games is failing to complete a desired build because the required upgrades never appear.

While randomness is essential for replayability, excessive RNG can make failure feel unfair rather than challenging.

The Adaptive Build Affinity System addresses this issue by allowing every upgrade choice to subtly influence future upgrade offerings.

Instead of relying entirely on luck, players gradually shape their own build through meaningful decisions. The game still offers random choices, but those choices become increasingly aligned with the player's preferred playstyle.

This creates a healthier balance between **player agency** and **randomness**.

---

## Design Goals

- Preserve replayability while reducing excessive RNG frustration.
- Reward players for committing to different build strategies.
- Encourage experimentation across multiple runs.
- Make every successful build feel intentional rather than accidental.

---

## Player Experience

### Early Game

Every run begins with a completely neutral upgrade pool.

Example:

- 🔥 Fire Orb
- ⚡ Lightning Bolt
- ❄ Ice Spear

The player selects **Fire Orb**.

Nothing changes visibly yet, but the system records the player's first build preference.

---

### Mid Game

As the player continues selecting Fire-related upgrades, the game's affinity system gradually begins favoring upgrades that naturally complement the current build.

Example:

- 🔥 Fire Explosion
- 🔥 Burn Aura
- ⚡ Lightning Chain

---

### Late Game

By the end of the run, the player has developed a specialized Fire-focused build that feels intentionally crafted rather than randomly assembled.

Another player making different decisions may naturally evolve into a completely different build, creating unique experiences every run.

---

## System Overview

| Category | Initial Affinity |
|-----------|-----------------:|
| 🔥 Fire | 0 |
| ❄ Ice | 0 |
| ⚡ Lightning | 0 |
| ☠ Poison | 0 |
| ⚔ Physical | 0 |

Every upgrade selected increases the affinity of its category.

These affinity values are then used as weights when generating future upgrade options.

---

## Upgrade Generation Flow

```text
Player Chooses Upgrade
        │
        ▼
Increase Build Affinity
        │
        ▼
Recalculate Upgrade Weights
        │
        ▼
Generate Upgrade Pool
        │
        ▼
Offer Player

• 2 Affinity-Based Choices
• 1 Wildcard Choice
```

---

## Hybrid Build Support

| Build Combination | Possible Evolutions |
|------------------|---------------------|
| 🔥 Fire + ⚡ Lightning | Thunder Flame, Plasma Burst |
| 🔥 Fire + ☠ Poison | Toxic Inferno, Acid Flames |
| ❄ Ice + ⚡ Lightning | Frozen Storm, Static Blizzard |
| ⚔ Physical + 🔥 Fire | Blazing Slash |

---

## Build Affinity Indicator

```text
Current Build

🔥 Fire        ████████░░ 80%

⚡ Lightning   ██░░░░░░░░ 20%

❄ Ice         █░░░░░░░░░ 10%

☠ Poison      ░░░░░░░░░░ 0%
```

---

## Balancing Considerations

- Every upgrade selection always contains at least one wildcard option.
- Affinity gains use diminishing returns to prevent over-specialization.
- Legendary upgrades are generated from a separate probability table.
- Players can pivot into different builds by sacrificing specialization.

---

## Benefits

- Higher player agency.
- Reduced RNG frustration.
- Increased replayability.
- Better long-term strategic planning.
- Stronger player-created build identity.

---

## Wireframe 1 – Early Upgrade Selection

```text
+--------------------------------------+
|          LEVEL UP!                   |
|                                      |
| Choose One Upgrade                   |
|                                      |
| 🔥 Fire Orb                          |
| ⚡ Lightning Bolt                    |
| ❄ Ice Spear                         |
|                                      |
+--------------------------------------+
```

---

## Wireframe 2 – Mid-Run Upgrade Selection

```text
+--------------------------------------+
|          LEVEL UP!                   |
|                                      |
| Choose One Upgrade                   |
|                                      |
| 🔥 Burn Aura                         |
| 🔥 Fire Explosion                    |
| ⚡ Shock Pulse                       |
|                                      |
| Your Fire build is evolving.         |
+--------------------------------------+
```

---

## Wireframe 3 – Build Affinity Indicator

```text
Current Build

🔥 Fire        ████████░░ 80%

⚡ Lightning   ██░░░░░░░░ 20%

❄ Ice         █░░░░░░░░░ 10%

☠ Poison      ░░░░░░░░░░ 0%
```

---

## Why This Feature Fits Survivor-Like Games

Survivor-like games thrive on experimentation, progression, and replayability.

The Adaptive Build Affinity System strengthens these core pillars by making the upgrade system respond intelligently to player decisions instead of relying solely on randomness.

Rather than replacing RNG, it transforms it into a system that rewards planning while preserving uncertainty.

Players gain greater control over how their builds evolve, yet every run remains unique thanks to weighted randomness, wildcard upgrades, hybrid build possibilities, and strategic trade-offs.

The result is a progression system that feels fair, engaging, and highly replayable while remaining technically feasible to implement.

---

# Thank You

Thank you for taking the time to review my submission. I appreciate the opportunity to participate in this assignment and hope you enjoy exploring both the playable prototype and my design responses.
