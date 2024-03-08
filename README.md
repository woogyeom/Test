# Rouge-like
A 2D Rouge-like.  

Trying to make it as Object Oriented as possible.  

Dungeon is made of Rooms and Rooms are made of Tiles.  
Player and Enemies inherit Units.  
StatusEffect consists Blind/Hobble.

Move consists Attack/Defend.  

Damage = attacker.attack - target.defense  
Hitrate = attacker.accuracy - target.avoidance  

GameManager manages turns.  
TileManager provides the link between Tiles and Units.  
Using FSM named BaseState for Enemies.

To-do
- procedural dungeon generator
- some basic Moves(Base Attack, Special Attack, Defend, Move)
- some basic BaseStates(Idle, Patrol, Chase, Attack, Flee)
- animations
- new input system
- ui

Data Structure
- Unit: tile, sight, health, maxHealth, attack, defense, accuracy, avoidance, critChance, statusEffects
    ㄴ Player: exp, maxExp, level
    ㄴ Enemy: rewardLevel, curState
- Dungeon: rooms, corridors
  - Area: tileDict
      ㄴ Room: 
      ㄴ Corridor: startRoom, endRoom
    -  Tile: position, isOccupied, area
