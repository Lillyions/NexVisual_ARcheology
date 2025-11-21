using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, InInteractable
{

    private bool isHeld = false;

    public void OnInteract()
    {
        Debug.Log("Interagindo com o cubo!");

        //isHeld = !isHeld;

        if (HoldingManager.Instance.TryPickUp(gameObject))
        {
            isHeld = true;
        }
        else if (isHeld)
        {
            HoldingManager.Instance.Drop();
            isHeld = false;
        }
    }

    public void StopInteract()
    {
        Debug.Log("Parando interação com o cubo!");
    }

    void Update()
    {
        if (InputHandler.TryRayCastHit(out RaycastHit hitObject))
        {
            if (hitObject.transform == transform)
            {
                OnInteract();
            }
        }
    }
}
