using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour
{
    public double dayseconds;
    float anglight;
    public float dayspeed=1;
    Light mylight;
    float intensity;
    public Gradient skylight;
    TimeSpan totalTime;
    public String timestring;

    public delegate void Dusk();
    public Dusk DuskCaller;
    public delegate void Dawn();
    public Dusk DawnCaller;
    bool day = false;
    public static DayCicle instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mylight = GetComponent<Light>();
        DuskCaller += GoodDay;
        DawnCaller += GoodNight;
    }
    // Update is called once per frame
    void Update()
    {

        dayseconds += Time.deltaTime* dayspeed;
        totalTime = TimeSpan.FromSeconds(dayseconds);
        timestring = totalTime.ToString();
        anglight = ((float)dayseconds / (84600 / 2)) * 180 -90;
        intensity = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down)+0.35f);
        mylight.intensity = intensity;
        transform.rotation = Quaternion.Euler(anglight, -30, 0);

        if (intensity > 0.3f && !day) {
            day = true;
            DuskCaller();
        }
        if (intensity < 0.3f && day) {
            day = false;
            DawnCaller();
        }

        RenderSettings.ambientLight = skylight.Evaluate(intensity);
        RenderSettings.fogDensity = 0.001f * intensity;

    }

    void GoodDay()
    {
        print("Good Day");
    }
    void GoodNight()
    {
        print("Good Night");
    }
}
