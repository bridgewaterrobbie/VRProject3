using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float speed;
    public CardboardHead head;
    private float holdTime;
    private bool jumping;
    private bool colliding;
    private bool freeCam;

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if(Time.time - holdTime >= 1)
            jumping = false;
        colliding = true;
    }
    
    void OnCollisionExit(Collision other)
    {
        if(jumping)
            colliding = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire3"))
            freeCam = !freeCam;

        if (freeCam)
        {
            jumping = false;
            GetComponent<Rigidbody>().useGravity = false;
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

		if(Input.GetButton("Jump") && freeCam)
        {
            transform.Translate(0, 5 * Time.deltaTime, 0);
        }

		if (Input.GetButtonDown("Jump") && !jumping && !freeCam)
        {
            jumping = true;
            holdTime = Time.time;
        }
        if(jumping && Time.time - holdTime < .4)
        {
            transform.Translate(0, 6 * Time.deltaTime, 0);
        }
        else
        {
            jumping = false;
        }
        //if(!jumping && !colliding && !freeCam)
        //{
        //    transform.Translate(0, -3 * Time.deltaTime, 0);
        //}

        float transForward = Input.GetAxis("Vertical");
        float transSide = Input.GetAxis("Horizontal");

        Vector3 dir = head.Gaze.direction;
        if (transSide > 0)
            dir = new Vector3(dir.z, 0, -dir.x);
        else if (transSide < 0)
            dir = new Vector3(-dir.z, 0, dir.x);
        else
            dir = new Vector3(0, 0, 0);

        Vector3 dir2 = head.Gaze.direction;
        if(!freeCam)
        {
            dir2 = new Vector3(dir2.x, 0, dir2.z);
            transform.position += speed * transForward * dir2 * Time.deltaTime;
        }
        else
            transform.position += speed * transForward * head.Gaze.direction * Time.deltaTime;

        transform.position += speed * .5f * dir * Time.deltaTime;
    }
}
