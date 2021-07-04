# TopDungeon
Top-Down dungeon rpg game in unity. Part of a project to do atleast some coding/programing related stuff everyday. The majority of the documentation here is for the code located in the TopDungeon/Assets/Scripts folder.  


## Player Script
Contains three fields and two methods

### Fields
-A BoxCollider2D field that will hold the box collider object of the player this script is assigned to. Called boxCollider.  
-A Vector3 object that will hold information about where the player wants to move each frame. Called moveDelta.  
-A RaycastHit2D object that will be used for checking wether or not the projected path of the player will cross or collide with any objects before actually moving the player. Called hit.  

### <ins>Methods:</ins>
### Start
-Currently just initializes a 2D box collider

### FixedUpdate
-This method runs every frame, and checks to see if the player has pressed a button  
-If they have, it checks to see if moving in that direction would cause it to collide with any other boxCollider object  
-If all checks are passed, it moves the player  


## CameraMotor Script
Has three fields and one method currently

### Fields
-A Transform object that keeps track of what the camera is going to look at  
-Two floats for the horizontal and vertical bounds of the camera's vision  

### <ins>Methods:</ins>
### LateUpdate
-This method runs every frame after most methods that are called each frame have been run.  
-Has a Vector3 object with all feilds initialized to zero when the method starts  
-It thens checks to see if the new position to look at is any different then the current position the camera is looking at on either axis, and gets that difference as a signed number(float).  
-If the new float is greater than the bound feild in this class then the x field from this method's Vector# object is set to that difference (flip flop for if it is less than the negative of that bound).  
-Finally it modifies the transform.position feild of the camera itself, adding to it the new Vector3 object that has been created and possibly augmented during this method.


## Collidable Class
Currently contains a three different fields and two methods. This class is going to be one inhereted from a lot, as it will govern the general outline of what happens when two game objects' Box Colliders collide.  

### Fields
-A ContactFilter2D object that will be used to check wether anything the player has touched is collidable.  
-A BoxCollider2D that will hold the Box Collider of the current object this script is asigned to. Called boxCollider  
-An array of Collider2D objects that will hold any 2D collider objects that the BoxCollider2D of this class has collided with. Called hits  

### <ins>Methods:</ins>
### Start
-As a start function it runs once at the begininng of a scene, with the purpose of getting the BoxCollider2D of the game object this script is assigned to and setting it equal to the boxCollider field in this class.  

### Update
-As an Update function it runs once a frame, and checks to see if something has collided with boxCollider. If some Collider2D object has, it puts it into the hits array.  
-It thens runs through each object in the array in order. The array is natrually instantiated as having all of its values set to null, so if the given value at a place in the array is null, that run through the loops ends and the next one starts.  
-If a position in the loop is not null it calles the OnCollide function of this class, sending it the Collider2D object at the current entry in the array. It then cleans up that position in the array for the next frame by setting the Collider2D object there to null.  

### OnCollide
-This method is a virtual one, and is intended to be overriden by almost all of the objects that inherit from this class. In its current form it simple prints out the name of the object that has been collided with.  


## Collectable Class
-A sub-calss of collidable, created to track game objects that will be collected by having the player object collide with them. Has sub-classes that will represent different individual collectable objects, or further classes of collectable objects.  
-Currently this class has one field and two methods.  

### Fields
-Simple boolean to track whether or not the object this script has been placed on has been collected by the player. Called collected.  

### <ins>Methods:</ins>
### OnCollide
-Basic method that checks whether or not the object that collided with the game object this script is assigned to was the player.  
-If it was, call OnCollect.  

### OnCollect
-Currently just sets the collected field to true.  


## Chest Class
A class used to facilitate the different properties of chests in the game. It inherits from Collectable, has two fields and one method.

### Fields
-A Sprite object that will hold the visual data for what the chest should look like once it has been collected. Called emptyChest.  
-A simple int that determines how much game currency is in the chest. Called pesosAmount.  

### <ins>Methods:</ins>
### OnCollect
-Overrides the virtual OnCollect method of the Collectable class.  
-Checks if the base field collected is true.  
-If it isn't sets collected to true, changes the the sprite of the object this script is attached to emptyChest, and prints a message to the debug log.  


## Portal Class
A class that will facilitate the transition between different games scenes. Inherits from Collidable. Has one fields and one method.

### Fields
-An array of strings that holds the different names of scenes. Called sceneNames.  

### <ins>Methods:</ins>
### OnCollide
-Overrides the virtual method of the Collidable class OnCollide.  
-Checks if the Collider2D object given to it belongs to the player.  
-If it does, declares a new string called sceneName and sets it equal to some random string from the sceneNames array.  
