using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitialSetup : MonoBehaviour
{


    [SerializeField] private float requiredArea;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject startExperienceUI;

    void OnEnable()
    {
        planeManager.planesChanged += OnPlanesUpdetad;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesUpdetad;
    }

    // Update is called once per frame
    /*void Update()
    {
        foreach (var plane in planeManager.trackables)
        {
            if (plane.size.x * plane.size.y >= requiredArea)
            {
                //Plano detectado
                startExperienceUI.SetActive(true);
                return;
            }
        }
        //Nenhum plano detectado
        startExperienceUI.SetActive(false);
    }*/

    public void OnClickStartExperience()
    {
        Debug.Log("EIniciando a experiência AR...");
        startExperienceUI.SetActive(false);
        planeManager.enabled = false;

        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }

    private void OnPlanesUpdetad(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in planeManager.trackables)
        {
            if (plane.size.x * plane.size.y >= requiredArea)
            {
                //Plano detectado
                startExperienceUI.SetActive(true);
            }
        }
    }
}
