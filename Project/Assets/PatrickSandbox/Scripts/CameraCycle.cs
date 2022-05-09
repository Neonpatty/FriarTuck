using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCycle : MonoBehaviour
{
    //VARS


    [SerializeField] private Camera[] cams;
    private int currentCamIndex;

    //Awake is called before start methods
    void Awake()
    {
        cams = Camera.allCameras;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetActiveCamOnStartUp();
    }

    // Update is called once per frame
    void Update()
    {
        CycleCamera();
    }

    void CycleCamera()
    {
        //If E button is pressed change to next camera in array
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentCamIndex++;

            //Sets camera at current index to inactive, and sets next camera in index to active
            if (currentCamIndex < cams.Length)
            {
                cams[currentCamIndex - 1].gameObject.SetActive(false);
                cams[currentCamIndex].gameObject.SetActive(true);
                Debug.Log("Camera:" + cams[currentCamIndex].GetComponent<Camera>().name + "is active");
            }
            //When you reach the end of array, go back to beginning
            else
            {
                cams[currentCamIndex - 1].gameObject.SetActive(false);
                currentCamIndex = 0;
                cams[currentCamIndex].gameObject.SetActive(true);
                Debug.Log("Camera:" + cams[currentCamIndex].GetComponent<Camera>().name + "is active");
            }
        }

        //If Q button is pressed change to next camera in array
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentCamIndex--;

            //Sets camera at current index to inactive, and sets next camera in index to active
            if (currentCamIndex < cams.Length)
            {
                cams[currentCamIndex + 1].gameObject.SetActive(false);
                cams[currentCamIndex].gameObject.SetActive(true);
                Debug.Log("Camera:" + cams[currentCamIndex].GetComponent<Camera>().name + "is active");
            }
            //When you reach the end of array, go back to beginning
            else
            {
                cams[currentCamIndex + 1].gameObject.SetActive(false);
                currentCamIndex = cams.Length - 1;
                cams[currentCamIndex].gameObject.SetActive(true);
                Debug.Log("Camera:" + cams[currentCamIndex].GetComponent<Camera>().name + "is active");
            }
        }
    }

    void SetActiveCamOnStartUp()
    {
        currentCamIndex = 0;

        //Turn off all cameras, except for first one in array
        for (int i = 1; i < cams.Length; i++)
        {
            cams[i].gameObject.SetActive(false);
        }

        //If any cameras were added to array, enable the first one
        if (cams.Length > 0)
        {
            cams[0].gameObject.SetActive(true);
            Debug.Log("Camera:" + cams[0].GetComponent<Camera>().name + "is active");
        }
    }
}
