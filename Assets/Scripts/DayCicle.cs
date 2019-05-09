using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour
{
    float dayseconds;
    float anglight;
    public float dayspeed=1;
    Light mylight;
    float intensity;
    // Start is called before the first frame update
    void Start()
    {
        mylight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        dayseconds += Time.deltaTime* dayspeed; 
        anglight = (dayseconds / (84600 / 2)) * 180 / Mathf.PI;
        intensity = Vector3.Dot(transform.forward, Vector3.down);
        mylight.intensity = intensity;
        transform.rotation = Quaternion.Euler(anglight, -30, 0);
    }
}
