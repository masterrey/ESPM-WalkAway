using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPost : MonoBehaviour
{
    public Light mylight;
    public Renderer lightGlass;
    // Start is called before the first frame update
    void Start()
    {
        DayCicle.instance.DawnCaller += Sunset;
        DayCicle.instance.DuskCaller += Sunrise;
    }

    void Sunrise()
    {
        mylight.intensity = 0;
        lightGlass.materials[1].DisableKeyword("_EMISSION");
    }

    void Sunset()
    {
        mylight.intensity = 1;
        lightGlass.materials[1].EnableKeyword("_EMISSION");
    }

}
