using UnityEngine; 
using System.Collections;

public class playInstrumentAnim : MonoBehaviour {

	public GameObject theInstrument;
	private Light theLight;

	//blah blah blah

	// Use this for initialization
	void Start () {
		//theLight = theInstrument.GetComponent<Light> ();
		theLight = theInstrument.GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (theInstrument.name == "FXTable") {
			if (!theInstrument.GetComponent<AudioSource> ().mute) {
				theLight.enabled = true;
			} else {
				theLight.enabled = false;
			}
		}
		else if (!theInstrument.GetComponent<AudioSource> ().mute) {
			theInstrument.GetComponent<Animation> ().Play ();
			theLight.enabled = true;
		} else {
			theInstrument.GetComponent<Animation> ().Stop();
			theLight.enabled = false;
		}
	}
}
