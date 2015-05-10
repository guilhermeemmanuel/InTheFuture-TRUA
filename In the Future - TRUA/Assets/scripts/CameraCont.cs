using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Transform target;
	private bool ignoraY = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float novoY = transform.position.y;
		if (!ignoraY) {
			novoY = target.position.y;
				}
		transform.position = new Vector3 (target.position.x, novoY, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log ("ooooooooooooooooooooooooooooo1");

		}

}
