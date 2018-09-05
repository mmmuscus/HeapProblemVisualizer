using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointController : MonoBehaviour {

	public bool isWinningPosition = true;
	private int transparency = 1;

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
		if (Input.GetKeyDown(KeyCode.R) && !isWinningPosition)
		{
			transparency++;

			if (transparency == 2)
			{
				transparency = 0;
			}

			this.GetComponent<Renderer>().material.color = new Color(1, 1, 1, transparency);
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
			if (transform.localScale == new Vector3 (0.4f, 0.4f, 0.4f))
			{
				transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			}
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
			if (transform.localScale == new Vector3 (1.1f, 1.1f, 1.1f))
			{
				transform.localScale = new Vector3 (1f, 1f, 1f);
			}
		}
	}
}
