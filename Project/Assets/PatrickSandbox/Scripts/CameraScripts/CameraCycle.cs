using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCycle : MonoBehaviour
{
    //VARS
    public List<Camera> cams;
    public Camera[] cameras;
    public int currentCamIndex;

    //Awake is called before start methods
    void Awake()
    {
        AddCamera();
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
            if (currentCamIndex < cams.Count)
            {
                cams[currentCamIndex - 1].gameObject.SetActive(false);
                cams[currentCamIndex].gameObject.SetActive(true);
                Debug.Log("Camera:" + cams[currentCamIndex].GetComponent<Camera>().name + " is active");
            }
            //When you reach the end of array, go back to beginning
            else
            {
                cams[currentCamIndex - 1].gameObject.SetActive(false);
                currentCamIndex = 0;
                cams[currentCamIndex].gameObject.SetActive(true);
                Debug.Log("Camera:" + cams[currentCamIndex].GetComponent<Camera>().name + " is active");
            }
        }

        //If Q button is pressed change to next camera in array
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentCamIndex--;

            //Sets camera at current index to inactive, and sets next camera in index to active
            if (currentCamIndex > 0)
            {
                cams[currentCamIndex + 1].gameObject.SetActive(false);
                cams[currentCamIndex].gameObject.SetActive(true);
                Debug.Log("Camera:" + cams[currentCamIndex].GetComponent<Camera>().name + " is active");
            }
            //When you reach the end of array, go back to beginning
            else if(currentCamIndex < 0)
            {
                cams[currentCamIndex + 1].gameObject.SetActive(false);
                currentCamIndex = cams.Count - 1;
                cams[currentCamIndex].gameObject.SetActive(true);
                Debug.Log("Camera:" + cams[currentCamIndex].GetComponent<Camera>().name + " is active");
            }
        }
    }

    public void SetActiveCamOnStartUp()
    {
        currentCamIndex = 0;

        //Turn off all cameras, except for first one in array
        for (int i = 1; i < cams.Count; i++)
        {
            cams[i].gameObject.SetActive(false);
        }

        //If any cameras were added to array, enable the first one
        if (cams.Count > 0)
        {
            cams[0].gameObject.SetActive(true);
            Debug.Log("Camera:" + cams[0].GetComponent<Camera>().name + " is active");
        }
    }

    public void ResetCameras()
    {
        currentCamIndex = 0;

        //Turn off all cameras, except for first one in array
        for (int i = 1; i < cams.Count; i++)
        {
            cams[i].gameObject.SetActive(false);
        }

        //If any cameras were added to array, enable the first one
        if (cams.Count > 0)
        {
            cams[cams.Count - 1].gameObject.SetActive(true);
            Debug.Log("Camera:" + cams[0].GetComponent<Camera>().name + " is active");
        }
    }

    public void AddCamera()
    {
        cameras = Camera.allCameras;
        cams = new List<Camera>();
        cams.AddRange(cameras);
    }
}
