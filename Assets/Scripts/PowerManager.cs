using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{

    public Material mat;
    public Slider slider;
    Color[] hiColors = {
            new Color(1, 0.9800432f, 0.0235849f),
            new Color(0.0f, 1, 0.009708643f),
            new Color(1f, 0.0f, 0.09708738f),
        };
    Color[] lowColors = {
            new Color(0.8867924f, 0.8403348f, 0.4810431f),
            new Color(0.4823529f, 0.8862745f, 0.4878726f),
            new Color(0.8862745f, 0.4823529f, 0.519865f),
        };
    void Start()
    {

        

        
        float[] colorAnchors = { 0, 0.3333f, 0.333331f, 0.666666f, 0.66666661f, 1 };
        Color[] colors = { lowColors[0], lowColors[0], lowColors[1], lowColors[1], lowColors[2], lowColors[2] };

        mat.SetColorArray("_Colors", colors);
        mat.SetFloatArray("_ColorAnchors", colorAnchors);
        mat.SetInt("_ColorCount", colors.Length);
    }   

    void Update()
    {
        float range = slider.value;
        int count = Mathf.RoundToInt(range * 3);
        Color[] colors = { lowColors[0], lowColors[0], lowColors[1], lowColors[1], lowColors[2], lowColors[2] };

        if(range > 0.1f){
            while (count > 0)
            {
                count--;
                colors[count*2] = hiColors[count];
                colors[count*2+1] = hiColors[count];
            }
        }
        mat.SetColorArray("_Colors", colors);

    }
}
