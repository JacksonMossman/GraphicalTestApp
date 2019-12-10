| Jackson Mossman |
:-
|s198037
|Math For Games Assessment
|Astroids but worse

## Requirements

1.Create a Graphical Test Application that uses Math Classes and implementing examples of Matrix Hierarchy To manipulate Visble elements, Examples of game objects moving with velocity and acceleration with vector, and examples of simple collision

## Input Information

 - W key is used to move the ship forward in the direction it is currently facing 
 - A Is used to rotate the ship left
 - D is used to rotate the ship right
 - E is used to rotate The left turret 
 - Q is used to rotate the right turret
 - X is used to Fire both Turrets
 - Esc is used to exit the game at any point
## Output Information
- The Game will begin with a ship in the middle of the screen with stars in the backround
- every 5 seconds a astroid will spawn randomly with a random position and velocity
- after 2 astroids are destroyed the rate they spawn will double this threshold doubles each time
- The Players scord and current lives are displayed in the top left corner of the screen
- If the player dies a shield will be diplayed for 5 seconds then end
- Visible Hitboxes that will turn blue upon collision events
  
## User Interface

- The User Interface only contains a amount of lives and the current score of the player

# Design

- My Game Loop Updates all of the actors in the scene and all the actors update thier children

- My Backround is a actor that has stars randmly placed at the begining of the game

- My Player is then added to my scene and the astroid spawner is started
  

## Classes

### Program

Programs duty is to initialize and start the game as well as add the astroid and star generators as well as the player and difficulty manager

### Game

Games Duty is to manage The Update Function and Drawing the root

    Name: _root  
    Desc: The root of the scene
    Type: Actor

    Name: _next
    Desc: Not used
    Type: Actor

    Name: stopwatch
    Desc: used as a stopwatch for the astroid generator
    Type:StopWatch

    Name: Score
    Desc: Keeps track of the players score
    Type:Int

    Name:windowsizeX 
    Desc:Takes the window size X
    Type:Int
    Name: WindowSizeY 
    Desc: Keeps Track of Y window Size

    Name:AstroidList
    Desc: a list of all the current astroids in the scene
    Type:List<Astroid>

    Name: random
    Desc: random Number Generator
    Type: Random

    Name:Difficulty 
    Desc: Manages the astroid spawn rate
    Type: Int

    Name: GameOver
    Desc: Keeps track if game is over
    Type:Bool

    
    Name:Run
    Desc:Main Game loop
    Type:void
### Actor

    Name: OnStart
    Desc: calls on start functions
    Type: Delegate

    Name: OnUpdate
    Desc: calls OnUpdate Functions
    Type:Delegate

    Name: OnDraw
    Desc: Calls on draw functions
    Type:Delegate

    Name: Started
    Desc: keeps track if a actor has been started
    Type:Bool

    Name:Parent  
    Desc: This actors parent
    Type:Actor

    Name: _children 
    Desc: List of this actors children
    Type:List<Actor>

    Name: _additions
    Desc: actors ready to be added to this actor
    Type:List<Actor>

    Name:_removals 
    Desc: a list of actors to be removed
    Type:List<Actor>

    Name: _localTransform
    Desc: this actors reletive transform to its parent
    Type: Matrix3

    Name: _globalTransform
    Desc: this actors global position
    Type: Matrix3

    Name: X
    Desc: this actors local x transform
    Type: Float

    Name: XAbsolute
    Desc: This actors global Xposition 
    Type: Float

    Name:Y  
    Desc:This actors local y transform
    Type: Float

    Name:YAbsolute 
    Desc:This actors global Y transform
    Type:Float

    Name:GetRotation 
    Desc:Return the rotation
    Type:float

    Name: Rotate(float Radians)
    Desc: Rotate a actor on the Z axis
    Type: Void

    Name: GetScale
    Desc: ReturnScale
    Type: Void

    Name:Scale(float Width float height)
    Desc:Update a scale based off input values
    Type:void

    Name:AddChild(Actor Child) 
    Desc:Add a child to this actor
    Type:Void

    Name:RemoveChild(Actor Child)
    Desc:add a child to this actors removals list
    Type:void

    
    Name:UpdateTransform()
    Desc:update a actors position
    Type:void
    
    Name:Start
    Desc:invoke all starting functions for this actor and its children
    Type:void
    
    Name:Update(float DeltaTime)
    Desc: manages all things ment to happen every update
    Type:void
    
    Name:Draw
    Desc:Do all the functions tied to this actors draw
    Type:void

### Entity 

    Entitys job is to maintain a objects acceleration and velocity 

    
    Name:_velocity
    Desc:Maintain a vector that represents this objects velocity
    Type: Vector3

    
    Name:_acceleration
    Desc: Maintain a vector representing a objects acceleration
    Type:Vector 3

    
    Name:XVelocity
    Desc:a entitys x velocity
    Type:Float

    
    Name:Xacceleration
    Desc:a entitiys xacceleration
    Type:Float

        Name:YVelocity
    Desc:a entitys Y velocity
    Type:Float

    
    Name:YAcceleration
    Desc:a entitiys Yacceleration
    Type:Float
    
