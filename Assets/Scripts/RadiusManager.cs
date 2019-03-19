using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiusManager : MonoBehaviour
{

    public Material mat;
    public Slider slider;

    Color[] colors = {
            new Color(0.8867924f, 0.8403348f, 0.4810431f),
            new Color(0.4823529f, 0.8862745f, 0.4878726f),
            new Color(0.8862745f, 0.4823529f, 0.519865f),
        };
    float[] alphas = { 0, 0.0f, 1f, 0f, 0 };
    float[] colorAnchors = { 0, 0.5f, 1 };

    void Start()
    {
        mat.SetColorArray("_Colors", colors);
        mat.SetFloatArray("_Alphas", alphas);
        mat.SetFloatArray("_ColorAnchors", colorAnchors);
        float[] alphaAnchors = { 0, 0.0f, 0.1f, 0.2f, 1 };
        mat.SetFloatArray("_AlphaAnchors", alphaAnchors);

        mat.SetInt("_ColorCount", colors.Length);
        mat.SetInt("_AlphaCount", alphas.Length);
    }

    void Update()
    {
        float range = slider.value;
        float[] alphaAnchors = { 0, range - 0.1f, range, range + 0.1f, 1 };

        mat.SetFloatArray("_AlphaAnchors", alphaAnchors);
    }
}
