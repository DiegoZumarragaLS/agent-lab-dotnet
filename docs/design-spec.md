# Card Deck Shuffle design spec

## Goal
Create a fast, tap-first social prompt flow: open the game, draw a card, reveal a question, and pass the deck to the next person.

## Direction
- Keep the existing Soc Ops palette, but make this mode feel more like a deck than a board.
- Use layered card surfaces, a single reveal interaction, and clear launch points.
- Prioritize entry points before extra chrome.

## Iteration 1
- Add Card Deck Shuffle to the start screen.
- Add a dedicated draw screen with a flip/reveal card.
- Keep the first pass simple: one question per draw, no extra rules.

## Decisions
- The mode uses the existing question bank.
- The card draw screen owns the shuffle/reveal interaction.
- The entry screen should make all modes obvious, not hide the new one.

## Iteration 1 shipped
- Start screen now surfaces Card Deck Shuffle alongside the existing modes.
- The deck screen uses one large flip/reveal card and simple next/shuffle actions.
- Mobile layout collapses to one column so the launch surface stays usable on phones.

## Iteration 2
- Simplified the reveal so the question is always legible after tap.
- Kept the card language, but dropped the fragile 3D dependency for clarity.

## Next ideas
- Optional swipe gestures.
- A stronger 3D flip treatment.
- Short celebratory motion when a new card appears.
