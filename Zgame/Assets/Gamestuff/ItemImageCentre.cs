using UnityEngine;
using System.Collections;

public class ItemImageCentre : MonoBehaviour
{
    
	void Update ()
    {
        transform.position = transform.parent.position;
	}
}
