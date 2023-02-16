using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Portal : MonoBehaviour
{
    public PortalManager PortalManager;
    public int PortalId;
    public Text debugText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Teleportable>() == null) { return; } // Check if object is Teleportable
        debugText.text = "Collision";
        PortalManager.TeleportObject(other.gameObject, PortalId);
    }

    private void OnTriggerExit(Collider other)
    {
        debugText.text = "No Collision";
    }
}
