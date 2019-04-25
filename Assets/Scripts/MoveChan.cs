using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChan : MonoBehaviour
{
    CharacterController ctrl;
    Animator anim;
    Vector3 inputCtrl;
    Vector3 inputRotCtrl;
    void Start()
    {
        ctrl = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputCtrl = new Vector3(0, 0, Input.GetAxis("Vertical"));
        inputRotCtrl = new Vector3(0,Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        ctrl.SimpleMove(transform.TransformDirection(inputCtrl*3));
        anim.SetFloat("Speed", ctrl.velocity.magnitude);
        transform.Rotate(inputRotCtrl);
    }
}