### Astroid

    Name:_astroidSprite
    Desc:Generating a sprite for the astroid
    Type:Sprite

    Name:Bounce(float DeltaTime)
    Desc: makes the astroids bounce off the walls
    Type: Void

    
    Name:playerCollide(float DeltaTime)
    Desc:CHecks if the astroid has collided with the player
    Type:Void

### Astroid Generator
    Generates the astroids and populates the screen

    Name: _stopwatch
    Desc: manage the time between astroid spawns
    Type: Stopwatch

    
    Name:_random
    Desc: randomly gerate diffrent factos for the astroid
    Type: Random

    
    Name:AstroidGeneration(float Delta)
    Desc:Generates the astroids from random variables
    Type:void

### Bullet
    Manages bullets
    
    Name:sprite
    Desc:load the bullets sprite
    Type: Sprite

    Name:_hitbox
    Desc:the bullets hitbox
    Type:AABB

    Name:BulletCleanUp(float deltaTime)
    Desc:Removes bullets when they exit the screen
    Type:void

    Name:BulletCollide
    Desc:Checks if the bullet is collideing with any astroids
    Type:void

### Input

    Manages KeyboardKey Inputs from raylib and converts them to bools

### Matrix 3

    Manages Matrix 3 Math 

### Matrix 4

    Manages Matrix 4 Math not used
### Player


    Name:_sprite
    Desc:Players ship sprite
    Type:Sprite
    
    Name:_shield
    Desc:Players first shield sprite
    Type:Sprite
    
    Name:_shield2
    Desc:Players second shield Sprite
    Type:Sprite
    
    Name:_shield3
    Desc:players third Shield Sprite
    Type:Sprite
    
    Name:_engineSprite
    Desc:the players engine Sprite
    Type:Sprite
    
    Name:_turret 
    Desc:the players first Turret
    Type:Turret
    
    Name:_turret2
    Desc:The players second Turret
    Type:Turret

    
    Name:_turrets
    Desc:a list of all the players turrets not used
    Type:List<Turret>
    
    Name:hitbox
    Desc:the players hitbox
    Type:AABB
    
    Name:Instance
    Desc:Static variable for the player
    Type:Player

    
    Name:stopwatch
    Desc:used to manage the time between shots
    Type:Stopwatch
    
    Name:InvincibilityStopWatch
    Desc:Used to time the players invicibility after being hit
    Type:StopWatch
    
    Name:_speedCap
    Desc:The players speedcap
    Type:int
    
    Name:lives
    Desc:used to keep players live counter
    Type:int
    
    Name:powerupcount
    Desc:keeps track of how many powerup the player currently has
    Type:int


    Name:invincibility
    Desc:keeps track if the player is currently invinsible 
    Type:bool
    
    Name:_deathSound
    Desc:Players deathsound
    Type: Sound
    
    Name:Movement(float deltatime)
    Desc:Manages the players movement and slowdown
    Type:void
    
    Name:Rotation(float deltatime)
    Desc:Rotates the player
    Type:void

    
    Name:turretRotation(float deltatime)
    Desc:Rotates the players turrets
    Type:void

    Name:bounceCheck(float deltatime)
    Desc:bounces the player off the edges of the  screen
    Type:void

    Name:speedCheck(float deltatime)
    Desc: checks the players speed and adjusts it if its to high
    Type:void

    Name:Fire(float deltatime)
    Desc:Fire all the players turrets
    Type:void

    Name:InvinsibilityTimer
    Desc:manages the players invinsbility after being hit
    Type:void

    Name:Playerhit
    Desc:called when the player is hit 
    Type:void

### Score and difficulty manager 

    Manges the players score and the games difficulty

    Name:ScoreMult
    Desc:incaments the games difficulty and multiplies the score
    Type:void
    

### Sprite
     A actor that is used to manage a image on the screen

 ### Star
    makes stars for the backround

    Name:_sprite
    Desc: this stars star sprite
    Type:Sprite

    Name: _sprite2
    Desc: this stars sprite if its randomly selected to be a planet
    Type: Sprite

### StarGenerator
    adds the stars and moves them around the scene

    Name:count
    Desc:the amount of stars to add
    Type:int

    Name:Generator
    Desc: generates the stars and randomly places them
    Type:void
### Timer

    Used to manage the games deltatime 

### Turret

    Name:_turretsprite 
    Desc:the turrets sprite
    Type:Sprite

    
    Name:Fire
    Desc:fires a bullet from this turret
    Type:void

### Vector3
    Manages Vector3 math
### Vector4 
    Manages Vector4 math



