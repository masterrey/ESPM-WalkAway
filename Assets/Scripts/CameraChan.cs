using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChan : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public float height;
    public float ajust;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = player.transform.position - transform.position;
        Vector3 mygoto = player.transform.position - player.transform.forward * distance + Vector3.up * height;

        RaycastHit hit;
        if(Physics.Raycast(player.transform.position+ Vector3.up * height, player.transform.forward * (-distance) + Vector3.up * height,out hit, 10))
        {
            mygoto = hit.point+hit.normal*ajust;
        }

       
        transform.rotation = Quaternion.LookRotation(dir + Vector3.up * height);

        transform.position = Vector3.Lerp(transform.position,mygoto,Time.smoothDeltaTime);
    }
}
