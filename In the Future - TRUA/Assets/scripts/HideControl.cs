using UnityEngine;
using System.Collections;

public class HideControl : MonoBehaviour {

	public Transform player;
	public GameObject textura;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (entrou ());
		if (entrou ()) {
			textura.SetActive(false);
		} else {
			textura.SetActive(true);
		}
		
	}

	private bool entrou() {
		return verificaX() && verificaY();
	}

	private bool verificaX() {
		return player.position.x > transform.position.x;
	}

	private bool verificaY() {
		return (player.position.y > transform.position.y - 1f) && (player.position.y < transform.position.y + 7f);
	}
}
