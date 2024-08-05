# ElfshockRPG

ElfshockRPG is a console-based role-playing game where players choose a character to fight against monsters in a 10x10 grid. The player can select one of three races: Warrior, Mage, or Archer. Each character and monster has specific attributes such as Strength, Agility, Intelligence, and Range. The game includes screens for Main Menu, Character Selection, In-Game actions, and Exit.

## Features
* Character Selection: Choose between Warrior, Mage, and Archer.
* Character Buffing: Option to buff up character stats before starting the game.
* In-Game Movement: Move the character across a 10x10 grid using keyboard controls.
* Combat: Attack monsters that appear on the grid.
* Monster Behavior: Monsters move towards the player and attack when in range.
* Persistence: Save hero details in a database using Entity Framework Core.
* Unit Testing: Automated tests for critical game functionality.
* Continuous Integration: CI workflow to run tests automatically on each commit.

## Installation 
1. Clone the repository:
2. Restore dependencies:
3. Apply database migrations:
4. Run the application


## Game Setup

### Character Attributes
* Warrior:
  * Strength: 3
  * Agility: 3
  * Intelligence: 0
  * Range: 1
  * Symbol: @
* Mage:
  * Strength: 2
  * Agility: 1
  * Intelligence: 3
  * Range: 3
  * Symbol: *
* Archer:
  * Strength: 2
  * Agility: 4
  * Intelligence: 0
  * Range: 2
  * Symbol: #
### Monster Attributes
* Monster:
  * Strength: Random (1-3)
  * Agility: Random (1-3)
  * Intelligence: Random (1-3)
  * Range: 1
  * Symbol: ◙


## Screens
* Main Menu: Welcome screen prompting the user to start the game.
* Character Selection: Screen to choose a character and optionally buff stats.
* In-Game: Main game screen where the player moves and attacks monsters.
* Exit: Screen to exit the game.


## Controls
* W: Move up
* S: Move down
* D: Move right
* A: Move left
* E: Move diagonally up-right
* X: Move diagonally down-right
* Q: Move diagonally up-left
* Z: Move diagonally down-left
 
