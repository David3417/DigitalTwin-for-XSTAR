using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examination : MonoBehaviour {
	Renderer m_Renderer;

	// Use this for initialization
	void Start () {

		m_Renderer = GetComponent<Renderer> ();
		m_Renderer.material.SetColor ("_Color", Color.green);

	}

	// Update is called once per frame
	void Update () {

		ProcessGaze();

	}

	public void ProcessGaze()
	{

		Ray raycastRay = new Ray(transform.position, transform.forward);
		RaycastHit hitInfo;

		Debug.DrawRay(raycastRay.origin, raycastRay.direction * 100);


		if (Physics.Raycast(raycastRay, out hitInfo))
		{
			// Do something to the object 
		}
	}

}