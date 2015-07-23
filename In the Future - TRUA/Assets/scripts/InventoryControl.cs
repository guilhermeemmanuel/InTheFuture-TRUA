using UnityEngine;
using System.Collections;

public class InventoryControl : MonoBehaviour {

	public static int coins;

	public UnityEngine.UI.Text coinsText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		coinsText.text = "Coins: " + coins.ToString ();
	}
}
