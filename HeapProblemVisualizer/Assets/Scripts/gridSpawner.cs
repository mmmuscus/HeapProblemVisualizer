using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSpawner : MonoBehaviour {

	public int length = 0;
	public GameObject PointPrefab;

	public void ChangeLength (string Text)
	{
		length = int.Parse(Text);
		Debug.Log(length);
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

	void Start () 
	{
		SpawnGrid();
	}
	
	void Update () 
	{
		
	}
}
