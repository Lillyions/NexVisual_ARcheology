using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitialSetup : MonoBehaviour
{


    [SerializeField] private float requiredArea;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject startExperienceUI;
    [SerializeField] private StartExperience startExperience;

    void OnEnable()
    {
        planeManager.planesChanged += OnPlanesUpdetad;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesUpdetad;
    }

    public void OnClickStartExperience()
    {
        Debug.Log("EIniciando a experiência AR...");
        startExperienceUI.SetActive(false);
        planeManager.enabled = false;

        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        startExperience.OnStartExperience(GetBiggestPlane());
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

    private ARPlane GetBiggestPlane()
    {
        ARPlane biggestPlane = null;
        float biggestArea = 0f;

        foreach (var plane in planeManager.trackables)
        {
            float area = plane.size.x * plane.size.y;
            if (area > biggestArea)
            {
                biggestArea = area;
                biggestPlane = plane;
            }
        }

        return biggestPlane;
    }
}
