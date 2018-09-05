using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSpawner : MonoBehaviour {

	public int length = 1;
	public GameObject PointPrefab;

	public void ChangeLength (string Text)
	{
		length = int.Parse(Text);
	}

	void SpawnGrid ()
	{
		for (int x = 0; x < length; x++)
		{
			for (int y = 0; y < length; y++)
			{
				for (int z = 0; z < length; z++)
				{
					Instantiate(PointPrefab, new Vector3(x, y, z), Quaternion.identity);
				}
			}
		}
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			SpawnGrid();
		}
	}
}
