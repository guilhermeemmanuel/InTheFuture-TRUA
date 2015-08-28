using UnityEngine;
using System.Collections;

public class PlayerMapControl : MonoBehaviour {

	bool stop = true;

	public static LocationControl location;
	public LocationControl inicialLocation;

	int x;
	int y;


	public static float posX;
	public static float posY;

	// Use this for initialization
	void Start () {
		if (location == null) {
			location = inicialLocation;
		}
		transform.position = new Vector3 (posX, posY, -2);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!stop) {
			Vector2 movimento = new Vector2 (x, y) * 3 * Time.deltaTime;
			transform.Translate (movimento);
		} else {

			if (Input.GetButtonDown ("Fire1")) {
				Application.LoadLevel(location.phase);
			}

			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");
			if(horizontal != 0) {
				if(horizontal > 0 && location.moveRight) {
					x = 1;
					y = 0;
					stop = false;
				}
				else if (horizontal < 0 && location.moveLeft) {
					x = -1;
					y = 0;
					stop = false;
				}

			} else if(vertical != 0) {
				if(vertical > 0 && location.moveUp) {
					y = 1;
					x = 0;
					stop = false;
				}
				else if (vertical < 0 && location.moveDown) {
					y = -1;
					x = 0;
					stop = false;
				}
			}
		}


	}

	void OnTriggerEnter2D( Collider2D col) {
		stop = true;
		transform.position = new Vector3 (col.transform.position.x, col.transform.position.y, -2) ;
		location = col.gameObject.GetComponent<LocationControl> ();
		posX = col.transform.position.x;
		posY = col.transform.position.y;
	}
}
