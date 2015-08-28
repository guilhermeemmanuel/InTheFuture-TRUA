using UnityEngine;
using System.Collections;

public class OpeningCamControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);

	}
}
