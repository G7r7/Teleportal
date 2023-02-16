using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public int currentPortal;
    private GameObject portal1;
    private GameObject portal2;

    void Start()
    {
        portal1 = null;
        portal2 = null;
        currentPortal = 0;
    }

    public bool isFirstPortalSet()
    {
        return portal1 != null;
    }

    public bool isSecondPortalSet()
    {
        return portal2 != null;
    }

    public void setCurrentFirstPortal()
    {
        currentPortal = 0;
    }

    public void setCurrentSecondPortal()
    {
        currentPortal = 1;
    }

    public void setFirstPortal(GameObject portal)
    {
        portal1 = portal;
    }

    public void setSecondPortal(GameObject portal)
    {
        portal2 = portal;
    }

    public void placePortal(Vector3 position, Quaternion rotation)
    {
        if (currentPortal == 0)
        {
            portal1.transform.position = position;
            portal1.transform.rotation = rotation;
        }
        else
        {
            portal2.transform.position = position;
            portal2.transform.rotation = rotation;
        }

    }

}
