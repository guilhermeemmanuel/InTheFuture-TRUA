using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float velocidade;
	public float forcaPulo;
	public bool noChao;
	public Transform player;
	private Animator animator;

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		move ();

		if (Input.GetButtonDown ("Fire1")) {
			GameObject b = Instantiate(bullet) as GameObject;
			b.transform.eulerAngles = transform.eulerAngles;
			b.transform.position = transform.position;

		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "chao")  {
			animator.SetBool("noChao",true);
			animator.SetBool("pulando",false);
		}
		else if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Coin")  {
			Destroy(col.gameObject);
			InventoryControl.coins += 1 ;
		} else if (col.gameObject.tag == "EndPhase") {
			Application.LoadLevel ("map");
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
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,600));
			animator.SetBool("pulando", true);
			animator.SetBool("noChao",false);
		}

	}
}
