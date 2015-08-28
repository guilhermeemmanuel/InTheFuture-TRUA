using UnityEngine;
using System.Collections;

public class BombControl : MonoBehaviour {

	Animator animator;

	public float timeToDestroy;

	float timePass;

	public int bombDamage;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		timePass += Time.deltaTime;
		if (timePass > timeToDestroy) {
			GetComponent<Rigidbody2D>().gravityScale = 0;
			GetComponent<CircleCollider2D>().isTrigger = true;
			animator.SetBool("explode", true);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player")  {
			animator.SetBool("explode", true);
			col.gameObject.GetComponent<PlayerControl>().Exploded(bombDamage);
		}

	}


}
