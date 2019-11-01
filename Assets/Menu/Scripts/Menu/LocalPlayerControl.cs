﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using InputTracking = UnityEngine.XR.InputTracking;
using Node = UnityEngine.XR.XRNode;

public class LocalPlayerControl : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject ovrCamRig;
    public Transform leftHand;
    public Transform rightHand;
    public Camera leftEye;
    public Camera rightEye;
    Vector3 pos;
    public float speed = 3;

    void Start()
    {
        pos =transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            Destroy(ovrCamRig);
        }
        else
        {
            if (leftEye.tag!= "MainCamera")
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
                pos += (primaryAxis.y * transform.forward * Time.deltaTime* speed);
            }
            if (primaryAxis.y < 0f)
            {
                pos += (Mathf.Abs(primaryAxis.y)* -transform.forward * Time.deltaTime * speed);
            }
            if (primaryAxis.x > 0f)
            {
                pos += (primaryAxis.x * transform.forward * Time.deltaTime*speed);
            }
            if (primaryAxis.x < 0f)
            {
                pos += (Mathf.Abs(primaryAxis.x) * -transform.forward * Time.deltaTime*speed);
            }

            transform.position = pos;

            Vector3 euler = transform.rotation.eulerAngles;
            Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            euler.y += secondaryAxis.x;
            transform.rotation = Quaternion.Euler(euler);
            transform.localRotation = Quaternion.Euler(euler);
        }
    }
}
