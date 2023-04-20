using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
/// Special script that work with the XRExclusiveSocket script. This allow to define a SocketType and if that SocketType
/// does not match the XRExclusiveSocket SocketType, this won't be accepted by the socket as a valid target
/// </summary>
/// 
public class XROnSocketEvent : UnityEngine.Events.UnityEvent<IXRSelectInteractable>
{

}

[RequireComponent(typeof(XRBaseInteractable))]
public class SocketTarget : MonoBehaviour
{
    public string SocketType;

    //TODO: Hotfix to avoid deprecation, look into where this event is listened to and see if change is needed
    public XROnSocketEvent SocketedEvent;
    public bool DisableSocketOnSocketed;

    void Awake()
    {
        var interactable = GetComponent<XRBaseInteractable>();

        interactable.selectEntered.AddListener(SelectedSwitch);
    }

    public void SelectedSwitch(SelectEnterEventArgs args)
    {
        var socketInteractor = args.interactableObject as XRExclusiveSocketInteractor;

        if (socketInteractor == null)
            return;

        if (SocketType != socketInteractor.AcceptedType)
            return;

        if (DisableSocketOnSocketed)
        {
            //TODO : find a better way, delay feel very wrong
            StartCoroutine(DisableSocketDelayed(socketInteractor));
        }

        SocketedEvent.Invoke(args.interactableObject);
    }

    IEnumerator DisableSocketDelayed(XRExclusiveSocketInteractor interactor)
    {
        yield return new WaitForSeconds(0.5f);
        interactor.socketActive = false;
    }
}
