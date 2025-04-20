# AI States Assignment3
 Assignment 3 Ai States
Document the Design Rationale and Gameplay Impact 
How AI behaviors influence player strategy and decision-making:
The Ai paths around specific checkpoints that interfere with the player trying to escape through the portal. The player must navigate through the enemy red cubes to use the portal and escape the level. However, the red cubes have a line of sight; meaning they will chase you until you either outrun them or get caught. Showing that the player needs to avoid the enemy line of sight before thinking about escaping. Which means that the positioning of the red cubes influences the player strategy, and decision making. Due to how the Ai goes into the chase state and goes to catch the player if they see them.

How player actions dynamically alter AI states and responses:
The player has a choice of either waiting or attempting to outrun the cubes if they spot the player. The player's actions of heading towards the portal risks being discovered and requires stealth maneuverability if they want to go unnoticed by the ai. As the player changes the Ai state from patrolling the various checkpoints to a chase state if the player is caught.

Challenges faced during implementation and their solutions:
I was absent during the development of the AI search state, for when the player gets out of sight, so as a result was unable to properly implement that feature. However, the project works fine as the Ai will just go back to patrolling instead. Another issue I came across was correctly implementing the switch scene scripts for the enemy and the portal on collision scripts. I got that to work by using on trigger enter instead; which, more or less accomplishes the same thing.
