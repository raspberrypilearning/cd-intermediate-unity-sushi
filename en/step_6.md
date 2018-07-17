## Creating Projectiles

+ Create a new folder called `Lasers` (make sure its in the "Scripts" folder). Now create three C# scripts:  `CreateLasers`, `MoveLaser`, and `DestoryLaser`.

+ Start with creating a laser. Attach the "CreateLasers" script to the "Lasers" **GameObject**. Add this code: 
    
```csharp
public GameObject laser;
public GameObject player;

void Update(){
    if (Input.GetMouseButtonDown(0))
    {
    Vector3 createPosition = player.transform.position;
    createPosition.y += 1f;
    // Create a laser clone
    Instantiate(laser, createPosition, transform.rotation); 
    }
}
```
  
--- collapse ---
---
title: What does the code do?
---

Notice this looks similar to the obstacle that you just created. You've added an `if` statement so that this block of code only runs when the player left clicks.

`player.transform.location` is the center of the player **GameObject**. 

You don't wan't to create the laser inside of the spaceship so adding 1 to the y value will stop that. 

You might not have seen this operator before `pos.y += 1f;`. Coders are pretty lazy and using these "shorthand" operators allow us to shorten code. `a += b` is the same as ` a = a + b`, but notice how much shorter the first one is! Here is a list of the shorthand operators in C#: [dojo.soy/CSharpShortOps](http://dojo.soy/CSharpShortOps).

--- /collapse ---

With this code, left clicking the mouse is the trigger for firing a laser.

+ If you want, try to allow the player to fire a laser when they press a different button like the spacebar. You can find other input options here: [dojo.soy/CSharpInputs](http://dojo.soy/CSharpInputs).

+ Now, just attach the "Laser" prefab and "Player" **GameObject** to the script.
  
+ Now open the "MoveLaser" script. Above `Start()` add `public Rigidbody rb` and `public float laserSpeed;`. In `Start()` add `rb.velocity = transform.up * laserSpeed;`.

+ Drag the script onto the "Laser" prefab . Then just add the laser's **Rigidbody** to the script and set "laserSpeed" to `20`.
    
+ Try out your lasers now!

Lasers make sounds, right? Lets add a sound to this laser.

+ Click on the laser in the "Prefabs" folder and add an **AudioSource** component (**Component > Audio > Audio Source**).

+ From the "Audio" folder drag "LaserSound" into the **Audio Clip** property in the "Laser" prefab **Inspector**.

If you run the game you can test the lasers out!
