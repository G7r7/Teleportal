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
        Quaternion rotation;
        if (sourceId == 0) {
            newPosition = portal2.transform.position + portal2.transform.forward * 5;
            rotation = portal2.transform.rotation;
        } else {
            newPosition = portal1.transform.position + portal1.transform.forward * 5;
            rotation = portal1.transform.rotation;
        }
        obj.transform.position = newPosition;
        obj.transform.rotation *= rotation;
    }

}
