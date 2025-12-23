using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable
{
    [SerializeField] private SO_ObjectInfo objectInfo;

    private bool isHeld = false;

    public void OnInteract()
    {
        Debug.Log("Interagindo com o cubo!");

        if (HoldingManager.Instance.TryPickUp(gameObject))
        {
            isHeld = true;
            ShowObjectInfo();
        }
        else if (isHeld)
        {
            HoldingManager.Instance.Drop();
            isHeld = false;
            HideObjectInfo();
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
    
    private void ShowObjectInfo()
    {
        if (objectInfo == null) return;

        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.SetObjInfo(objectInfo);
            infoController.SetVisible(true);

            infoController.transform.SetParent(transform);
            infoController.transform.localPosition = new Vector3(0, 2f, 0);
        }
    }

    private void HideObjectInfo()
    {
        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.SetVisible(false);
            infoController.transform.SetParent(null);
        }
    }
}
