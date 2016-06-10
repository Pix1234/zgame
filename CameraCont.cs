using UnityEngine;
using System.Collections;
//[ZppixFix] using RootMotion.FinalIK;

public class CameraCont : MonoBehaviour 
{
    //[ZppixFix]public AimIK ik;
    //[ZppixFix]public FullBodyBipedIK BodyIK;

    public Transform target; 
	public Transform FPStarget;
    public Transform AIMtarget;

    public Transform gun;
    public Transform gunTarget;

    public Transform HipAimPosition;

    public Quaternion PosQuaternion;

	public Vector3 HeadAjusterVector;


    public float FOWChangeSpeed;

	//3rd Person Floats
	public float targetHeight = 2.0f; 
	public float distance = 2.8f; 
	public float maxDistance = 10f; 
	public float minDistance = 0.5f; 
	public float xSpeed = 250.0f; 
	public float ySpeed = 120.0f; 
	public float yMinLimit = -40f; 
	public float yMaxLimit = 80f; 
	public float zoomRate = 20f; 
	public float rotationDampening = 3.0f;
	private float x = 0.0f; 
	private float y = 0.0f;
    private float NormalizedZ;

	//1st Person Floats
	public float CamX;
	public float CamY;
	public float CamZ;


	private RaycastHit hit;

	public bool CanMove = true;
	public bool CanZoom = true;
	public bool FirstAndThirdToggle;
    public bool Aiming = false;
    public bool TrueAiming;

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;
	float rotationX = 0F;
    



    void Start () 
	{ 
		
		Vector3 angles = transform.eulerAngles; 
		
		x = angles.y;
		y = angles.x;

        //[ZppixFix]ik.solver.OnPostUpdate += AfterIK;

    }



