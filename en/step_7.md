## Detecting collisions

You have all the components of your game working now. Awesome, but... they don't do anything when they **collide**. Colliding is when two objects touch each other. You need to detect the collision between the game's objects and write some scripts that do something when a collision is detected. In this case, 'something' is usually an explosion.

Before you start, tagging the asteroid prefab will be helpful. Tags are used to help you identify objects later in your code. You can add a tag using the drop-down in the Inspector, just below an object's name. 

--- task ---
Tag the asteroid prefab with 'asteroid'.
--- /task ---

--- task ---
If you haven't already attached the 'DestroyLaser' script to the  'Lasers' game object, do so now.
--- /task ---

### Lasers colliding with asteroids

First, make sure that the laser blasts will destroy an asteroid if they hit it, and that they'll vanish when they do so:

--- task ---
Open the C# script called 'DestroyLaser'. Add the following code to the script:

```csharp
public void OnCollisionEnter(Collision col)
{
    if (col.gameObject.CompareTag("Asteroid"))
    {
    // Destroy both objects
    Destroy(col.gameObject);
    Destroy(gameObject);
    }
}
```
--- /task ---

--- task ---
Now open the "CreateLasers" script and add the following line underneath `GameObject laserClone = Instantiate(laser, createPosition, transform.rotation);`

```csharp
laserClone.AddComponent<DestroyLaser>();
```
--- /task ---

--- collapse ---
---
title: What does the code do?
---

`OnCollisionEnter(Collision col)` is a built in function that is called when the object the script is attached to and another object collide.

Within this function you have two **GameObjects** `col.gameObject` and `gameObject`. `gameObject` is what the script is attached to (the laser clone) and `col.gameOBject` is the thing colliding with the laser (the asteroid). 

`col.gameobject.name` returns the name of the object the laser collided with.

The `if` statement is to make sure that if the laser collided with an asteroid (which will be tagged "asteroid"), then the two objects will be destroyed.

Finally, you need to attach the 'DestroyLaser' script to each new **instance** of the laser game object. You do this in the 'CreateLasers' script, after instantiating the clone:

```csharp
GameObject laserClone = Instantiate(laser, createPosition, transform.rotation);
laserClone.AddComponent<DestroyLaser>();
```

--- /collapse ---

To reward you player for successfully hitting an asteriod (with a laser, not their ship!), you should add a nice explosion sound!

--- task ---
Create an Empty GameObject (**GameObject > Create Empty**) and call it `AsteroidExplosion`.
--- /task ---

--- task ---
Add an **AudioSource** component to `AsteroidExplosion`. Open up the "Audio" Assets folder and drag and drop the "DestroyAsteroidSound" sound into the `AsteroidExplosion` **Inspector** for "Audio Clip". 

--- /task ---

--- task ---
Then, uncheck the "Play On Awake" property. 

![The Play On Awake checkbox is unticked](images/step7_playOnAwake.png)
--- /task ---

--- task ---
To play the **AudioSource** add this code into the `if` statement you made above.

```csharp
AudioSource audio = GameObject.Find("AsteroidExplosion").GetComponent<AudioSource>();
audio.Play();
```
--- /task ---

--- collapse ---
---
title: What does the code do?
---

The first line finds the game object you made and stores it in a variable called `audio`.

The second line tells the game object to play the sound that you added to the **AudioSource**.

--- /collapse ---

### Collisions with the player

Now you can detect a collision with an asteroid and the laser, but not your "Player" **GameObject** and an asteroid. The code below will fix that.

--- task ---
Add this code to your "PlayerController" script after the `Update()` function:

```csharp
void OnCollisionEnter(Collision col)
{
    if(col.gameObject.name == "Asteroid(Clone)")
    {
        Destroy(gameObject);
        Destroy(col.gameObject);
    }
}
```
--- /task ---

--- collapse ---
---
title: Understanding the code
---

Do you know what the `gameObject` is here?

It is your "Player" object because your script is attached to the "Player" object. 

That means the `col.gameObject` is an asteroid.

--- /collapse ---

Let's play a different noise if the player collides with an asteroid.

--- task ---
Create another **Empty** and call it "PlayerExplosion".
--- /task ---

You can re-use the asteroid explosion sound here, or add one of your own by dragging it into Unity and storing it in the **Assets>Audio** folder.

--- task ---
Add an **AudioSource** and add the "DestroyAsteroidSound" sound to it.
--- /task ---

--- task ---
Finally, add this code to the `OnCollisionEnter()` function in the "Player" script.

```csharp
AudioSource audio = GameObject.Find("PlayerExplosion").GetComponent<AudioSource>();
audio.Play();
```
--- /task ---

    
    
