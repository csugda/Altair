# Project Altair
CSU Game Developers Association, Fall 2018

## Overview

### Theme/Setting/Genre

Project Altair is a Sci-fi tower defense game set on the outer hull of a starship being attacked by aliens. 



### Core Gameplay Mechanics (Brief)

* The Map is a grid-based map cut to the shape of the back of the ship.
* Enemies land on the map and follow the shortest path to a weak spot.
* Once a certain number of enemies get to weak spots the game is a loss.
* Once a certain number of enemies or waves of enemies has been defeated, the game is won.
* The player can order construction of towers on the map that both attack enemies and disrupt their pathing. 
* Towers take some time to build once placed.
* Until construction is complete players will not know what type of tower the tower will be. 
* Towers can be moved once built, taking some time to be moved.



### Project Scope

* #### Game/Time Scale

  * Small game to be completed by Winter Break 2018.

* #### Team

  * Project Lead: Miles Wood
  * Art Team
    * Team Lead: Desarae Cruz
    * Team Members
      * <Names>
  * Code Team
    * Team Lead: David Im
    * Team Members
      * <Names>
  * Engine Team
    * Team Lead: Jonathan Griego
    * Team Members
      * <Names>



### The elevator Pitch

Project Altair is space themed tower defense game, where the player is defending a starship from a swarm of aliens. Whenever a tower is built it will be a random one to represent the rushed way that it is being built, and the player will have to work with whatever towers they end up with to successfully defend their starship.



### Inspirations

* Tower Madness
  * IOS tower defense game
  * Inspiration for wave system and some tower types.





## Core Gameplay Mechanics (Detailed)

### General

* #### Game Map `High`

  * Details
    * The map is a grid placed on the back of the starship.
    * If the center of each tile is a node, enemies path from node to node, along the connecting edges. 
    * If a tower is placed on a tile that tile's node becomes impassable to enemies.
  * How it works
    * The pathing map can be a bi-directional graph consisting of all of the tiles that do not have a tower on them. 
    * Pathing can be achieved with a simple search algorithm. 
      * At the moment A* looks like the best solution. 
    * The map will be between 5 and 15 tiles wide, and between 10 and 20 tiles tall.

* #### The starship has several weak points `High`

  * Details
    * The ship has three weak spots, the engines, the airlock, and the command bridge.
    * These spots are all about the same distance from the spawn points for the enemies.
    * If enough enemies make it to the weak points the game ends with a loss. 
  * How it works
    * Three tiles are designated as weak spots and are the targets of the pathfinding. 
    * When enemies make it to these tiles they disappear.
    * When enemies reach these tiles some life counter is reduced, and the game ends if it hits zero.
    * `Idea` Each weak point tracks health separately, game ends if any one is destroyed.
      * This would allow for different enemy types that attack different targets. 

* #### Victory condition `Low`

  * Details
    * After a number of waves of enemies are defeated the player wins the game. 
      * If we have multiple stages/maps then the player progresses to the next map and wins once completing all of them.
  * How it works
    * There should be a list of waves, once all waves are completed the game is over and the player wins. 



### Enemies

