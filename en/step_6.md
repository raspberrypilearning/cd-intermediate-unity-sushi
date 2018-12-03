## Creating lasers

Just like with the asteroids, you'll be using an empty `Lasers` object to create each indivdual laser.

--- task ---
 Create an Empty Object (GameObject > CreateEmpty). Name this Lasers.
--- /task ---

You'll also, as with the asteroids, have a pair of scripts to create and destroy 

--- task ---
Inside the `Scripts` folder, create a new folder called `Lasers`. Now create two C# scripts: `CreateLasers` and `DestroyLaser`.
--- /task ---

### Firing lasers

You're going to start with creating a laser (it's got to exist before you can destroy it, after all!). 

--- task ---
Attach the `CreateLasers` script to the `Lasers` **GameObject**.
--- /task ---

--- task ---
Add this code to the `CreateLasers` script: 
    
```csharp
public GameObject laser;
public GameObject player;

void Update(){
    if (Input.GetMouseButtonDown(0))
    {
    Vector3 createPosition = player.transform.position;
    createPosition.y += 1f;
    // Create a laser clone
    GameObject laserClone = Instantiate(laser, createPosition, transform.rotation); 
    }
}
```
--- /task ---

--- collapse ---
---
title: What does the code do?
---

Notice that this looks similar to the obstacle that you just created. You've added an `if` statement so that this block of code only runs when the player left clicks.

`player.transform.location` is the center of the player **GameObject**, your spaceship. You don't wan't to create the laser inside of the spaceship, and adding `1` to the `y` value will prevent that. 

You might not have seen this operator here before: `pos.y += 1f;`. Coders are pretty lazy and using these "shorthand" operators allow us to shorten code. `a += b` is the same as ` a = a + b`, but notice how much shorter the first one is! Here is a list of the shorthand operators in C#: [dojo.soy/CSharpShortOps](http://dojo.soy/CSharpShortOps){:target="_blank"}.

--- /collapse ---

With this code, left-clicking the mouse is the trigger for firing a laser.

If you want, you can try to allow the player to fire a laser when they press a different button like the spacebar. You can find other input options at [dojo.soy/CSharpInputs](http://dojo.soy/CSharpInputs){:target="_blank"}.

--- task ---
Now, just attach the "Laser" **Prefab** and "Player" **GameObject** to the script.
--- /task ---

### Getting the lasers to move

If you test your game right now you'll see that the lasers appear… and then just stay there. Time to get them moving!

--- task ---
Go back to the "CreateLasers" script and above `Start()` add

```csharp
public float laserSpeed;
```
--- /task ---

--- task ---
Add the following code to the end of `Update()` (so, underneath the line `GameObject laserClone = Instantiate(laser, createPosition, transform.rotation);`):

```csharp
// Make the clone move
Rigidbody laserRB = laserClone.GetComponent<Rigidbody>();
laserRB.velocity = transform.up * laserSpeed;
```
--- /task ---

--- collapse ---
---
title: What does the code do?
---

Just like with the asteroids, you need to access the laser's **Rigidbody** to set its velocity.

The code `laserClone.GetComponent<Rigidbody>()` gets the **Rigidbody** so that you can then set the velocity on the next line.

--- /collapse ---

--- task ---
Back in Unity, click on the "Laser" object in the Hierarchy and set "laserSpeed" to `20` in the script section of the Inspector.
--- /task ---

--- task ---
Try out your lasers now!
--- /task ---

### Adding sound
In movies, lasers make sounds, right? Let's add a sound to this laser.

--- task ---
Click on the laser in the "Prefabs" folder and add an **AudioSource** component (**Component > Audio > Audio Source**).
--- /task ---

--- task ---
From the "Audio" folder in "Assets", drag "LaserSound" into the **Audio Clip** property in the "Laser" prefab **Inspector**.

![Drag the sound into the Audio Clip box](images/step6_laserSound.png)
--- /task ---

--- task ---
Run the game and test the lasers out!
--- /task ---
