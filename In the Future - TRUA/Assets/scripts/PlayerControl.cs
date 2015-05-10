using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float velocidade;
	public float forcaPulo;
	public bool noChao;
	public Transform player;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "chao") {
			animator.SetBool("noChao",true);
			animator.SetBool("pulando",false);
		}
	}


	private void move() {
		horizontal ();
		vertical ();
	}
	private void horizontal ()	{
		float axis = Input.GetAxis ("Horizontal");
		if (axis > 0) {
			transform.eulerAngles = new Vector2 (0, 0);
			Vector2 movimento = new Vector2 (axis, 0) * velocidade * Time.deltaTime;
			transform.Translate (movimento);
			animator.SetBool ("correndo",true);
			animator.SetBool ("parado",false);
		}
		else
		if (axis < 0) {
			transform.eulerAngles = new Vector2 (0, 180);
			// tem que botar o - pq ele aqui, como vira o boneco, inverte o eixo X
			Vector2 movimento = new Vector2 (-axis, 0) * velocidade * Time.deltaTime;
			transform.Translate (movimento);
			animator.SetBool ("correndo",true);
			animator.SetBool ("parado",false);
		}
		else {
			animator.SetBool ("parado",true);
			animator.SetBool ("correndo",false);
		}
	}

	private void vertical() {
		if (Input.GetButtonDown("Jump") && !animator.GetBool("pulando")) {
			//player.getComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
			//animator.SetBool("pulando", true);
			//animator.SetBool("noChao",false);
		}

	}
}
