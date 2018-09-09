using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSpawner : MonoBehaviour {

	public int length = 1;
	public GameObject PointPrefab;

	private GameObject Prnt;
	private GameObject PointHandle;

	private GameObject[] PointsHandle;

	public bool[,,] GridDemo;
	private int xx = 0;
	private int yy = 0;
	private int zz = 0;

	public void ChangeLength (string Text)
	{
		length = int.Parse(Text);

		CalculateGrid();
	}

	void CalculateGrid ()
	{
		GridDemo = new bool[length, length, length];

		for (int x = 0; x < length; x++)
		{
			for (int y = 0; y < length; y++)
			{
				for (int z = 0; z < length; z++)
				{
					GridDemo[x,y,z] = true;
					
					xx = 0;
					yy = 0;
					zz = 0;
					while (xx <= x && GridDemo[x,y,z])
					{
						while (yy <= y && GridDemo[x,y,z])
						{
							while (zz <= z && GridDemo[x,y,z])
							{
								if ((xx != x && yy == y && zz == z) || (xx == x && yy != y && zz == z) || (xx == x && yy == y && zz != z))
								{
									if (GridDemo[xx,yy,zz])
									{	
										GridDemo[x,y,z] = false;
									}
								}

								zz++;
							}

							yy++;
						}

						xx++;
					}
				}
			}
		}
	}

	void SpawnGrid ()
	{
		Prnt.transform.rotation = Quaternion.identity;
		Prnt.transform.position = new Vector3 (length/2.0f, length/2.0f, length/2.0f);

		for (int x = 0; x < length; x++)
		{
			for (int y = 0; y < length; y++)
			{
				for (int z = 0; z < length; z++)
				{
					PointHandle = Instantiate(PointPrefab, new Vector3(x, y, z), Quaternion.identity);
					PointHandle.GetComponent<pointController>().isWinningPosition = GridDemo[x,y,z];
					PointHandle.transform.parent = Prnt.transform;
				}
			}
		}
	}

	void Start ()
	{
		Prnt = GameObject.FindWithTag("Parent");

		CalculateGrid();
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
