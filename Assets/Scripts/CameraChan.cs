using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChan : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public float height;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = player.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(dir + Vector3.up * height);

        transform.position = Vector3.Lerp(transform.position,
            player.transform.position - player.transform.forward*distance + Vector3.up*height,Time.smoothDeltaTime);
    }
}
