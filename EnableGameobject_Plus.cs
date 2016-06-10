using UnityEngine;
using System.Collections;

public class EnableGameobject_Plus : MonoBehaviour 
{

	public GameObject obj;

	
	void EnableObject()
	{
		if(gameObject.GetComponent<ItemCollisionDetection>().Good == false)
		{
			obj.SetActive (true);
		}
	}
}
