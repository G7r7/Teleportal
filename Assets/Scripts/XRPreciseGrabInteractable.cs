using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRPreciseGrabInteractable : XRGrabInteractable
{
    private Vector3 position = Vector3.zero;
    private Quaternion rotation = Quaternion.identity;

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);

        // Saving the position and orientation of the controller
        this.position = interactor.attachTransform.localPosition;
        this.rotation = interactor.attachTransform.localRotation;

        // If we the object 
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.SetPositionAndRotation(
            hasAttach ? attachTransform.position : transform.position,
            hasAttach ? attachTransform.rotation : transform.rotation
        );
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        
        // Restore the position and rotation to previous value
        interactor.attachTransform.localPosition = this.position;
        interactor.attachTransform.localRotation = this.rotation;

        // Restore the private members to their default value
        this.position = Vector3.zero;
        this.rotation = Quaternion.identity;
    }
}
