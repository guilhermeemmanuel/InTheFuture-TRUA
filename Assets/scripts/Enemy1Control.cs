using UnityEngine;
using System.Collections;

public class Enemy1Control : MonoBehaviour {

	private int walk = 0;
	private int side;


	public GameObject coin;

	public Transform player;


	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Bullet" ) {
			GameObject c = Instantiate(coin) as GameObject;
			c.transform.position = transform.position; 
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (player.position.x - transform.position.x) < 30) {
			if (walk == 0) {
				side = Random.Range (0, 2);
				walk = 100;
			}
			if (side == 0) {
				transform.eulerAngles = new Vector2 (0, 0);
				Vector2 movimento = new Vector2 (1, 0) * 3 * Time.deltaTime;
				transform.Translate (movimento);
				walk--;
			} else {
				transform.eulerAngles = new Vector2 (0, 180);
				// tem que botar o - pq ele aqui, como vira o boneco, inverte o eixo X
				Vector2 movimento = new Vector2 (1, 0) * 3 * Time.deltaTime;
				transform.Translate (movimento);
				walk--;
			}
		}

	}
}
