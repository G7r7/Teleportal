using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalButton : MonoBehaviour
{
    public Sprite InactiveButtonImage;
    public Sprite ActiveButtonImage;
    public PortalManager portalManager;
    public Portal portal;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprite()
    {
        if (portalManager.currentPortal == portal.PortalId)
        {
            GetComponent<Image>().sprite = ActiveButtonImage;
            return;
        }
        GetComponent<Image>().sprite = InactiveButtonImage;
    }
}
