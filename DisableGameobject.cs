using UnityEngine;
using System.Collections;

public class DisableGameobject : MonoBehaviour 
{
	public GameObject obj;

	void DisableObject()
	{
		obj.SetActive (false);
	}
}
