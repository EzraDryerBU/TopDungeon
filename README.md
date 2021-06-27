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


## CameraMotor Script
Has three fields and one method currently

### Fields
-A Transform object that keeps track of what the camera is going to look at  
-Two floats for the horizontal and vertical bounds of the camera's vision  

### LateUpdate
-This method runs every frame after most methods that are called each frame have been run.  
-Has a Vector3 object with all feilds initialized to zero when the method starts  
-It thens checks to see if the new position to look at is any different then the current position the camera is looking at on either axis, and gets that difference as a signed number(float).  
-If the new float is greater than the bound feild in this class then the x field from this method's Vector# object is set to that difference (flip flop for if it is less than the negative of that bound).  
-Finally it modifies the transform.position feild of the camera itself, adding to it the new Vector3 object that has been created and possibly augmented during this method.  
