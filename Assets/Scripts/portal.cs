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

    public PortalManager PortalManager;

    public void createPortal()
    {
        RaycastHit hit;
        Physics.Raycast(leftH.transform.position, leftH.transform.forward, out hit);


        if (PortalManager.currentPortal == 0 && !PortalManager.isFirstPortalSet())
        {
            PortalManager.setFirstPortal(Instantiate(cylinder, hit.point, Quaternion.identity));
        }
        else if(PortalManager.currentPortal == 1 && !PortalManager.isSecondPortalSet())
        {
            PortalManager.setSecondPortal(Instantiate(sphere, hit.point, Quaternion.identity));
        }

        PortalManager.placePortal(hit.point, hit.transform.gameObject.transform.rotation);
    }
}
