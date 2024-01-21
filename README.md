# ConsoleSnakeMark2

The main idea of this console snake game is to achieve a modular design based on behaviors. 

Game field consists of cells that implement the `ICell` interface.
Every `ICell` gets game behavior associated with the logic of that cell if snake head hits this cell. So to add a new game cell with specific logic it is enough to implement a new `ICell` component.

Keyboard input is captured using the `Console.ReadKey` method and the `AutoResetEvent` class for read timeout.

Console menu for changing settings and starting/restarting the game is implemented via [ConsoleMenuAPI](https://github.com/melon-code/ConsoleMenuAPI). The menu localization is done using XML file.

## Cell
Realized cells and corresponding behaviors:

`EmptyCell` 
- Behavior: `ContinueBehavior`
- Empty field cell.

`BorderCell` 
- Behavior: `EndGameBehavior`
- Border of the field.

`PortalBorderCell` 
- Behavior: `PortalBorderBahavior`
- Border that teleports snake head to the other side of the field.

`FoodCell`, `SmallFoodCell`, `BigFoodCell` 
- Behavior: `EatFoodBehavior`
- Represents food with different value.

`SnakeHeadCell`, `SnakeBodyCell`
- Behavior: EndGameBehavior
- Represents defferent parts of the snake.

`SnakeMovingTailCell`
- Behavior: `ContinueBehavior`
- Snake tail that will move on this turn. So if snake head takes this cell there won't be a collision.

`SnakeStaticTailCell` 
- Behavior: `EndGameBehavior`
- Snake tail that will not move on this turn because the snake still have eaten food. So if snake head takes this cell it will be game over.

## Behavior
Every behavior have to implement the `ICollisionBehavior` interface and have to be created with `ICollisionBehaviorParameters` to take the `GameLogic` instance.

Behaviors' description:
- `ContinueBehavior` - snake moves in the currently set direction
- `EatFoodBehavior` - snake eats food of the specified value and moves in the currently set direction
- `EndGameBehavior` - stops the game
- `PortalBorderBehavior` - teleports snake head to the specified location

## Game logic
Win game state is defined by the `GameLogic` class if snake's length is equal to game field capacity.

The `GameLogic` class represents and provides base operations, that can be executed during every game turn by `ICollisionBehavior` and `IGameLogicUser`.

To make game logic even more modular the `IGameLogicUser` interface was created. It represents any additional operations and game logic that can be performed during every game turn.
So to add a new functionality or game modifier it is enough to implement a new `IGameLogicUser` class.

Standard classes that implements this interface:
- `BaseSnakeTurn` - realizes snake movement
- `BigFoodSpawner` - realizes spawning of `BigFoodCell`

Every game turn execution is managed by the `GameIterator` class. It executes every item provided with the `IList<IGameLogicUser>` parameter.

## Custom game field
Custom game field can be created by implementing the `ICustomGameGridData` interface. 

The game has `CustomGameGridTypeA` and `CustomGameGridTypeB` implementations that stores field data directly inside.

Also the game supports reading field data from a `.txt` file using the `CustomGameGridDataFromFile` class.
### The file rules:
- The first string is speed value.
- Starting from the second string located field data.
- `'B'` is border
- `'P'` is portal border
- Can specify initial snake head position and direction by putting direction symbol in that location. If not default values is set.
- `'U'` - up direction
- `'D'` - down direction
- `'L'` - left direction
- `'R'` - right direction
- `'o'` - specifys the location of `SmallFoodCell`
