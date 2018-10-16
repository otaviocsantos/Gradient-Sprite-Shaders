using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{

    public Material mat;
    public Slider slider;
    void Start()
    {

        Color[] cores = { 
            new Color(0.1019608f, 0.01960784f, 0.2470588f), 
            new Color(0.08235294f, 0.01176471f, 0.4862745f), 
            new Color(0.2656272f, 0.14454433f, 0.884906f) 
        };
        float[] colorAnchors = {0, 0.5f, 1 };

        float[] alfas = { 1, 1, 0 };
        float[] alfaAnchors = { 0, 0.94F, 1 };


        mat.SetColorArray("_Colors", cores);
        mat.SetFloatArray("_ColorAnchors", colorAnchors);
        mat.SetFloatArray("_Alphas", alfas);
        mat.SetFloatArray("_AlphaAnchors", alfaAnchors);
        mat.SetInt("_ColorCount", cores.Length);
        mat.SetInt("_AlphaCount", alfas.Length);
    }

    void Update()
    {
        float range = slider.value;
        float[] alfaAnchors = {0, range * 0.94f, range };
        mat.SetFloatArray("_AlphaAnchors", alfaAnchors);

    }
}
