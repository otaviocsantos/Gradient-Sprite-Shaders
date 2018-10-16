# Gradient Sprite Shaders
version: 1.0.0

# What are these?
These are sprite shaders that display gradients with more than two colors. 

# How to use:

1 - Create a material: Top Menu -> Assets / Create / Material
    
2 - Assign one of the shaders to the material: For example: Tavio / Sprites / LinearAlphaGradient

3 - Create a UI element: like a Panel or Image

4 - Apply your material to the UI element

5 - Create a script that takes in the material and assign gradient values to it. There are example scripts you can follow, look for the in Scripts folder

## The gradients will appear only **after** you run the script.

# How does these work?
The colors need to be defined via script:
```C#
Color[] colors = { Color.red, Color.green, Color.blue };
float[] colorAnchors = { 0, 0.5f, 1 };

float[] alphas = { 1, 0.2f, 0, 0.7f, 1 };
float[] alphaAnchors = { 0, 0.3f, 0.5f, 0.7f, 1 };

// Set colors in the gradient
mat.SetColorArray("_Colors", colors);

// Control where a color fade into another, this allow for different sized color bands
mat.SetFloatArray("_ColorAnchors", colorAnchors);

// Set alpha values, this allow for trasparency in the gradient
mat.SetFloatArray("_Alphas", alphas);

// Define where in the gradient a color should turn more opaque or transparent
mat.SetFloatArray("_AlphaAnchors", alphaAnchors);

// Set how many color and trasparency bands are used
mat.SetInt("_ColorCount", colors.Length);
mat.SetInt("_AlphaCount", alphas.Length);
```

Adjusting anchors result in a subtle or drastic transition

# LICENSE
These files are licensed under the MIT License by Otavio Costa dos Santos