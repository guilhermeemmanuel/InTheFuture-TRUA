using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float velocidade;
	public float forcaPulo;
	public bool noChao;
	public Transform player;
	private Animator animator;

	public GameObject bullet;

	bool moveLeft;
	bool moveRight;

	public UnityEngine.UI.Image goku; 


	public int easter;

	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Click")) {
			if(Input.mousePosition.y > 400) { 
				if(easter == 0 || easter == 1) {
					easter++;
					//print(easter);
				}

			}
			else if(Input.mousePosition.y < 200) {  
				if(easter == 2 || easter == 3) {
					easter++;
					//print(easter);
				}
			}

		}

		float horizontal = Input.GetAxis("Horizontal");
		if (moveLeft || horizontal < 0) {
			Move (180);
		} else if (moveRight || horizontal > 0) {
			Move (0);
		} else if (horizontal == 0) {
			//codigo para testes
			StopMoveLeft();
			StopMoveRight();
		}

		if (Input.GetButtonDown ("Jump")) {
			Jump();
		}

		if (Input.GetButtonDown ("Fire1")) {
			Fire();
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
		if (col.gameObject.tag == "Coin") {
			Destroy (col.gameObject);
			InventoryControl.coins += 1;
		} else if (col.gameObject.tag == "EndPhase") {
			Application.LoadLevel ("map");
		} else if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}



	public void Move(int angle) {
		transform.eulerAngles = new Vector2 (0, angle);
		Vector2 movimento = new Vector2 (1, 0) * velocidade * Time.deltaTime;
		transform.Translate (movimento);
		animator.SetBool ("correndo",true);
		animator.SetBool ("parado",false);
	}

	public void d() {
		goku.enabled = false;
	}

	public void Fire() {
		if (easter == 9) {
			easter++;
			//print(easter);
			goku.enabled = true;
			Invoke("d",2);  
			AudioSource gokuA = GetComponent<AudioSource>();
			gokuA.Play();
		}
		else {
			easter = 0;
			//print(easter);
		}
		GameObject b = Instantiate(bullet) as GameObject;
		b.transform.eulerAngles = transform.eulerAngles;
		b.transform.position = transform.position;
	}

	public void Jump() {
		if (easter == 8) {
			easter++;
			//print(easter);
		}
		else {
			easter = 0;
			//print(easter);
		}
		if (!animator.GetBool("pulando")) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,forcaPulo));
			animator.SetBool("pulando", true);
			animator.SetBool("noChao",false);
		}

	}

	public void StartMoveLeft() {
		if (easter == 4 || easter == 6) {
			easter++;
			//print(easter);
		}
		else {
			easter = 0;
			//print(easter);
		}
		moveLeft = true;
	}
	
	public void StopMoveLeft() {
		moveLeft = false;
		animator.SetBool ("parado",true);
		animator.SetBool ("correndo",false);
	}
	
	public void StartMoveRight() {
		if (easter == 5 || easter == 7) {
			easter++;
			//print(easter);
		}
		else {
			easter = 0;
			//print(easter);
		}
		moveRight = true;
	}
	
	public void StopMoveRight() {
		moveRight = false;
		animator.SetBool ("parado",true);
		animator.SetBool ("correndo",false);
	}

}
