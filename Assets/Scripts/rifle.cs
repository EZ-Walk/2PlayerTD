using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class rifle : MonoBehaviour {

    public float bulletSpeed = 200f;
    public float bulletLife = 5f;

    public static int clip = 13;

    private GameObject bullet;
    private GameObject trigger;

    private VRTK_ControllerEvents controllerEvents;

    private float minTriggerRotation = -10f;
    private float maxTriggerRotation = 45f;

    private void ToggleCollision(Rigidbody objRB, Collider objCol, bool state)
    {
        objRB.isKinematic = state;
        objCol.isTrigger = state;
    }

    public void Grabbed(VRTK_InteractGrab currentGrabbingObject)
    {

        controllerEvents = currentGrabbingObject.GetComponent<VRTK_ControllerEvents>();

        //Limit hands grabbing when picked up
        if (VRTK_DeviceFinder.GetControllerHand(currentGrabbingObject.controllerEvents.gameObject) == SDK_BaseController.ControllerHand.Left)
        {
            object allowedTouchControllers = VRTK_InteractableObject.AllowedController.LeftOnly;
            object allowedUseControllers = VRTK_InteractableObject.AllowedController.LeftOnly;
        }
        else if (VRTK_DeviceFinder.GetControllerHand(currentGrabbingObject.controllerEvents.gameObject) == SDK_BaseController.ControllerHand.Right)
        {
            object allowedTouchControllers = VRTK_InteractableObject.AllowedController.RightOnly;
            object allowedUseControllers = VRTK_InteractableObject.AllowedController.RightOnly;
        }
    }

    public void StartUsing(VRTK_InteractUse currentUsingObject)
    {
        FireBullet();
        VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(controllerEvents.gameObject), 0.63f, 0.2f, 0.01f);

        VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(controllerEvents.gameObject), 0.08f, 0.1f, 0.01f);

    }

    protected void Awake()
    {
        bullet = transform.Find("Bullet").gameObject;
        bullet.SetActive(false);

        trigger = transform.Find("TriggerHolder").gameObject;
    }


    private void FireBullet()
    {
        clip--;
        if (clip > 0)
        {
            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
        else
        {
            Debug.Log("clip is empty, try reloading by pulling the slide back");
        }
    }
}