    void LateUpdate () 
	{

        if (FirstAndThirdToggle == true)
        {

            if (!target)

                return;

            if (CanMove == true)
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }

            

                if (CanZoom == true)
                {
                    distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
                }

            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            y = ClampAngle(y, yMinLimit, yMaxLimit);



            // ROTATE CAMERA

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            transform.rotation = rotation;



            // POSITION CAMERA

            Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -targetHeight, 0));

            transform.position = position;



            // VIEW BLOCK

            Vector3 trueTargetPosition = target.transform.position - new Vector3(0, -targetHeight, 0);

            if (Physics.Linecast(trueTargetPosition, transform.position, out hit))
            {
                float tempDistance = Vector3.Distance(trueTargetPosition, hit.point) - 0.28f;
                position = target.position - (rotation * Vector3.forward * tempDistance + new Vector3(0, -targetHeight, 0));
                transform.position = position;
            }
        }
    }



    // Called by AimIK each time it is done updating
    void AfterIK()
    {

        

        if (Aiming == true)
        {
            if (TrueAiming == true)
            {
                GameObject g = target.GetComponent<WeaponsManager>().GetInHandsWeaponObject();
                float MaxAimFOW = target.GetComponent<Stats>().ItemDB.GetComponent<WeaponDatabase>().weapons[target.GetComponent<WeaponsManager>().GetInHandsWeaponID()].weaponAimFieldOfView;

                //AIMtarget.transform.SetParent(g.transform);
                AIMtarget.position = target.GetComponent<WeaponsManager>().GetInHandsWeaponObject().GetComponent<WeaponSetup_Hands>().CameraPosition.transform.position;

                if (MaxAimFOW > 60)
                {
                    if (gameObject.GetComponent<Camera>().fieldOfView < MaxAimFOW)
                    {
                        gameObject.GetComponent<Camera>().fieldOfView += FOWChangeSpeed * Time.deltaTime;
                    }
                    if (gameObject.GetComponent<Camera>().fieldOfView > MaxAimFOW)
                    {
                        gameObject.GetComponent<Camera>().fieldOfView = MaxAimFOW;
                    }
                }
                else if (MaxAimFOW < 60)
                {
                    if (gameObject.GetComponent<Camera>().fieldOfView > MaxAimFOW)
                    {
                        gameObject.GetComponent<Camera>().fieldOfView -= FOWChangeSpeed * Time.deltaTime;
                    }
                    if (gameObject.GetComponent<Camera>().fieldOfView < MaxAimFOW)
                    {
                        gameObject.GetComponent<Camera>().fieldOfView = MaxAimFOW;
                    }
                }
                else
                {
                    gameObject.GetComponent<Camera>().fieldOfView = 60;
                }

                transform.position = AIMtarget.position;
            }
            else
            {
                
                float MaxAimFOW = target.GetComponent<Stats>().ItemDB.GetComponent<WeaponDatabase>().weapons[target.GetComponent<WeaponsManager>().GetInHandsWeaponID()].weaponAimFieldOfView;

                //AIMtarget.transform.SetParent(g.transform);

                if (MaxAimFOW > 60)
                {
                    if (gameObject.GetComponent<Camera>().fieldOfView < MaxAimFOW)
                    {
                        gameObject.GetComponent<Camera>().fieldOfView += FOWChangeSpeed * Time.deltaTime;
                    }
                    if (gameObject.GetComponent<Camera>().fieldOfView > MaxAimFOW)
                    {
                        gameObject.GetComponent<Camera>().fieldOfView = MaxAimFOW;
                    }
                }
                else if (MaxAimFOW < 60)
                {
                    if (gameObject.GetComponent<Camera>().fieldOfView > MaxAimFOW)
                    {
                        gameObject.GetComponent<Camera>().fieldOfView -= FOWChangeSpeed * Time.deltaTime;
                    }
                    if (gameObject.GetComponent<Camera>().fieldOfView < MaxAimFOW)
                    {
                        gameObject.GetComponent<Camera>().fieldOfView = MaxAimFOW;
                    }
                }
                else
                {
                    gameObject.GetComponent<Camera>().fieldOfView = 60;
                }

                transform.position = HipAimPosition.position;
            }
            
        }
        else
        {



            if (gameObject.GetComponent<Camera>().fieldOfView > 60)
            {
                gameObject.GetComponent<Camera>().fieldOfView -= FOWChangeSpeed * Time.deltaTime;

                if (gameObject.GetComponent<Camera>().fieldOfView < 60)
                {
                    gameObject.GetComponent<Camera>().fieldOfView = 60;
                }
            }
            else if (gameObject.GetComponent<Camera>().fieldOfView < 60)
            {
                gameObject.GetComponent<Camera>().fieldOfView += FOWChangeSpeed * Time.deltaTime;

                if (gameObject.GetComponent<Camera>().fieldOfView > 60)
                {
                    gameObject.GetComponent<Camera>().fieldOfView = 60;
                }
            }

            
            transform.position = FPStarget.position;
            
            
        }
    }
    

    // Clean up the delegate
    void OnDestroy()
    {
        //[ZppixFix]if (ik != null) ik.solver.OnPostUpdate -= AfterIK;
    }


    void Update ()
    {
        
        FirstAndThirdToggle = target.GetComponent<MovementController>().FirstAndThirdToggle;
        if (FirstAndThirdToggle == false)
        {
            if (CanMove == true)
            {
                if (Aiming == false)
                {
                    rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


                }
                else
                {
                    rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

                    
                }
                
            }
            /*if (Aiming == true)
            {
                transform.position = AIMtarget.position;
            }
            else
            {
                transform.position = FPStarget.position;
            }*/

            sensitivityX = 2;
            sensitivityY = 2;

            target.gameObject.GetComponent<MovementController>().turnSpeed = 0.1f;
        }
        else
        {
            sensitivityX = 5;
            sensitivityY = 5;
            target.gameObject.GetComponent<MovementController>().turnSpeed = 0.1f;
        }
		

	}  
    
	static float ClampAngle (float angle,float min, float max) 
	{ 
		if (angle < -360) 
			angle += 360; 
		
		if (angle > 360) 
			angle -= 360; 
		
		return Mathf.Clamp (angle, min, max); 
	}
}
