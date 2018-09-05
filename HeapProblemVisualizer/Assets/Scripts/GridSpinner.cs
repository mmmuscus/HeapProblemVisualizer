using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpinner : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	if (Input.GetKey(KeyCode.W))
    	transform.Rotate(Vector3.up * speed * Time.deltaTime);
      
  	if (Input.GetKey(KeyCode.S))
		transform.Rotate(-Vector3.up * speed * Time.deltaTime);	

	if (Input.GetKey(KeyCode.D))
    	transform.Rotate(Vector3.right * speed * Time.deltaTime);
      
  	if (Input.GetKey(KeyCode.A))
		transform.Rotate(-Vector3.right * speed * Time.deltaTime);	
	}
}
