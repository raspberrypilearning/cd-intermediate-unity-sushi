## Creating obstacles
Now that you've got a player ship, it's time to add some asteriods for them to dodge and blast. You'll use one, invisible, `Asteroids` object and it will create visible asteroids. You'll also need a couple fo scripts to create and remove the asteroids in the game.

 Fist, make that `Asteroids` object: 
--- task ---
Create an Empty Object (**GameObject > CreateEmpty**). Name this `Asteroids`. 
--- /task ---

--- task ---
Create a folder called 'Asteroids' inside the Scripts folder.
--- /task ---

--- task ---
Make a `CreateAsteroids` script inside the 'Asteroids' folder.
--- /task ---

--- task ---
Make a `DestroyAsteroid` script inside the 'Asteroids' folder.
--- /task ---

--- task ---
Attach the `CreateAsteroids` script to the `Asteroids` object
--- /task ---

Now you're ready to start making asteroids:

--- task ---
Open the `CreateAsteroids` script and add this code inside the `Update` function:
```csharp
public GameObject asteroid;
  
void Update()
{
  Vector3 createPosition = Vector3.zero;
  GameObject asteroidClone = Instantiate(asteroid, createPosition, asteroid.transform.rotation);
}
```
--- /task ---

--- collapse ---
---
title: What does the code do?
---

To understand what's happening here, you need to know what **'instantiate'** means.

Instantiating something is like building something from plans or instructions. If you're baking a cake, the cake is the **instance** and the recipe is the `Instantiate()` function. In the game world, what's being instantiated with this code is not a cake but instead a **GameObject** called `asteroidClone`, using the `asteroid` 'recipe'.

--- /collapse ---

--- task ---
Drag the Asteroid prefab from the `Prefabs` folder and, in the Inspector for your `Asteroids` object, drop it into the **asteroid** box for your `CreateAsteroids` script.

![The asteroid prefab in the script](images/step5_asteroidPrefabInVar.png)
--- /task ---

--- task ---
Save everything (**File > Save Scenes**) and try running your game.
--- /task ---

WOAH! That was a lot of asteroid clones! 

![Lots of asteroid clone game objects](images/step5_lotsOfAsteroidClones.png)

The `Update()` function runs really fast, so it makes asteroids _really_ quickly. You can control how fast the asteroids are created with the `InvokeRepeating()` function, which invokes a particular repeating function on a set schedule. 

--- task ---
Add this to your existing code in `CreateAsteroids`:

```csharp
public float creationTime = 1f;

// Use this for initialization
void Start()
{
  InvokeRepeating("createAsteroid", 0f, creationTime);
}
```
--- /task ---

--- collapse ---
---
title: What does the code do?
---
This code sets up the `InvokeRepeating` function to run when the object is created. The function takes three parameters:

  * "createAsteroid" is the function to repeat
  * 0f is when to start invoking repeat
  * creationTime (currently set to 1) is the number of seconds to wait between invocations of the "createAsteroid" function
--- /collapse ---

--- task ---
Now change `Update()` to `createAsteroid()` and put the Asteroid prefab into the the script's **asteroid** box in the `Asteroids` object Inspector.
--- /task ---

--- task ---
Save the script, and try running the game again. It should create asteroids much more slowly now.
--- /task ---


### Cleaning up asteroids

If you create too many objects, your computer wont be able to keep track of them all. So you need to make sure these asteroids are destroyed at some point. You'll use the `Destroy()` function in the `DestroyAsteroid` script:


--- task ---
Attach the `DestroyAsteroid` script to the `Asteroids` object in the Hierarchy.
--- /task ---

--- task ---
Add `Destroy(gameObject, 10f);` to the `Start()` function of the `DestroyAsteroid` script.
--- /task ---

--- collapse ---
---
title: What does the code do?
---

Your `Start()` function should look like this:

```csharp
void Start () {
  Destroy(gameObject, 10f);
}
```

+ `gameObject` is the object the script is attached to (i.e. the asteroid clone)

+ `10f` means the asteroid will get destroyed after ten seconds
 
--- /collapse ---

### Make your asteroids move!

Now you have lots of asteroids, but they don't… do much. In this section, you'll make them move around.

--- task ---
Go back to the `CreateAsteroids` script and add this **above** `Start()`:

```csharp
public float asteroidSpeed;
```

+ Change the `createAsteroid()` function so that it looks like this:

```csharp
void createAsteroid () {
  Vector3 createPosition = Vector3.zero;
  GameObject asteroidClone = Instantiate(asteroid, createPosition, asteroid.transform.rotation);

  // make the asteroid move
  Rigidbody asteroidCloneRB = asteroidClone.GetComponent<Rigidbody>();
  asteroidCloneRB.velocity = -(transform.up * asteroidSpeed);
}
```
--- /task ---

--- collapse ---
---
title: What does the code do?
---

To make an asteroid move, you need to give it a velocity (a speed), and to do that, you need to get the asteroid's **Rigidbody**.

The line:

```csharp
Rigidbody asteroidCloneRB = asteroidClone.GetComponent<Rigidbody>();
```

looks at the asteroid clone you just created and gets its **Rigidbody**.

With the last line, you're changing the **Rigidbody**'s **velocity** property. `-(transform.up)` is the direction to move.

--- /collapse ---

--- task ---
Back in Unity, click on the `Asteroid` object in the Hierarchy and set **asteroidSpeed** to `2` in the script section of the Inspector. 

![](images/step5_setAsteroidSpeed.png) 

--- /task ---

### Randomise where the asteroids appear

Lets make it more fun by creating asteroids in different places. To do this, you can write a function that returns a random position!

--- task ---
Add this function to the `CreateAsteroids` script:
  
```csharp
Vector3 getRandomPosition()
{
    float xPos = Random.Range(.05f, .95f);
    Vector3 randomPosition = Camera.main.ViewportToWorldPoint(new Vector3(xPos, 1.1f, 15f));
    return randomPosition;
}
```
--- /task ---

--- collapse ---
---
title: What does the code do?
---

Putting `Vector3` instead of `void` in front of a function declaration means that the function will return a Vector3 object. 
  
`Random.Range(.05f, .95f)` returns a random number between the two numbers given in the **parameters** (a parameter is anything within the parentheses following a function). In this case, that will be a random number in between `0.05` and `0.95`. 
    
The camera's viewpoint dimensions are `1` × `1` (the bottom left being `(0,0)` and the top right being `(1,1)`). So the random number `xPos` you'll be using as the X coordinate will always be within the dimensions of the viewpoint.
  
You then create a Vector3 object called `randomPosition` and set it to:
  x — your randomly generated `x` position
  y — a `y` position that will lead to asteroid clones being created 'above' the screen
  z — the `z` position that is level with your `Player` object

You then return `randomPosition`.
  
--- /collapse ---

--- task ---
Finally, change `Vector3 createPosition = Vector3.zero;` to `Vector3 createPosition = getRandomPosition();`.
--- /task ---

--- task ---
Try the game out!
--- /task ---

