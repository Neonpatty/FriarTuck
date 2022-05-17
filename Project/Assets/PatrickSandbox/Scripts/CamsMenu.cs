using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CamsMenu : MonoBehaviour
{
    //VARS
    public CameraCycle cC;
    public Button buttonPrefab;
    public Transform buttonParent;

    private int camIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera cam in cC.cams)
        {
            if (cam != null) 
            {
                Button newButton = Instantiate<Button>(buttonPrefab);
                newButton.transform.SetParent(buttonParent);
                SetCam sC = newButton.GetComponent<SetCam>();
                sC.camIndex = camIndex;
                camIndex++;
            }            
        }
    }

    public void UpdateCams()
    {
        foreach (Camera cam in cC.cams)
        {
            if (cam != null)
            {
                Button newButton = Instantiate<Button>(buttonPrefab);
                newButton.transform.SetParent(buttonParent);
                SetCam sC = newButton.GetComponent<SetCam>();
                sC.camIndex = camIndex;
                camIndex++;
            }
        }
    }
}
