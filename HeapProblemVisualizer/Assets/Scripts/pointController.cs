using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointController : MonoBehaviour {

	public bool isWinningPosition = true;

	private GameObject[] Points;

	void Start () 
	{
		Points = GameObject.FindGameObjectsWithTag("Point");

		foreach (GameObject P in Points)
		{
			if (P.transform.position.x == this.transform.position.x && P.transform.position.y == this.transform.position.y && P.transform.position.z < this.transform.position.z && P.GetComponent<pointController>().isWinningPosition)
			{
				isWinningPosition = false;
			}

			if (P.transform.position.x == this.transform.position.x && P.transform.position.z == this.transform.position.z && P.transform.position.y < this.transform.position.y && P.GetComponent<pointController>().isWinningPosition)
			{
				isWinningPosition = false;
			}

			if (P.transform.position.y == this.transform.position.y && P.transform.position.z == this.transform.position.z && P.transform.position.x < this.transform.position.x && P.GetComponent<pointController>().isWinningPosition)
			{
				isWinningPosition = false;
			}
		}

		if (isWinningPosition)
		{
			this.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
		}
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.T) && !isWinningPosition)
		{
			this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
		}
	}
}
