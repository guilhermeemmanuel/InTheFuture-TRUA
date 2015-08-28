using UnityEngine;
using System.Collections;

public class EnemyBombControl : MonoBehaviour {


	public GameObject coin;
	
	public Transform player;
	
	public float timeToBomb;
	
	public float timePass;
	
	public GameObject bomb;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (player.position.x - transform.position.x) < 30) {
			timePass += Time.deltaTime;
			if(timePass > timeToBomb) {
				Instantiate(bomb,  new Vector2(transform.position.x + 1, transform.position.y + 0.5f), Quaternion.Euler(0, 180, 0)); 
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
