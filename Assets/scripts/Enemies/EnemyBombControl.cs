using UnityEngine;
using System.Collections;

public class EnemyBombControl : MonoBehaviour {


	public GameObject coin;
	
	public Transform player;
	
	public float timeToBomb;
	
	public float timePass;
	
	public GameObject bomb;

	Animator animator;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (player.position.x - transform.position.x) < 30) {
			timePass += Time.deltaTime;
			if(timePass > timeToBomb) {
				animator.SetTrigger("throw"); 
				timePass = 0;
			}
		}
	}

	//This method will be called for behaviour when the animation of throw bomb ends
	public void ThrowBomb() {
		GameObject newBomb = Instantiate(bomb,  new Vector2(transform.position.x - 0.8f, transform.position.y + 0.3f), Quaternion.Euler(0, 180, 0)) as GameObject; 
		newBomb.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-100,100));
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
