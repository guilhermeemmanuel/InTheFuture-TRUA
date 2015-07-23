using UnityEngine;
using System.Collections;

public class ControlCam : MonoBehaviour {
	
	public Transform target;
	public Transform marginLeft;
	public Transform marginRight;
	
	//private float margemUpY;
	//private float margemDownY;

	private float margem;

	
	// Use this for initialization
	void Start ()  {
		//margemUpY = float.MaxValue;
		//margemDownY = float.MinValue;
	}
	
	// Update is called once per frame
	void Update () {
		float novoX = Mathf.Clamp(target.position.x, marginLeft.position.x, marginRight.position.x);
		float novoY = target.position.y+2.5f;
		transform.position = new Vector3 (novoX, novoY, transform.position.z);

	}
	

	

}
