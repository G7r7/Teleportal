using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static List<GameObject> portals = new List<GameObject>();
    public static int currentPortal = 0;

    public static bool isCurrentPortalSet()
    {
        return portals[currentPortal] != null;
    }

    public static void setCurrentFirstPortal()
    {
        currentPortal = 0;
    }

    public static void setCurrentSecondPortal()
    {
        currentPortal = 1;
    }

    public static void setCurrentPortal(GameObject portal)
    {
        portals[currentPortal] = portal;
    }

    public static void placePortal(Vector3 position, Quaternion rotation)
    {
        portals[currentPortal].transform.position = position;
        portals[currentPortal].transform.rotation = rotation;
    }

}
