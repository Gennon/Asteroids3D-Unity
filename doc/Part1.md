---
marp: true
theme: uncover
class: invert
paginate: true
---
<style>.smaller-text { font-size: 0.8em; }</style>
# Asteroids 3D

An introduction to 3D game development with Unity and Blender

---

# Tools we will use

-  [Unity 2022.3 LTS](https://unity.com/) - Game engine
-  [Blender 3.6](https://www.blender.org/) - 3D modeling
-  [Visual Studio Code](https://code.visualstudio.com/) - Code editor

---

# What we will learn

-   How to create low-poly 3D models in Blender
-   How to import 3D models into Unity
-   How to create a simple 3D game in Unity

---

# Setup Blender

We need to setup blender with some nice settings to make it easier to work with. We will focos on creating low poly models.

---

## Default Material

First we need to create a default material that we can use for all our models. We will make use of the same texture for all models to save space and make it easier to work with.

---

<!--
_backgroundColor: #1D1D1D
_color: white
-->

![height:640px](./assets/Shader.png)

---

## Viewport

![bg left width:300](./assets/ViewportShading.png)


-   <small>We change the viewport settings to make it easier to see the texture while modeling.</small>
-   <small>We will use the `UV Editing` layout for this.</small>


---

## Addons

There are some great addons that we can use to make it easier to work with Blender.

-   Select `Edit` -> `Preferences` -> `Add-ons`

Add the following addons:

-   Interface: Modifier Tools
-   Mesh: Auto Mirror
-   Mesh: F2
-   Object: Bool Tool

---

## Setup the scene

- Delete the camera
- Delete the light


## Save Startup File

We need to save the startup file so that we can use it for all our models.
File -> Defaults -> Save Startup File

<small>Can be smart to have StartupFile.blend saved in OneDrive or similar.</small>

---

# Setup Unity

Unity has most of the settings we need by default. We will just change a few things.

---

## Create a new project

-   Open Unity Hub
-   Select `New Project`
-   Select `3D (URP) Core Template`

---

### Unity Render Engines

<small>Unity has three different render engines that we can use.</small>

-   `Built-in Render Pipeline`
-   `Universal Render Pipeline`
-   `High Definition Render Pipeline`

<small>We will use the _Universal Render Pipeline (URP)_ as it is the most flexible and works on most platforms.</small>

---

### Unity Packages

<small>Unity has a lot of packages that we can use to extend the functionality of Unity.</small>

- Select `Window` -> `Package Manager`
- Update `Visual Studio Editor` to 2.0.20 or later

---

## Preferences

-   Select `Edit` -> `Preferences`
-   Select `External Tools`
-   Change `External Script Editor` to `Visual Studio Code`
---


# Setup Visual Studio Code

-   Open Visual Studio Code
-   Select `Extensions` (Ctrl+Shift+X)
-   Install `Unity` extension

<small>This will install several other dependencies.</small>

---

# Create an Asteroid

We will create a simple asteroid model in Blender and import it into Unity.

---

## Create a new Blender file

-  Open Blender
-  Select `File` -> `New` -> `General`
-  Select `File` -> `Save As` -> `Asteroid01.blend`

Save the file in the same folder as the Unity project under `Assets/Models`

---

## Import it into Unity

- Open Unity
- Drag the Asteroid01 file into the scene
- Select the `Asteroid01` object in the scene and press `F` to focus on it.
<small>The asteroid should now be visible in the scene, but it is WHITE!😱</small>

---

## Fix the material (1/1)

-   Select `Asteroid01` in the `Project` window
-   Select `Asteroid01` in the `Inspector` window
-   Select `Materials` -> `Extract Materials...`
-   Save the material in the models folder 'Assets/Models'

---

## Fix the material (2/2) 

- Create a new folder `Assets/Models/Textures`
- Copy the albedo.png and the emission.png into the `Textures` folder
- Select the Material in the `Project` window
- Select the `Albedo` texture for the Base Map
- Select the `Emission` texture for the Emission Map

---

![bg height:480px](./assets/Cube.png)
![bg height:480px](./assets/Material.png)

---

## Make it look like a real asteroid

So the cube with all it's colors doesn't really look like an asteroid. Let's fix that!

- Open Blender

---

### Select the color

- Select the `Cube` object in the 3D viewport
- Rename the object to `Asteroid01`
- Go into `Edit Mode` (Tab)
- Select all the vertices in the 3D viewport (A)
- Select all the UVs in the UV editor (A)
- Scale to zero (S -> 0 -> Enter)
- Move the UVs to the correct position (G)
- Save the file (Ctrl+S)
- View the result in Unity

---

### Add some details

- Select the `Cube` object in the 3D viewport
- Go into `Object Mode` (Tab)
- Add a `Subdivision Surface` modifier (Ctrl+4)
- Apply the modifier (Ctrl+A)
- Go into `Edit Mode` (Tab)
- Make use of Propotional Editing (O)
- Select some random vertices and move them around (G)
- Create the asteroid of your nightmares!

---

### Convert it to low-poly

- Select the `Cube` object in the 3D viewport
- Go into `Object Mode` (Tab)
- Add a `Decimate` modifier
- Change the `Ratio` to 0.1
- Apply the modifier (Ctrl+A)
- Save the file (Ctrl+S)
- View the result in Unity

---

### Scale it to the correct size

- Select the `Cube` object in the 3D viewport
- Go into `Object Mode` (Tab)
- Scale the object to the correct size (S)
- Apply the scale (Ctrl+A)
- Save the file (Ctrl+S)
- View the result in Unity

---

### Why is scale important?

- If we don't apply the scale the object will be scaled in Unity
- This will cause problems with physics and other things
- It is important to apply the scale before exporting the model

---



# Make the asteroid move

