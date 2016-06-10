using UnityEngine;
using System.Collections;
//[ZppixFix]using RootMotion.FinalIK;

public class MovementController : MonoBehaviour 
{
    public bool AimingTestBool;
    public float AnimationSpeed;
	public float FallDetMaxDist;
	public float FallDistance;
	public float FallSpeed;
	public float FallSpeedForward;
    public float angleVel;
    public float turnSpeed;
    public float AimTransitionSpeed;

    public bool TurnToCam;
	public bool CanLand;
	public bool CanFall;
	public bool IdleAnimPlayed;
	public bool AnimBesideWalkPlayed;
	public bool InteractMode;
    public bool FirstAndThirdToggle;



    public GameObject MC;
	public GameObject MyPauseMenu;
	public GameObject h;
    public GameObject CurrentStorage;

	private Vector3 FallDetRayDir;
	private Vector3 DistanceVector;

	public Transform TP;
	public Transform LastPos;
	public Transform CasterPosition;
	public Transform MainCamAcess;

	public Rigidbody rb;

    public Quaternion QE;

	public Animator animator;
	public AnimatorStateInfo currentBaseState;
    public WeaponsManager WM;

	public int walkState = Animator.StringToHash("Base Layer.WalkingLocomotion");
	public int runState = Animator.StringToHash("Base Layer.RunningLocomotion");
	public int sprintState = Animator.StringToHash("Base Layer.SprintLocomotion");
	public int rollLandState = Animator.StringToHash("Base Layer.RollLand");
	public int hardLandState = Animator.StringToHash("Base Layer.HardLand");
	public int easyLandState = Animator.StringToHash("Base Layer.EasyLand");
	public int fallingState = Animator.StringToHash("Base Layer.Falling");
	public int inventoryState = Animator.StringToHash("Base Layer.Inventory");
    public int turnState = Animator.StringToHash("Idle Legs Turn.Turn");


