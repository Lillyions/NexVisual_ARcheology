using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetController : MonoBehaviour
{

    [SerializeField] private List<SpotController> spots;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            TryToPutOnCabinet(collision.gameObject);
        }
    }

    private void TryToPutOnCabinet(GameObject obj)
    {
        if (GetAvailableSpot() is SpotController avaliableSpot)
        {
            obj.transform.SetParent(avaliableSpot.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            if (obj.TryGetComponent<Rigidbody>(out Rigidbody body))
            {
                body.isKinematic = true;
            }
        }
    }

    private SpotController GetAvailableSpot()
    {
        foreach (SpotController spot in spots)
        {
            if (!spot.isOccupied())
            {
                return spot;
            }
        }

        return null;
    }
}
