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
        Teleportable teleportable = other.gameObject.GetComponent<Teleportable>();
        if (teleportable.teleporting) { return; } // We won't allow the object to be stuck in a teleportation loop
        teleportable.teleporting = true;
        teleportable.sourcePortalId = PortalId;
        PortalManager.TeleportObject(other.gameObject, PortalId);
        debugText.text = "Collision";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Teleportable>() == null) { return; } // Check if object is Teleportable
        Teleportable teleportable = other.gameObject.GetComponent<Teleportable>();
        if (teleportable.teleporting && teleportable.sourcePortalId != PortalId) { // If we exit the portal on the other side
            // We reset the teleporting flag
            teleportable.teleporting = false;
        }
        debugText.text = "No Collision";
    }
}
