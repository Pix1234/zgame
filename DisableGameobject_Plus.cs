using UnityEngine;
using System.Collections;

public class DisableGameobject_Plus : MonoBehaviour 
{

	public GameObject obj1;
	public GameObject obj2;
	
	
	void DisableObject()
	{
		obj1.SetActive (false);
		obj2.SetActive (false);
	}
}
