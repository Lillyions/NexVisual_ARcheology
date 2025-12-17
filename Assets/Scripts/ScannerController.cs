using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerController : MonoBehaviour
{
    [SerializeField] private SpotController spot;
    [SerializeField] private float scanDuration = 3f;
    [SerializeField] private GameObject scanUI;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            TryToPutOnSpot(collision.gameObject);
        }

    }

    private void TryToPutOnSpot(GameObject obj)
    {
        if (!spot.isOccupied())
        {
            obj.transform.SetParent(spot.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            if (obj.TryGetComponent<Rigidbody>(out Rigidbody body))
            {
                body.isKinematic = true;
            }

            StartCoroutine(StartScanning());
        }
    }

    private IEnumerator StartScanning()
    {
        Debug.Log("Started Scanning...");
        animator.SetBool("isScanning", true);
        scanUI.SetActive(false);

        yield return new WaitForSeconds(scanDuration);
        
        animator.SetBool("isScanning", false);
        scanUI.SetActive(true);
        Debug.Log("Scanning Complete.");
    }
}
