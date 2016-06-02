using UnityEngine;
using System.Collections;

public class EnableGameobject : MonoBehaviour 
{
	public GameObject obj;
	
	void EnableObject()
	{
		obj.SetActive (true);
	}
}
