using UnityEngine;
using System.Collections;

public class EnemyShotControl : MonoBehaviour {

	public GameObject coin;

	public Transform player;

	public float timeToShot;

	public float timePass;

	public GameObject shot;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (player.position.x - transform.position.x) < 30) {
			timePass += Time.deltaTime;
			if(timePass > timeToShot) {
				Instantiate(shot,  new Vector2(transform.position.x - 0.7f, transform.position.y + 0.5f), Quaternion.Euler(0, 180, 0)); 
				timePass = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Bullet" ) {
			GameObject c = Instantiate(coin) as GameObject;
			c.transform.position = transform.position; 
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}

}
