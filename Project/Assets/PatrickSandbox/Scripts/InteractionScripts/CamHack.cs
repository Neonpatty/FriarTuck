using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHack : MonoBehaviour
{
    [SerializeField] private GameObject camParent;
    [SerializeField] private CameraCycle cC;
    [SerializeField] private CamsMenu cM;

    private bool hacked = false;

    private void OnMouseOver()
    {
        gameObject.GetComponent<Outline>().enabled = true;

        if (Input.GetMouseButtonDown(1) && !hacked)
        {
            hacked = true;
            camParent.AddComponent<Camera>();
            Camera cam = (Camera)camParent.GetComponent<Camera>();
            cC.cams.Add(cam);
            cC.ResetCameras();
            cM.UpdateCams();
        }
        else if (Input.GetMouseButtonDown(1) && hacked)
        {
            Debug.Log("Already have hacked this cam");
        }

    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }
}
