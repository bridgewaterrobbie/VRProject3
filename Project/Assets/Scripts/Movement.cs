using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float speed;
    public CardboardHead head;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float transForward = Input.GetAxis("Vertical");
        float transSide = Input.GetAxis("Horizontal");

        Vector3 dir = head.Gaze.direction;
        if (transSide > 0)
            dir = new Vector3(dir.z, 0, -dir.x);
        else if (transSide < 0)
            dir = new Vector3(-dir.z, 0, dir.x);
        else
            dir = new Vector3(0, 0, 0);

        transform.position += speed * transForward * head.Gaze.direction * Time.deltaTime;
        transform.position += speed * dir * Time.deltaTime;
    }
}
