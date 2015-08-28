using UnityEngine;
using System.Collections;

public class ShootingControl : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			float mousex = (Input.mousePosition.x);
			float mousey = (Input.mousePosition.y);
			Vector2 mouseposition = Camera.main.ScreenToWorldPoint(new Vector2 (mousex,mousey));

			float angle = Vector2.Angle(mouseposition, new Vector2(1,0));
			print(angle);

			if(mouseposition.y <  0) {
				angle = -angle; 
			}

			//GameObject wave =  
			Instantiate(bullet,  new Vector2(0, 0), Quaternion.Euler(0, 0, angle)) 
			//as GameObject
			;

		}
	}
}
