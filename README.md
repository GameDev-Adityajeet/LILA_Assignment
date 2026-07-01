# Question 3 – Feature Proposal

# Adaptive Build Affinity System

## Feature Summary

The **Adaptive Build Affinity System** is a progression feature that allows the game's upgrade pool to gradually adapt based on the player's decisions during a run.

Instead of every level presenting completely random upgrade options, the system tracks the player's build preferences and dynamically adjusts future upgrade probabilities. This helps players naturally develop coherent builds while preserving the unpredictability that makes survivor-like games exciting.

The objective is **not to eliminate randomness**, but to make randomness **react to player choices**, creating a stronger sense of ownership, strategy, and replayability.

---

# Design Rationale

One of the most common frustrations in survivor-like games is failing to complete a desired build because the required upgrades never appear.

While randomness is essential for replayability, excessive RNG can make failure feel unfair rather than challenging.

The Adaptive Build Affinity System addresses this issue by allowing every upgrade choice to subtly influence future upgrade offerings.

Instead of relying entirely on luck, players gradually shape their own build through meaningful decisions. The game still offers random choices, but those choices become increasingly aligned with the player's preferred playstyle.

This creates a healthier balance between **player agency** and **randomness**.

---

# Design Goals

The feature is designed around four primary goals:

- Preserve replayability while reducing excessive RNG frustration.
- Reward players for committing to different build strategies.
- Encourage experimentation across multiple runs.
- Make every successful build feel intentional rather than accidental.

---

# Player Experience

## Early Game

Every run begins with a completely neutral upgrade pool.

### Example Upgrade Selection

- 🔥 Fire Orb
- ⚡ Lightning Bolt
- ❄ Ice Spear

The player selects **Fire Orb**.

Nothing changes visibly yet, but the system records the player's first build preference.

---

## Mid Game

As the player continues selecting Fire-related upgrades, the game's affinity system gradually begins favoring upgrades that naturally complement the current build.

Instead of offering completely unrelated upgrades, the player may now receive options such as:

- 🔥 Fire Explosion
- 🔥 Burn Aura
- ⚡ Lightning Chain

The player begins to recognize that their earlier decisions are influencing future opportunities.

---

## Late Game

By the end of the run, the player has developed a specialized Fire-focused build that feels intentionally crafted rather than randomly assembled.

Another player making different decisions may naturally evolve into a completely different build, creating unique experiences every run.

---

# System Overview

The feature works by maintaining an internal **Build Affinity** value for every upgrade category.

Example categories:

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

# Example Progression

### Player selects:

🔥 Fire Orb

Updated affinity:

| Category | Affinity |
|-----------|----------:|
| 🔥 Fire | +25 |
| ❄ Ice | 0 |
| ⚡ Lightning | 0 |
| ☠ Poison | 0 |
| ⚔ Physical | 0 |

The next upgrade selection becomes weighted toward Fire.

Instead of:

- Fire Explosion
- Ice Shield
- Lightning Chain

The player may now receive:

- 🔥 Fire Explosion
- 🔥 Burn Aura
- ⚡ Lightning Chain

Notice that one unexpected option remains available to encourage experimentation.

---

# Upgrade Generation Flow

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

This ensures the player always has meaningful decisions while maintaining uncertainty.

---

# Hybrid Build Support

The system also supports hybrid playstyles.

Instead of rewarding only specialization, combining different affinities can unlock unique upgrade paths.

### Examples

| Build Combination | Possible Evolutions |
|------------------|---------------------|
| 🔥 Fire + ⚡ Lightning | Thunder Flame, Plasma Burst |
| 🔥 Fire + ☠ Poison | Toxic Inferno, Acid Flames |
| ❄ Ice + ⚡ Lightning | Frozen Storm, Static Blizzard |
| ⚔ Physical + 🔥 Fire | Blazing Slash |

This encourages experimentation instead of forcing every player into a single optimized strategy.

---

# Build Affinity Indicator

During level-up, players receive lightweight feedback showing how their build is evolving.

```text
Current Build

🔥 Fire        ████████░░ 80%

⚡ Lightning   ██░░░░░░░░ 20%

❄ Ice         █░░░░░░░░░ 10%

☠ Poison      ░░░░░░░░░░ 0%
```

The indicator only appears during upgrade selection, keeping the main gameplay screen clean.

---

# Balancing Considerations

To preserve replayability and prevent repetitive runs, the system includes several balancing rules.

### 1. Wildcard Upgrade

Every upgrade selection always contains at least one unexpected option.

This keeps every run unpredictable and allows players to pivot into new strategies.

---

### 2. Diminishing Returns

Affinity bonuses become smaller as players continue specializing.

Example:

| Upgrade | Fire Affinity |
|----------|--------------:|
| First Fire Upgrade | +25 |
| Second Fire Upgrade | +18 |
| Third Fire Upgrade | +12 |
| Fourth Fire Upgrade | +8 |

This prevents one category from becoming overwhelmingly dominant.

---

### 3. Legendary Upgrades

Legendary upgrades are generated using a separate probability table.

This ensures that every run still contains exciting surprise moments regardless of the player's current build.

---

### 4. Flexible Build Paths

Players can intentionally pivot into another build at any point.

Changing direction is possible, but comes at the cost of delaying specialization, creating an interesting strategic trade-off.

---

# Benefits

## Higher Player Agency

Players feel responsible for creating their own builds rather than relying purely on luck.

---

## Reduced RNG Frustration

Important upgrades become more likely without ever becoming guaranteed.

---

## Increased Replayability

Different decisions naturally lead to different build evolutions across multiple runs.

---

## Better Strategic Depth

Players begin thinking about long-term build planning instead of making isolated upgrade decisions.

---

## Stronger Build Identity

Every completed run reflects the player's own choices, making successful builds feel personal and memorable.

---

# Wireframe 1 – Early Upgrade Selection

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

# Wireframe 2 – Mid-Run Upgrade Selection

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

# Wireframe 3 – Build Affinity Indicator

```text
Current Build

🔥 Fire        ████████░░ 80%

⚡ Lightning   ██░░░░░░░░ 20%

❄ Ice         █░░░░░░░░░ 10%

☠ Poison      ░░░░░░░░░░ 0%
```

---

# Why This Feature Fits Survivor-Like Games

Survivor-like games thrive on experimentation, progression, and replayability.

The Adaptive Build Affinity System strengthens these core pillars by making the upgrade system respond intelligently to player decisions instead of relying solely on randomness.

Rather than replacing RNG, it transforms it into a system that rewards planning while preserving uncertainty.

Players gain greater control over how their builds evolve, yet every run remains unique thanks to weighted randomness, wildcard upgrades, hybrid build possibilities, and strategic trade-offs.

The result is a progression system that feels fair, engaging, and highly replayable while remaining technically feasible to implement.
