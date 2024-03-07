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
- Some basic BaseStates(Idle, Patrol, Chase, Attack, Flee)
- new input system
- ui
- 
