using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movimento = new Vector2 (1, 0) * 10 * Time.deltaTime;
		transform.Translate (movimento);
	}
}
