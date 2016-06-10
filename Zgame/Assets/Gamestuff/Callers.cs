using UnityEngine;
using System.Collections;

public class Callers : MonoBehaviour 
{
	public GameObject boxPrefab;

	public void InstantiateBox()
	{
		GameObject copy = (GameObject)Instantiate(boxPrefab, transform.position, Quaternion.identity);
		copy.GetComponent<TestBoxScript> ().varToAssign = gameObject;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			InstantiateBox();
		}
	}
}
