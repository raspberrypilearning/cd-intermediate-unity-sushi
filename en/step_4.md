## Moving the Player

+ Create a folder in your Assets folder and name it `Scripts`. Now create a new C# script in your new "Scripts folder". When you create a script you want to know what it does, so lets give it a descriptive name. You could use `PlayerController`. Attach this code to your "Player" object.

+ Open your new script and add this code to the **Update()** function. 

```csharp
Vector3 mousePos = Input.mousePosition;  
mousePos.z = 15f;
transform.position = Camera.main.ScreenToWorldPoint(mousePos);
```

--- collapse ---
---
title: What does the code do?
---

**Vector3**s are structures (a structure stores multiple variables in one unit).

Unity uses **Vector3** to keep track of an object's position in the world (x, y, z). So, when you set the **Vector3** equal to the `Input.mouseposition` the x and y values of the **Vector3** are changed each frame (because its in the update function).

`Input.mousePosition` doesn't change the **Vector3**'s position on the z-axis. You can set the z value by using "**.**" (called the "Dot Operator"). This allows us to access the variables within the **Vector3** structure.

The last line moves our "player" object to the position of our mouse!      `transform.position` changes the location of your "Player" object. `Camera.main.ScreenToWorldPoint(mousePos)` sets the position of your "Player" object in the game world space.

--- /collapse ---

+ Now try to run your game! What is something that you might want to change about where the "player" object goes?
     
+ Did you notice that the "Player" object doesn't stay on the screen? You can fix this by adding this bit of code underneath the code you added in step 2!
    
```csharp
Vector3 spritePos = Camera.main.WorldToViewportPoint(transform.position);
spritePos.x = Mathf.Clamp(spritePos.x, 0.05f, 0.95f);
spritePos.y = Mathf.Clamp(spritePos.y, 0.1f, 0.9f);
transform.position = Camera.main.ViewportToWorldPoint(spritePos);
```
  
--- collapse ---
---
title: What does the code do?
---
  
The first line of code here gets the position of our "Player" object.

You can then use the **Mathf** function **Clamp** to keep the "Player object within the camera's viewport. **Clamp** stops the position of the "Player" object coordinates on the x, y axis from exceeding the given values.

--- /collapse ---

Now the "Player" object follows your cursor, but it would be nice to remove the cursor now!

+ Adding this line of code into the **Start** function does will get rid of the cursor:

```csharp
Cursor.visible = false;
```

+ Try running the game and moving the "Player" object with your mouse!