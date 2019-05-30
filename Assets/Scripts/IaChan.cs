using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaChan : MonoBehaviour
{
    public Animator anim;
    int lives = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Hit"))
        {

            Vector3 dir = collision.transform.position - transform.position;
            transform.forward = new Vector3(dir.x, 0, dir.z);

            anim.SetTrigger("Hit");

            lives--;
            if (lives < 0)
            {
                anim.SetBool("Death",true);
                Destroy(GetComponent<Collider>());
                Destroy(GetComponent<Rigidbody>());
            }
        }
    }
}
