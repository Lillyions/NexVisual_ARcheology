using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInfoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private UnityEngine.UI.Image iconImage;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject panel;

    public void SetVisible(bool isVisible)
    {
        panel.SetActive(isVisible);
    }

    public void SetObjInfo(SO_ObjectInfo info)
    {
        titleText.text = info.objectTitle;
        iconImage.sprite = info.objectIcon;
        descriptionText.text = info.objectDescription;
    }
}
