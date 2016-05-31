using UnityEngine;
using System.Collections;

public class ActionTeller : MonoBehaviour 
{
	public int wantedAction;
	public GameObject itemMainParent;

	void SetAction()
	{
		itemMainParent.GetComponent<ItemFunctionFoundation> ().actionID = wantedAction;
	}
}
