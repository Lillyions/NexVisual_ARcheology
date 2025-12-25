using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Info", menuName = "ScriptableObjects/ObjectInfo")]

public class SO_ObjectInfo : ScriptableObject
{
    [Header("Object Informations")]
    public string objectTitle;

    [TextArea]
    public string objectDescription;
}
