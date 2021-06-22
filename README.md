# TopDungeon
Top-Down dungeon rpg game in unity

## Player Script
Contains two methods: 

### Start
-Currently just initializes a 2D box collider

### FixedUpdate
-This method runs every frame, and checks to see if the player has pressed a button
-If they have, it checks to see if moving in that direction would cause it to collide with any other boxCollider object
-If all checks are passed, it moves the player
