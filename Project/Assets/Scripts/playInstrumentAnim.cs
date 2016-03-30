using UnityEngine;
using System.Collections;

public class playInstrumentAnim : MonoBehaviour {

	public GameObject theInstrument;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!theInstrument.GetComponent<AudioSource> ().mute) {
			theInstrument.GetComponent<Animation> ().Play ();
		} else {
			theInstrument.GetComponent<Animation> ().Stop();
		}
	}
}
