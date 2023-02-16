using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalManager : MonoBehaviour
{
    public int currentPortal;
    public GameObject portal1;
    public GameObject portal2;
    public XRController controller;

    public void setCurrentFirstPortal()
    {
        currentPortal = 0;
    }

    public void setCurrentSecondPortal()
    {
        currentPortal = 1;
    }

    public void PlacePortal()
    {
        Physics.Raycast(controller.transform.position, controller.transform.forward, out RaycastHit hit);

        if (currentPortal == 0)
        {
            portal1.SetActive(true);
            portal1.transform.position = hit.point;
            portal1.transform.rotation = hit.transform.gameObject.transform.rotation;
        }
        else
        {
            portal2.SetActive(true);
            portal2.transform.position = hit.point;
            portal2.transform.rotation = hit.transform.gameObject.transform.rotation;
        }

    }

    public void TeleportObject(GameObject obj, int sourceId)
    {
        Vector3 newPosition;
        if (sourceId == 0)
        {
            newPosition = portal2.transform.position;
        } else {
            newPosition = portal1.transform.position;
        }
        obj.transform.position = newPosition + new Vector3(2,2,2);
    }

}
