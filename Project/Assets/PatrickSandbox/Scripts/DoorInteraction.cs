using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    //VARS
    public GameObject dropdownMenu;
    public GameObject buttonPrefab;

    [SerializeField] private GameObject interObj;
    [SerializeField] private Transform buttonParent;
    [SerializeField] private CameraCycle cC;

    private GameObject button;
    private bool interacting = false;
    private RaycastHit hitPoint;

    // Update is called once per frame
    void Update()
    {
        ClickToOpen();
    }

    void ClickToOpen()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitPoint);

        if (hitPoint.collider.tag == "Interactable")
        {
            this.gameObject.GetComponent<Outline>().enabled = true;

            if (Input.GetMouseButtonDown(1) && !interacting)
            {
                interacting = true;
                dropdownMenu.SetActive(true);
                button = Instantiate(buttonPrefab);
                button.transform.SetParent(buttonParent);
                button.GetComponent<Button>().onClick.AddListener(DoorHackSuccess);
                //dropdownMenu.GetComponent<RectTransform>().position = Camera.main.ScreenToViewportPoint(Input.mousePosition.x,Input.mousePosition.y);
            }
        }
        else if (Input.GetMouseButtonDown(1) && interacting)
        {
            interacting = false;
            dropdownMenu.SetActive(false);
            Destroy(button);
        }
        else
        {
            this.gameObject.GetComponent<Outline>().enabled = false;
            Debug.Log("No Interactable");
            return;
        }

    }

    public void DoorHackSuccess()
    {
        if (interObj.tag == "Door")
        {
            Animator ani = interObj.GetComponent<Animator>();
            if (ani.GetBool("Hacked") == false)
                ani.SetBool("Hacked", true);
            else
                ani.SetBool("Hacked", false);
        }

        interacting = false;
        dropdownMenu.SetActive(false);
        Destroy(button);
    }
}