    protected void Start ()
	{
		animator = GetComponent<Animator>();

		rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        Update3DClick();
        UpdateInputs();
        UpdateAnimator();
        UpdateCursorLock();
        UpdateInventory();
        UpdateCamera();
        UpdateAimingSystem();
    }
    void FixedUpdate()
    {
        FixedUpdateAnimator();
        FixedUpdateFallDetection();
        UpdateCharacterRotation();

    }
    void UpdateCamera()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            FirstAndThirdToggle = !FirstAndThirdToggle;
        }
    }
    void UpdateCursorLock()
    {
        if (MyPauseMenu.GetComponent<PauseMenu>().PauseMenuGroup.active == true || gameObject.GetComponent<Stats>().inventoryOn == true || InteractMode == true)
        {
            Cursor.visible = true;
            Screen.lockCursor = false;
        }
        else
        {
            Cursor.visible = false;
            Screen.lockCursor = true;
        }
    }

    void Update3DClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit h;
        if (Physics.Raycast(MC.transform.position, ray.direction, out h))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (h.transform.gameObject.GetComponent<Pickup>() == true)
                {
                    if (currentBaseState.nameHash == inventoryState)
                    {
                        float distance = Vector3.Distance(h.transform.position, transform.position);
                        if (distance < 3f)
                        {
                            if (h.transform.gameObject.GetComponent<AmmoPickup>() == true)
                            {
                                gameObject.GetComponent<Stats>().InstantiateInventoryItemAmmo(h.transform.gameObject.GetComponent<Pickup>().GiveItemID, h.transform.gameObject);
                            }
                            else
                            {
                                gameObject.GetComponent<Stats>().InstantiateInventoryItemConsumable(h.transform.gameObject.GetComponent<Pickup>().GiveItemID, h.transform.gameObject);

                            }
                            gameObject.GetComponent<Stats>().inventoryOn = true;
                            
                            GameObject.Destroy(h.transform.gameObject);
                        }
                    }
                }
                else if (h.transform.gameObject.GetComponent<Storage>() == true)
                {
                    if (currentBaseState.nameHash == inventoryState && gameObject.GetComponent<Stats>().inventoryOn != true)
                    {
                        float distance = Vector3.Distance(h.transform.position, transform.position);
                        if (distance < 3f)
                        {
                            gameObject.GetComponent<Stats>().inventoryOn = true;
                            CurrentStorage = h.transform.gameObject;
                            CurrentStorage.gameObject.GetComponent<Storage>().CurrentlyBeingUsed = true;
                            CurrentStorage.gameObject.GetComponent<Storage>().currentlyInteractingInstance = gameObject;
                        }
                    }
                }

                else if (h.transform.gameObject.GetComponent<WeaponPickup>() == true)
                {
                    float distance = Vector3.Distance(h.transform.position, transform.position);
                    if (distance < 3f)
                    {
                        gameObject.GetComponent<Stats>().InstantiateWeaponSlotted(h.transform.gameObject.GetComponent<WeaponPickup>().GiveWeaponID);
                        GameObject.Destroy(h.transform.gameObject);
                    }

                }
            }
        }
    }
    void UpdateInputs()
    {
        

        if (Input.GetKey(KeyCode.T))
        {
            transform.position = TP.position;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
            animator.SetBool("RifleRun", true);
            
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("RifleRun", false);
        }
        animator.SetBool("Rifle", animator.GetBool("Rifle_Aim"));

        if (Input.GetKey(KeyCode.Mouse1) ||AimingTestBool == true)
        {
            if (WM.CheckIfHoldingWeapon() == true)
            {
                animator.SetBool("Rifle_Aim", true);
                //[ZppixFix]if (gameObject.GetComponent<AimIK>().solver.IKPositionWeight < 1)
                //[ZppixFix]  {
                //[ZppixFix]     gameObject.GetComponent<AimIK>().solver.IKPositionWeight += AimTransitionSpeed * Time.deltaTime;
                //[ZppixFix] }
                MainCamAcess.GetComponent<CameraCont>().Aiming = true;

                if (Input.GetKeyDown(KeyCode.Mouse2))
                {
                    MainCamAcess.GetComponent<CameraCont>().TrueAiming = !MainCamAcess.GetComponent<CameraCont>().TrueAiming;
                }
                
            }
            else
            {
                animator.SetBool("Rifle_Aim", false);
                //[ZppixFix] if (gameObject.GetComponent<AimIK>().solver.IKPositionWeight > 0)
                //[ZppixFix] {
                //[ZppixFix] gameObject.GetComponent<AimIK>().solver.IKPositionWeight -= AimTransitionSpeed * Time.deltaTime;
                //[ZppixFix]  }
                //[ZppixFix] if (gameObject.GetComponent<AimIK>().solver.IKPositionWeight <= 0)
                //[ZppixFix] {
                //[ZppixFix]          MainCamAcess.GetComponent<CameraCont>().Aiming = false;
                //[ZppixFix]   }
            }
        }
        else
        {
            animator.SetBool("Rifle_Aim", false);
            //[ZppixFix]  if (gameObject.GetComponent<AimIK>().solver.IKPositionWeight > 0)
            //[ZppixFix]     {
            //[ZppixFix]    gameObject.GetComponent<AimIK>().solver.IKPositionWeight -= AimTransitionSpeed * Time.deltaTime;
            //[ZppixFix] }
            //[ZppixFix] if (gameObject.GetComponent<AimIK>().solver.IKPositionWeight <= 0)
            //[ZppixFix]     {
            //[ZppixFix]         MainCamAcess.GetComponent<CameraCont>().Aiming = false;
            //[ZppixFix]     }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (gameObject.GetComponent<WeaponsManager>().BigWeapons == false)
            {
                animator.SetBool("Sprint", true);
            }
            else
            {
                animator.SetBool("Sprint", false);
            }
        }
        else
        {
            animator.SetBool("Sprint", false);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentBaseState.nameHash == walkState || currentBaseState.nameHash == inventoryState)
            {

                gameObject.GetComponent<Stats>().inventoryOn = !gameObject.GetComponent<Stats>().inventoryOn;

            }
            gameObject.GetComponent<ActionPerform>().StopAction();
        }

        if (Input.GetKey(KeyCode.E))
        {
            
            InteractMode = true;
        }
        else
        {
            
            InteractMode = false;
        }
    }

    void UpdateAnimator()
    {
        if (animator.GetFloat("DirX") < 0 || animator.GetFloat("DirY") < 0)
        {
            if (currentBaseState.nameHash != inventoryState)
            {
                TurnToCam = true;
            }
        }
        else if (animator.GetFloat("DirX") > 0 || animator.GetFloat("DirY") > 0)
        {
            if (currentBaseState.nameHash != inventoryState)
            {
                TurnToCam = true;
            }
        }
        else
        {
            TurnToCam = false;
        }

        if (currentBaseState.nameHash == walkState)
        {
            IdleAnimPlayed = true;
        }
        else
        {
            IdleAnimPlayed = false;
        }
        if (currentBaseState.nameHash == runState || currentBaseState.nameHash == sprintState)
        {
            AnimBesideWalkPlayed = true;
        }
        else
        {
            AnimBesideWalkPlayed = false;
        }
        if (IdleAnimPlayed == true && FirstAndThirdToggle == false)
        {
            float rotation = Input.GetAxis("Mouse X");
            animator.SetLayerWeight(1, 0.8f);
            animator.SetFloat("TurnSpeed",rotation);

            if (animator.GetFloat("TurnSpeed") > 1)
            {
                animator.SetFloat("TurnSpeed",1);
            }
            else if (animator.GetFloat("TurnSpeed") < -1)
            {
                animator.SetFloat("TurnSpeed",-1);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Turn", false);
            }
            else
            {
                if (rotation > 0.09999f)
                {
                    animator.SetBool("Turn", true);
                }
                else if (rotation < -0.09999f)
                {
                    animator.SetBool("Turn", true);
                }
                else
                {
                    animator.SetBool("Turn", false);
                }
            }
            if (rotation > 10)
            {
                rotation = 10;
            }
            else if (rotation < -10)
            {
                rotation = -10;
            }
        }
        else
        {
            animator.SetBool("Turn", false);
            animator.SetLayerWeight(1, 0f);
        }
    }

    void UpdateCharacterRotation()
    {
        //if (TurnToCam == true)
        //{
        if (FirstAndThirdToggle == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (currentBaseState.nameHash != fallingState &&
                    currentBaseState.nameHash != rollLandState &&
                    currentBaseState.nameHash != hardLandState)
                {
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, MC.transform.eulerAngles.y, ref angleVel, turnSpeed);
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                }
            }
        }
        else
        {
            if (currentBaseState.nameHash != fallingState &&
                currentBaseState.nameHash != rollLandState &&
                currentBaseState.nameHash != hardLandState)
            {
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, MC.transform.eulerAngles.y, ref angleVel, turnSpeed);
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            }
        }
        
        //}
    }

    void UpdateInventory()
    {
        if (gameObject.GetComponent<Stats>().inventoryOn == false)
        {
            foreach (Transform child in transform.gameObject.GetComponent<Stats>().UnReadyItemsUI.transform)
            {
                if (child.GetComponent<AmmoData>() == true)
                {
                    gameObject.GetComponent<Stats>().InstantiatePickupItemAmmo(child.GetComponent<ItemFunctionFoundation>().itmID, child.gameObject);
                    GameObject.Destroy(child.gameObject);
                }
                else if (child.GetComponent<ItemAction_StatsEditorItem>() == true)
                {
                    gameObject.GetComponent<Stats>().InstantiatePickupItemConsumable(child.GetComponent<ItemFunctionFoundation>().itmID, child.gameObject);
                    GameObject.Destroy(child.gameObject);
                }
                else
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
            if (CurrentStorage != null)
            {
                CurrentStorage.GetComponent<Storage>().CurrentlyBeingUsed = false;
                CurrentStorage.GetComponent<Storage>().MyStorageUI.transform.SetParent(CurrentStorage.transform);
                CurrentStorage.GetComponent<Storage>().currentlyInteractingInstance = null;
                CurrentStorage = null;
            }

        }

        if (gameObject.GetComponent<Stats>().inventoryOn == true)
        {
            CameraCont CamCon = MainCamAcess.gameObject.GetComponent<CameraCont>();
            animator.SetBool("Inventory", true);
            TurnToCam = false;
            CamCon.CanMove = false;
        }
        else if (InteractMode == true)
        {
            CameraCont CamCon = MainCamAcess.gameObject.GetComponent<CameraCont>();
            animator.SetBool("Inventory", true);
            TurnToCam = false;
            CamCon.CanMove = false;
        }
        else if (MyPauseMenu.GetComponent<PauseMenu>().PauseMenuGroup.active == true)
        {
            CameraCont CamCon = MainCamAcess.gameObject.GetComponent<CameraCont>();
            TurnToCam = false;
            CamCon.CanMove = false;
        }
        else
        {
            CameraCont CamCon = MainCamAcess.gameObject.GetComponent<CameraCont>();
            animator.SetBool("Inventory", false);
            CamCon.CanMove = true;
        }
    }

    void UpdateAimingSystem()
    {
        //[ZppixFix]gameObject.GetComponent<FullBodyBipedIK>().solver.leftHandEffector.positionWeight = gameObject.GetComponent<AimIK>().solver.IKPositionWeight;
        //[ZppixFix]gameObject.GetComponent<FullBodyBipedIK>().solver.leftHandEffector.rotationWeight = gameObject.GetComponent<AimIK>().solver.IKPositionWeight;
        //[ZppixFix]gameObject.GetComponent<FullBodyBipedIK>().solver.leftArmMapping.weight = gameObject.GetComponent<AimIK>().solver.IKPositionWeight;
    }

    void FixedUpdateAnimator()
    {
       
        animator.speed = AnimationSpeed;
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);

        TransitionSmoothingScript tss = gameObject.GetComponent<TransitionSmoothingScript>();

        animator.SetFloat("DirX", tss.TransSmootherX);
        animator.SetFloat("DirY", tss.TransSmootherY);


        //[ZppixFix] if (gameObject.GetComponent<AimIK>().solver.IKPositionWeight < 0)
        //[ZppixFix] {
        //[ZppixFix] gameObject.GetComponent<AimIK>().solver.IKPositionWeight = 0;
        //[ZppixFix]}
        //[ZppixFix] if (gameObject.GetComponent<AimIK>().solver.IKPositionWeight > 1)
        //[ZppixFix] {
        //[ZppixFix]     gameObject.GetComponent<AimIK>().solver.IKPositionWeight = 1;
        //[ZppixFix] }
    }
    void FixedUpdateFallDetection()
    {
        FallDetRayDir = transform.TransformDirection(Vector3.down);
        Debug.DrawRay(CasterPosition.position, FallDetRayDir * FallDetMaxDist, Color.red);


        if (Physics.Raycast(CasterPosition.position, FallDetRayDir, FallDetMaxDist))
        {
            if (CanLand == true)
            {
                Land();
                CanLand = false;
            }
            if (currentBaseState.nameHash == fallingState)
            {
                Land();
            }
        }
        else
        {
            if (CanFall == true)
            {
                Fall();
                CanFall = false;
            }
            Debug.DrawRay(transform.position, transform.forward * FallDetMaxDist, Color.blue);
            rb.AddForce(transform.forward * FallSpeedForward);
            rb.AddForce(-transform.up * FallSpeed);
        }


        if (currentBaseState.nameHash == rollLandState)
        {

            animator.SetFloat("DirX", 0);
            animator.SetFloat("DirY", 0);
        }
        if (currentBaseState.nameHash == hardLandState)
        {

            animator.SetFloat("DirX", 0);
            animator.SetFloat("DirY", 0);
        }
        if (currentBaseState.nameHash == fallingState)
        {
            animator.SetFloat("DirX", 0);
            animator.SetFloat("DirY", 0);
        }
        if (currentBaseState.nameHash == easyLandState)
        {
            animator.SetFloat("DirX", 0);
            animator.SetFloat("DirY", 0);
        }
        if (currentBaseState.nameHash == walkState || currentBaseState.nameHash == runState || currentBaseState.nameHash == sprintState)
        {
            animator.SetBool("RollLand", false);
            animator.SetBool("HardLand", false);
            animator.SetBool("EasyLand", false);
        }
    }
	void Fall()
	{
		LastPos.position = transform.position;
		Debug.Log ("Started falling.");
		animator.SetBool("Fall", true);
		CanLand = true;
	}
	void Land()
	{
		DistanceVector = LastPos.position - transform.position;
		DistanceVector.x = 0;
		DistanceVector.z = 0;
		FallDistance = DistanceVector.magnitude;
		if(FallDistance >= 1.5f && FallDistance <= 5)
		{
			animator.SetBool("Fall", false);
			animator.SetBool("RollLand", true);
			Debug.Log ("Roll landed.");
		}
		else if (FallDistance > 5)
		{
			animator.SetBool("Fall", false);
			animator.SetBool("HardLand", true);
			Debug.Log ("Hard landed.");
		}
		else if (FallDistance < 1.5f)
		{
			animator.SetBool("EasyLand", true);
			animator.SetBool("Fall", false);
			Debug.Log ("Easly landed.");
		}
		CanFall = true;
	}
    


    
}
