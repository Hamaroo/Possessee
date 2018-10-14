using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {
    Rigidbody rb;
    public float speed = 10;
    public float x, z;
    public GameObject posessee;

    public Transform cam;

	// Use this for initialization
	void Start () {
        rb = GetComponentInParent<Rigidbody>();
        reconstructSoul();

	}

    void reconstructSoul() {
        posessee = transform.parent.gameObject;
        transform.localPosition = new Vector3(0, 0, 0);
        rb = GetComponentInParent<Rigidbody>();
        Debug.Log("switched");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(posessee != transform.parent.gameObject) {
            reconstructSoul();
        }

        if (Input.GetAxisRaw("Change Camera") > 0) {
            //switch to other camera

        }
        else {
            float horiz = Input.GetAxis("Horizontal");
            float verti = Input.GetAxis("Vertical");

            x = horiz;
            z = verti;

            horiz *= speed;
            verti *= speed;

            Vector3 forward = cam.forward;
            forward.y = 0;

            Vector3 right = cam.right;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            Vector3 gravity = new Vector3(0, rb.velocity.y, 0);

            Vector3 force = forward * verti + cam.right.normalized*horiz + gravity;
            rb.velocity = force;
        }
        

	}
}
