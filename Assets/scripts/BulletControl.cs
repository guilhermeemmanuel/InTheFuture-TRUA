using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	float passTime;

	public float timeToDestroy;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		passTime += Time.deltaTime;

		Vector2 movimento = new Vector2 (1, 0) * 10 * Time.deltaTime;
		transform.Translate (movimento);
		if (passTime >= timeToDestroy) {
			Destroy(gameObject);
		}
	}
}
