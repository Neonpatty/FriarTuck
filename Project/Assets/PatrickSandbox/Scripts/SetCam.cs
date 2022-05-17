using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetCam : MonoBehaviour
{
    //VARS
    public int camIndex;
    public CameraCycle cC;
    public TextMeshProUGUI nameText;

    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeCamera);
        cC = FindObjectOfType<CameraCycle>();
    }

    private void Start()
    {
        nameText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        nameText.text = ">//: " + cC.cams[camIndex].GetComponent<Camera>().name;
    }

    void ChangeCamera()
    {
        cC.cams[cC.currentCamIndex].gameObject.SetActive(false);
        cC.currentCamIndex = camIndex;
        cC.cams[camIndex].gameObject.SetActive(true);
        Debug.Log("Camera:" + cC.cams[cC.currentCamIndex].GetComponent<Camera>().name + " is active");
    }
}
