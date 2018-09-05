using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

	private int pos = -4;

	void Start()
	{
		transform.position = new Vector3 (pos, pos, pos);
	}

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		if (Input.GetKeyDown(KeyCode.C))
		{
			pos++;
			transform.position = new Vector3 (pos, pos, pos);
		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			pos--;
			transform.position = new Vector3 (pos, pos, pos);
		}
    }
}
