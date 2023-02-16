using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Portal : MonoBehaviour
{
    public PortalManager PortalManager;
    public int PortalId;

    private void OnTriggerEnter(Collider other)
    {
        PortalManager.TeleportObject(other.gameObject, PortalId);
    }
}
