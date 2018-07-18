## Creating Your Game World

Cameras are important in Unity. The camera displays what the player of your game sees. Lights in Unity do exactly what they do in real life. You can move lights around to see objects better.

+ Make sure that the **Transform** of the "Main Camera" is set to have **position** `(0, 0, -15)` and that the **Transform** of the "Directional Light" has the **position** set to `(0, 0, -15)`.

![The position Transform for the Main Camera](images/step3_MainCameraPos.png)
![The position Transform for the Directional Light](images/step3_DirLightPos.png)

+ Create a 3D Object **Quad** and rename it to `Background` and set the **Transform** position to `(0, 0, 1)`. Make sure the **Rotation** is `(0, 0, 0)`.

+ Drag the "SpaceNebula" image from the "Materials" folder in the **Project Viewer** and drop it on the Background object in the **Hierarchy**. 

+ Set the **Scale** of x and y on your "Background" **Quad** until it covers the entire Game Display. (Make sure it's set to the "Standalone" Aspect Ratio)

![A space background scaled to fit the Game Display](images/step3_background.png)

Awesome, you have a background! Now lets add something to control!

+ From the "Prefabs" folder drag and drop the "Player" object onto your scene view. Set the **Transform** position to `(0, 0, 0)`.

![The Player object placed in the centre of the scene](images/step3_PlayerPos.png)

Did you notice that the spaceship has a shadow? It doesn't look very good, so you can get rid of it. To select which objects the "Directional Light" applies to you use the **Culling Mask** and **Layers** properties of the light.

+ In the "Directional Light" **Inspector** click the "Layers" drop down on the top right.

+ Click "Add Layer...". In the first open layer type `Background`.

+ Go back to the "Directional Light" **Inspector**. Click the **Culling Mask** drop down menu and select "Everything". Now deselect the "Background" in the **Culling Mask**. The **Culling Mask** will now say "Mixed...".

![The culling mask settings](images/step3_cullingMask.png)

+ Go to your "Background" object's **Inspector** and select the layer drop down menu and set it to the "Background" layer you just created. There will be no more shadow!

To control the game with scripts without attaching them to a 3D object, "Empty Objects" can be used.

+ Create an "Empty Object" (**GameObject > CreateEmpty**). Name this `Asteroids`. 

+ Create another "Empty Object" called `Lasers`. 

Your scene should look something like this when it is done. (You can use the icons in the top right of the scene to look at it from different angles!)
    
![The finished scene](images/SceneComplete.png)
![The finished scene viewed from above](images/step3_SceneComplete2.png)