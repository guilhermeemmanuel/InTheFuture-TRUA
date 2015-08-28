using UnityEngine;
using System.Collections;

public class BombControl : MonoBehaviour {

	Animator animator;

	public float timeToDestroy;

	public float timePass;

	// Use this for initialization
	void Start () {
		//FIXME Isso deveria ser feito pelo objeto que cria a bomba
		GetComponent<Rigidbody2D> ().AddForce (new Vector2(100,100));
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		timePass += Time.deltaTime;
		if (timePass > timeToDestroy) {
			animator.SetBool("explode", true);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player")  {
			animator.SetBool("explode", true);
			col.gameObject.GetComponent<PlayerControl>().Exploded(30);
		}

	}

}