* #### Enemies spawn and follow the shortest path to a weak spot. `High`

  * Details
    * There will be an area, either one or several tiles, at the top of the map where enemies will spawn.
    * Once spawned they will choose one of the week spots of the ship to target, and start to follow the shortest path to that tile. 
    * `Low` Show the path that enemies are going to follow to the player.
  * How it works
    *  When enemies spawn they either run a search to get a path, or get a pre-calculated path (I think that this will be the better option so that when several enemies spawn they don't all have to run the pathfinding algorithm to just get the same answer)
    *  Enemies move to each node along the edges, then to the next one until reaching their goal. 
    *  If a new tower is placed, all enemies will need to re-path if their original path is blocked. 
      * Possibly the best way will be to have them path using the goal as the heuristic goal for the pathfinding algorithm, but calling it good whenever they intersect the "permenant" path and just appending whatever is left of that path. This could improve pathfinding speed if that is necessary. 

* #### Enemies spawn in waves `Medium`

  * Details
    * A wave is a group of one or more enemies of the same type.
    * Waves spawn at regular increments.
    * The player can rush the next wave to have it land immediately, starting the timer for the wave after it. 
  * How it works
    * Pre-code a list of waves, consisting of a enemy type and number. 
    * Every X seconds check the next wave and spawn the given number of the given type of enemy.
    * If the player selects the rush button spawn the next wave immediately. 
      * Possibly wait until the previous wave has completed its spawn animation, but not for the whole wave timer that would normally be used. 

* #### There are multiple types of enemies `Low`

  - Details
    - Different types of enemies have different goals. 
      - One type for each of the three weak spots.
    - The different enemy types move at different speeds and have different mounts of health.
    - `Low` `Idea` The different enemy types could have weaknesses to different tower types, encouraging the player to place towers that do more damage to an enemy along the path that that enemy will take. 
  - How it works
    - On spawning, the enemy picks its target weak spot based on its type. 

* #### Enemies can be killed `High`

  * Details
    - Enemies have an amount of health, and once they take that much damage they are killed. 
    - Different types of enemies have different amounts of health. 
  * How it works
    - Each enemy tracks its own health. 
    - Enemies should have a method to reduce health.
    - If, after reduction, the enemies health is zero or less, the enemy stops moving, plays a death animation, and disappears. 



### Towers

- #### Tower behavior `High`

  - Details
    - Towers are build on nodes in the middle of tiles.
    - Each tower has a range around it that it can target in.
    - Towers built on the map target enemies and do damage to them. 
    - Towers take time to target enemies, they have to rotate to face them. 
    - A tower will target the enemy that is furthest along the path to the weak spots and continue firing at it until that enemy leaves its range or is destroyed. 
  - How it works
    - Towers will need to track enemies in range
      - Possibly by tracking which path nodes they can hit and then looking for enemies in range of those. 
      - Possibly by simply calculating range to each enemy, although this could be slow. 
      - Towers could have a collider around them that, when an enemy enters it adds that enemy to a list, and when the enemy leaves removes it. Then the first enemy on the list should always be the enemy that is furthest along the path. 

* #### There are multiple types of tower `Medium`

  * Details
    * Tower types:
      * Normal gun/laser tower `High`
        * Targets a single enemy and fires a ray at it that cannot miss.
        * Relatively low damage, high fire rate
      * Beam Cannon/Railgun `Medium`
        * Targets enemy in the same way, but fires a beam that hits every enemy that it touches, passing through them to either a maximum range or the edge of the map in whatever direction. 
        * Slow fire rate, medium damage to each enemy that it hits, but high overall because of many hits.
      * Mortar/Missile tower `Low`
        * Targets an enemy, then fires a projectile at where it is when fired. 
        * When the projectile lands it does damage to every enemy in an area around the impact. 
        * Fairly high damage, medium to low fire rate.



### Player Interaction

* #### The player can order towers to be built on the map `High`
  * Details
    * The player selects the build mode then a tile that they want the tower to be built on. 
    * If that tile would completely cut off the enemies path to one of the weak spots then the player is shown an error, and the tower construction is aborted. 
      * A story reason could be that if the enemy's path is completely blocked, they will start to burrow into the hull right away instead of trying to reach a weak point. 
    * Over the next few seconds the tower is constructed.
    * When construction is complete the tower becomes one of the available tower types at random.
  * How it works
    * When in build mode, when a tile is selected it is checked for being the last option in a path.
    * If that tile wouldn't cut off a path it is marked as being occupied.
    * Enemies will have to calculate a new path if that tile is in their path. 
    * The tower construction animation plays, for several seconds.
    * At some point in the construction the tower type is chosen at random
    * Once construction is complete the tower becomes active. 

- #### Towers are built and moved by work crews `Medium`

  - Details
    - The towers will cost something as a way to restrict the player from building towers for free and therefore having no tension to the gameplay.
    - Once tower construction is started a work crew is occupied until the tower becomes active. 
    - Constructing and moving towers requires work crews. 
      - Limits the construction of towers by having a crew held up until construction of the previous one is complete. 
  - How it works
    - When tower construction is stated a work crew is marked as busy. 
    - Once construction is finished the work crew is free.

- ####  Work crews `Medium`

  - Details
    - The player has a total of three "work crews".
    - To construct or move a tower the player assigns a work crew to that task.
    - Work crews can only have one task at a time.
    - When a task is completed the work crew is free to start another task
    - If a task is canceled the work crew is immediately free, but all progress on the task is lost.
      - If a tower was being built then is is canceled and completely removed from the map.
      - If a tower was being moved then it is reconstructed at its original place, and the work crew is occupied until the build is finished.  

- #### The player can move towers around the map `Medium`

  - Details
    - Once a player has built a tower they can select it and order it to be moved to a new tile on the map. 
    - The process is similar to building a new tower, but the player knows what kind of tower will appear in the new spot. 
    - The tower in the original place is dissembled, then the tower is built at the new spot. 
    - The path that the old tower blocked is now free, so enemies should re-path in case this gives them a shorter path. 
  - How it works
    - When selected a tower opens a dialogue that includes the move option.
      - If the third option for "currency" is chosen (work crews) then the move command will be a part of the work crew dialogue instead of giving towers a dialogue. 
    - Once the player selects a new place to build the tower it is disabled and the disassembly animation starts on the old tile. 
    - The new tile gets the construction animation
    - The new tile is marked as not a valid path, and paths are updated. 
    - New tower construction completes with the same tower type as was disassembled.
    - Old tile is marked as a path, and paths are updated. 





## Story and gameplay

### Story

While on a normal shipping run, and just a few weeks before reaching the end of the run, your starship ran itself through a untracked traveling swarm of evil aliens. As you try and escape the cloud of aliens you cannot help but hit some of them, and once they recover their bearings they are, understandably, rather annoyed. You and your crew quickly start to throw up some defensive towers to keep the aliens away from the critical parts of the ship: the engines, command bridge (maybe communications array instead), and airlock. Your engineers throw together towers from whatever they can find lying around, leading to some... questionably reliable structures, but in an emergency... 



### Gameplay







## Assets Needed

### 2D

* [ ] Title card
* [ ] Main Menu background
* [ ] Button templates
* [ ] Game HUD design



### 3D

* [ ] Enemy models
  * [ ] Enemy type A `High`
  * [ ] Enemy type B `Medium`
  * [ ] Enemy type C `Low`
* [ ] Tower models
  * [ ] Tower type A `High`
  * [ ] Tower type B `Medium`
  * [ ] Tower type C `Low`
* [ ] Starship map model `Medium`



### Sound

* [ ] Tower shooting `High`
* [ ] Tower targeting `Low`
* [ ] Tower idle `Low`
* [ ] Enemy movement `Medium`
* [ ] Enemy death `High`
* [ ] Enemy spawn `Medium`
* [ ] Enemy reaching the weak points `Medium`
* [ ] Tower construction `High`
* [ ] Tower destruction `Medium`
* [ ] Ambient sound `Low`
* [ ] Background music `Medium`
* [ ] Menu music `Low`
* [ ] Button sounds `Low`



### Code

* [ ] Enemy pathing
* [ ] Tower targeting
* [ ] Enemy health
* [ ] Tower construction
* [ ] Moving towers
* [ ] Enemy spawning
* [ ] Enemy spawn waves



### Animation

* [ ] Enemy movement `High`
* [ ] Enemy spawning `Medium`
* [ ] Enemy death `Medium`
* [ ] Enemy reaching goal `Low`
* [ ] Tower rotation `Low`
* [ ] Tower construction `High`
* [ ] Tower firing `High`





## Schedule

### Phase 1

* 10/1/2018
  * Map that can have towers placed on it.
  * Enemy pathfinder.
  * Complete tower and enemy concept art.

### Phase 2

* 10/31/18
  * Enemies path around towers and react to new tower placement.
  * Towers can shoot enemies.
  * Towers can be moved.
  * Complete models for towers, enemies, and background.
  * Tower and enemy sounds.

### Phase 3

* 12/1/18
  * Complete gameplay, including waves of enemies, victory condition, and loss condition. 
  * Complete and usable gameplay UI.
  * Animation for enemies and towers.
  * Music and ambient sound.

### Phase 4

* 12/14/18
  * Main menu complete
  * Final polish and balance 
  * Project complete
