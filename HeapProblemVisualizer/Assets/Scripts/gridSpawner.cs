using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSpawner : MonoBehaviour {

	public int length = 1;
	public GameObject PointPrefab;

	private GameObject Prnt;
	private GameObject PointHandle;

	private GameObject[] PointsHandle;

	public void ChangeLength (string Text)
	{
		length = int.Parse(Text);
	}

	void SpawnGrid ()
	{
		Prnt.transform.rotation = Quaternion.identity;
		Prnt.transform.position = new Vector3 (length/2.0f, length/2.0f, length/2.0f);

		// for (int x = 0; x < 1; x++)
		// {
		// 	for (int y = 0; y < 1; y++)
		// 	{
		// 		for (int z = 0; z < 1; z++)
		// 		{
		// 			PointHandle = Instantiate(PointPrefab, new Vector3(x, y, z), Quaternion.identity);
		// 		}
		// 	}
		// }

		// Destroy(PointHandle);

		for (int x = 0; x < length; x++)
		{
			for (int y = 0; y < length; y++)
			{
				for (int z = 0; z < length; z++)
				{
					PointHandle = Instantiate(PointPrefab, new Vector3(x, y, z), Quaternion.identity);
					PointHandle.transform.parent = Prnt.transform;
				}
			}
		}
	}

	void Start ()
	{
		Prnt = GameObject.FindWithTag("Parent");
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			PointsHandle = GameObject.FindGameObjectsWithTag("Point");

			foreach (GameObject P in PointsHandle)
			{
				Destroy(P);
			}

			SpawnGrid();
		}
	}
}
