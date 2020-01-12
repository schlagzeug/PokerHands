# PokerHands
Determines the winner of a round of poker

## Implementation notes
I chose this example because I don't play poker so I thought it might be a fun challenge.

The user should input the players names and their hands and then click the "Show Winner" button to find the winner.

## Room for improvement
- The app currently allows duplicate cards, which wouldn't be possible in a normal game, and using them may provide inaccurate results.
- The UI could be improved to visually show cards, or a way to select cards instead of using the text
- An option to load data from a file would help in setting up the input quicker

## Input notes
input for the cards should be in the following format:

<value><suit>

where value can be any of the following: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A, j, q, k, a

and suit can be any of the following: D, S, C, H, d, s, c, h

## LINQPad Script
There is a LINQPad version included as well, as this was my initial test bed and prototype. It can be run using LINQPad, available at https://www.linqpad.net/