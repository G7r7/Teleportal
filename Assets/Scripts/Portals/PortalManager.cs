using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalManager : MonoBehaviour
{
    public int currentPortal;
    public GameObject portal1;
    public GameObject portal2;
    public XRBaseController controller;

    public void setCurrentFirstPortal()
    {
        currentPortal = 0;
    }

    public void setCurrentSecondPortal()
    {
        currentPortal = 1;
    }

    public void TeleportObject(GameObject obj, int sourceId)
    {
        Vector3 newPosition;
        if (sourceId == 0) { 
            newPosition = portal2.transform.position;
        } else {
            newPosition = portal1.transform.position;
        }
        obj.transform.position = newPosition;
    }

}
