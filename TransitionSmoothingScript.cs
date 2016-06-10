using UnityEngine;
using System.Collections;

public class TransitionSmoothingScript : MonoBehaviour 
{
	//Smoothing for X

	public float TransSmootherX;
	public float TransHelperX;
	public float TransSpeedX;

	//Smoothing for Y
	
	public float TransSmootherY;
	public float TransHelperY;
	public float TransSpeedY;

	void Update () 
	{
		/////////////////////////////////
		/////////	FOR X		//////////
		/////////////////////////////////
		if (TransHelperX > 1)
		{
			TransHelperX = 1;
		}
		else if (TransHelperX < -1)
		{
			TransHelperX = -1;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			
			TransHelperX += TransSpeedX;
			TransSmootherX = Mathf.Clamp(TransHelperX, -1, 1);
		}
		else if (Input.GetKey (KeyCode.A)) 
		{
			TransHelperX -= TransSpeedX;
			TransSmootherX = Mathf.Clamp(TransHelperX, -1, 1);
		}
		else
		{
			if(TransHelperX == 0)
			{
				
			}
			else if(TransHelperX > 0.1)
			{
				TransHelperX -= TransSpeedX;
				TransSmootherX = Mathf.Clamp(TransHelperX, -1, 1);
			}
			else if(TransHelperX < -0.1)
			{
				TransHelperX += TransSpeedX;
				TransSmootherX = Mathf.Clamp(TransHelperX, -1, 1);
			}
			if(TransHelperX < 0.1 && TransHelperX > -0.1)
			{
				TransSmootherX = 0;
			}
		}
		/////////////////////////////////
		/////////	FOR Y		//////////
		/////////////////////////////////

		if (TransHelperY > 1)
		{
			TransHelperY = 1;
		}
		else if (TransHelperY < -1)
		{
			TransHelperY = -1;
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			
			TransHelperY += TransSpeedY;
			TransSmootherY = Mathf.Clamp(TransHelperY, -1, 1);
		}
		else if (Input.GetKey (KeyCode.S)) 
		{
			TransHelperY -= TransSpeedY;
			TransSmootherY = Mathf.Clamp(TransHelperY, -1, 1);
		}
		else
		{
			if(TransHelperY == 0)
			{

			}
			else if(TransHelperY > 0.1)
			{
				TransHelperY -= TransSpeedY;
				TransSmootherY = Mathf.Clamp(TransHelperY, -1, 1);
			}
			else if(TransHelperY < -0.1)
			{
				TransHelperY += TransSpeedY;
				TransSmootherY = Mathf.Clamp(TransHelperY, -1, 1);
			}
			if(TransHelperY < 0.1 && TransHelperY > -0.1)
			{
				TransSmootherY = 0;
			}
		}
	}
}
