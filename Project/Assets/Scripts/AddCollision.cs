using UnityEngine;
using System.Collections;

public class AddCollision : MonoBehaviour {

	// Use this for initialization
	void Awake()
    {
        addCollider(transform);
    }

    void addCollider(Transform g)
    {
        if(g.GetComponent<MeshFilter>())
            g.gameObject.AddComponent<MeshCollider>();

        foreach (Transform t in g){
            addCollider(t);
        }
    }
}
