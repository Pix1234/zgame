using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;

public class Aim_Control : MonoBehaviour
{
    /// <summary>
	/// Basic full body FPS IK controller.
	/// 
	/// If aimWeight is weighed in, the character will simply use AimIK to aim his gun towards the camera forward direction.
	/// If sightWeight is weighed in, the character will also use FBBIK to pose the gun to a predefined position relative to the camera so it stays fixed in view.
	/// That position was simply defined by making a copy of the gun (gunTarget), parenting it to the camera and positioning it so that the camera would look down it's sights.
	/// </summary>
	
        [Range(0f, 1f)]
        public float aimWeight = 1f; // The weight of aiming the gun towards camera forward
        [Range(0f, 1f)]
        public float sightWeight = 1f; // the weight of aiming down the sight (multiplied by aimWeight)
        [Range(0f, 180f)]
        public float maxAngle = 80f; // The maximum angular offset of the aiming direction from the character forward. Character will be rotated to comply.

        [SerializeField]
        bool animatePhysics; // Is Animate Physiscs turned on for the character?
        [SerializeField]
        Transform gun; // The gun that the character is holding
        [SerializeField]
        Transform gunTarget; // The copy of the gun that has been parented to the camera
        [SerializeField]
        FullBodyBipedIK ik; // Reference to the FBBIK component
        [SerializeField]
        AimIK gunAim; // Reference to the AimIK component
    [SerializeField]
    public GameObject MainCam;
        private Vector3 gunTargetDefaultLocalPosition;
        private Quaternion gunTargetDefaultLocalRotation;
        private Vector3 camDefaultLocalPosition;
        private Vector3 camRelativeToGunTarget;
        private bool updateFrame;

        void Start()
        {
            // Remember some default local positions
            gunTargetDefaultLocalPosition = gunTarget.localPosition;
            gunTargetDefaultLocalRotation = gunTarget.localRotation;

            // Disable the camera and IK components so we can handle their execution order
            
            gunAim.enabled = false;
            ik.enabled = false;
        }

        void FixedUpdate()
        {
            // Making sure this works with Animate Physics
            updateFrame = true;
        }

        void LateUpdate()
        {
            // Making sure this works with Animate Physics
            if (!animatePhysics) updateFrame = true;
            if (!updateFrame) return;
            updateFrame = false;


            // Remember the camera's position relative to the gun target
            camRelativeToGunTarget = gunTarget.InverseTransformPoint(MainCam.transform.position);

            // Set FBBIK positionWeight for the hands
            ik.solver.leftHandEffector.positionWeight = aimWeight > 0 && sightWeight > 0 ? aimWeight * sightWeight : 0f;
            ik.solver.rightHandEffector.positionWeight = ik.solver.leftHandEffector.positionWeight;

            Aiming();
        }

        private void Aiming()
        {
            if (aimWeight <= 0f) return;

            // Remember the rotation of the camera because we need to reset it later so the IK would not interfere with the rotating of the camera
            Quaternion camRotation = MainCam.transform.rotation;

            // Aim the gun towards camera forward
            gunAim.solver.IKPosition = MainCam.transform.position + MainCam.transform.forward * 10f;
            gunAim.solver.IKPositionWeight = aimWeight;
            gunAim.solver.Update();
            MainCam.transform.rotation = camRotation;
        }
    /*
        private void LookDownTheSight()
        {
            float sW = aimWeight * sightWeight;
            if (sW <= 0f) return;

            // Interpolate the gunTarget from the current animated position of the gun to the position fixed to the camera
            gunTarget.position = Vector3.Lerp(gun.position, gunTarget.parent.TransformPoint(gunTargetDefaultLocalPosition), sW);
            gunTarget.rotation = Quaternion.Lerp(gun.rotation, gunTarget.parent.rotation * gunTargetDefaultLocalRotation, sW);

            // Get the current positions of the hands relative to the gun
            Vector3 leftHandRelativePosition = gun.InverseTransformPoint(ik.solver.leftHandEffector.bone.position);
            Vector3 rightHandRelativePosition = gun.InverseTransformPoint(ik.solver.rightHandEffector.bone.position);

            // Get the current rotations of the hands relative to the gun
            Quaternion leftHandRelativeRotation = Quaternion.Inverse(gun.rotation) * ik.solver.leftHandEffector.bone.rotation;
            Quaternion rightHandRelativeRotation = Quaternion.Inverse(gun.rotation) * ik.solver.rightHandEffector.bone.rotation;

            // Position the hands to the gun target the same way they are positioned on the gun
            ik.solver.leftHandEffector.position = gunTarget.TransformPoint(leftHandRelativePosition);
            ik.solver.rightHandEffector.position = gunTarget.TransformPoint(rightHandRelativePosition);

            // Make sure the head does not rotate
            ik.solver.headMapping.maintainRotationWeight = 1f;

            // Update FBBIK
            ik.solver.Update();

            // Rotate the hand bones relative to the gun target the same way they are rotated relative to the gun
            ik.references.leftHand.rotation = gunTarget.rotation * leftHandRelativeRotation;
            ik.references.rightHand.rotation = gunTarget.rotation * rightHandRelativeRotation;

        }
        */
   
}


