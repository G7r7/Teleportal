using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class portal : MonoBehaviour
{

    public XRController leftH;

    // Référence au prefab du cube à instancier
    public GameObject cylinder;

    public GameObject sphere;

    public void createPortal()
    {
        RaycastHit hit;
        Physics.Raycast(leftH.transform.position, leftH.transform.forward, out hit);

        if (!PortalManager.isCurrentPortalSet())
        {
            if (PortalManager.currentPortal == 0)
            {
                PortalManager.setCurrentPortal(Instantiate(cylinder, hit.point, Quaternion.identity));
            }
            else
            {
                PortalManager.setCurrentPortal(Instantiate(sphere, hit.point, Quaternion.identity));
            }
        }


        PortalManager.placePortal(hit.point, hit.transform.gameObject.transform.rotation);
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class portal : MonoBehaviour
{
    public XRNode controller;
    private bool IsPressed;


    // Référence au prefab du cube à instancier
    public GameObject cylinder;

    // La distance maximale à laquelle le joueur peut tirer
    public float maxDistance = 100f;

    void Start()
    {
    }

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controller);
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out IsPressed) && IsPressed)
        {
            createPortal(transform.position, transform.forward);
        }
    }

    private void createPortal(Vector3 pos, Vector3 dir)
    {
        RaycastHit hit;
        Physics.Raycast(pos, dir, out hit);
        Debug.Log(hit.collider.name);
        cylinder = Instantiate(cylinder, hit.point, Quaternion.identity);
        cylinder.transform.position = hit.point;
        cylinder.transform.rotation = hit.transform.gameObject.transform.rotation;

    }
}

*/