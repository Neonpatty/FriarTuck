using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteract : MonoBehaviour
{
    [SerializeField] InteractableObjects objInfo;
    private GameObject interObj;
    private Transform objParent;
    private GameObject buttonPrefab;
    private Transform buttonParent;
    private GameObject hackObj;

    void awake()
    {
        interObj = objInfo.interObj;
        objParent = objInfo.objParent;
        buttonPrefab = objInfo.buttonPrefab;
        buttonParent = objInfo.buttonParent;
        hackObj = objInfo.hackObj;
    }

    void OnMouseOver()
    {

    }

    void OnMouseExit()
    {
        
    }
}
