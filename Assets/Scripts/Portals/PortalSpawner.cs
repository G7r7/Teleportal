using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalSpawner : MonoBehaviour
{
    public XRBaseController controller;
    public PortalManager portalManager;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.3f;
        audioSource.clip = Resources.Load<AudioClip>("DM-CGS-37");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlacePortal()
    {
        audioSource.Play();
        Debug.Log("Hello");

        Physics.Raycast(controller.transform.position, controller.transform.forward, out RaycastHit hit);

        if (portalManager.currentPortal == 0)
        {
            portalManager.portal1.gameObject.SetActive(true);
            portalManager.portal1.transform.position = hit.point;
            portalManager.portal1.transform.rotation = hit.transform.gameObject.transform.rotation;
        }
        else
        {
            portalManager.portal2.gameObject.SetActive(true);
            portalManager.portal2.transform.position = hit.point;
            portalManager.portal2.transform.rotation = hit.transform.gameObject.transform.rotation;
        }

    }
}
