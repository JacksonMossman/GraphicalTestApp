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


