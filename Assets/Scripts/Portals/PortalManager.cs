using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalManager : MonoBehaviour
{
    public int currentPortal;
    public Portal portal1;
    public Portal portal2;
    public XRBaseController controller;
    public PortalButton portal1Button;
    public PortalButton portal2Button;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.2f;
        audioSource.clip = Resources.Load<AudioClip>("DM-CGS-09");
    }


    public void setCurrentFirstPortal()
    {
        currentPortal = 0;
        portal1Button.UpdateSprite();
        portal2Button.UpdateSprite();
    }

    public void setCurrentSecondPortal()
    {
        currentPortal = 1;
        portal1Button.UpdateSprite();
        portal2Button.UpdateSprite();
    }

    public void TeleportObject(GameObject obj, int sourceId)
    {
        audioSource.Play();

        Vector3 newPosition;
        Quaternion rotation;
        if (sourceId == 0) {
            newPosition = portal2.transform.position;
            rotation = portal2.transform.rotation;
        } else {
            newPosition = portal1.transform.position;
            rotation = portal1.transform.rotation;
        }
        obj.transform.position = newPosition;
        obj.transform.rotation *= rotation;
    }

}
