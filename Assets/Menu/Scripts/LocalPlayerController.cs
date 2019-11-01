using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;

using InputTracking = UnityEngine.XR.InputTracking;
using Node = UnityEngine.XR.XRNode;


public class LocalPlayerController : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject OVRCameraRig;
    public Transform leftHand;
    public Transform rightHand;

    public Camera leftEye;
    public Camera rightEye;

    public float speed = 3.0F;



    public int force = 200;
    public GameObject projectile;
    public bool cooldown;
    public float fireRate = 1.0f;

    public GameObject body;

    Vector3 position;

    Renderer bodyRender;


    void Start()
    {

        bodyRender = GetComponent<Renderer>();
        position = transform.position;
        bodyRender.material.SetColor("_Color", Color.red);

    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            Destroy(OVRCameraRig);
        }
        else
        {
            if (leftEye.tag != "MainCamera")
            {
                leftEye.tag = "MainCamera";
                leftEye.enabled = true;
            }
            if (rightEye.tag != "MainCamera")
            {
                rightEye.tag = "MainCamera";
                rightEye.enabled = true;
            }

            leftHand.localRotation = InputTracking.GetLocalRotation(Node.LeftHand);
            rightHand.localRotation = InputTracking.GetLocalRotation(Node.RightHand);

            leftHand.localPosition = InputTracking.GetLocalPosition(Node.LeftHand);
            rightHand.localPosition = InputTracking.GetLocalPosition(Node.RightHand);

            Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            if (primaryAxis.y > 0f)
            {
                position += (primaryAxis.y * transform.forward * Time.deltaTime * speed);
            }

            if (primaryAxis.y < 0f)
            {
                position += (Mathf.Abs(primaryAxis.y) * -transform.forward * Time.deltaTime * speed);
            }

            if (primaryAxis.x > 0f)
            {
                position += (primaryAxis.x * transform.right * Time.deltaTime * speed);
            }

            if (primaryAxis.x < 0f)
            {
                position += (Mathf.Abs(primaryAxis.x) * -transform.right * Time.deltaTime * speed);
            }

            transform.position = position;

            Vector3 euler = transform.rotation.eulerAngles;
            Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            euler.y += secondaryAxis.x;
            transform.rotation = Quaternion.Euler(euler);
            transform.localRotation = Quaternion.Euler(euler);

            if ((OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0f && !cooldown) || (Input.GetMouseButtonDown(0)) && !cooldown)
            {
                Fire();
                cooldown = true;
                Invoke("FireRate", fireRate);
            }




        }
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(projectile, rightHand.position, rightHand.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }

    public void FireRate()
    {
        cooldown = false;
    }
}