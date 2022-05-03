﻿# Slot Machine
Simplified slot machine game.

## The rules​:
- At the start of the game the player should enter the deposit amount (e.g. the initial
money balance).
- After that, for each spin, the player is asked how much money he wants to stake.
- A table with the results of each spin is displayed to the player.
- The win amount should be displayed together with the total balance at the current stage.
After the first spin the total balance will be equal to:
({deposit amount} - {stake amount}) + {win amount}).
- Game ends when the player balance hits 0.

## The game:
- A slot game with dimensions 4 rows of 3 symbols each.
- Supports following symbols:
                Symbol Coefficient Probability to appear on a cell
     Apple        (A​)      0.4         45%
     Banana       (B​)      0.6         35%
     Pineapple    (P​)      0.8         15%
     Wildcard     (*​)      0           5%

- The symbols are placed randomly respecting the probability of each item. For example:
there is 5% chance that a Wildcard will be placed in a cell and there is 45% chance for
an Apple.
- The player will win only if one or more horizontal lines contain 3 matching symbols.
Wildcard (*) is a symbol that matches any other symbol (A​, B​ or P​).
- The won amount should be the sum of the coefficients of the symbols on the winning
line(s), multiplied by the stake amount.