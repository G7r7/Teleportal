using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    public XRNode controller;
    private Vector2 inputAxis;
    private CharacterController user;
    private XROrigin rig;
    private bool padPressed;
    public float speed = 1f;
    public LayerMask ground;
    private float fallingSpeed = 0;
    private float gravity = 5;

    // Start is called before the first frame update
    void Start()
    {
        user = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controller);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out padPressed);
    }

    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        if (padPressed)
        {
            user.Move(2 * speed * Time.deltaTime * direction);
        }
        else
        {
            user.Move(speed * Time.deltaTime * direction);
        }
        bool isGrounded = checkIfGrounded();
        if (!isGrounded)
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
            user.Move(fallingSpeed * Time.fixedDeltaTime * Vector3.down);
        }
        else
        {
            fallingSpeed = 0;
        }

    }

    bool checkIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(user.center);
        float rayLength = user.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, user.radius, Vector3.down, out RaycastHit hitInfo, rayLength, ground);
        return hasHit;
    }
}