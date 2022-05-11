using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Interactions : MonoBehaviour
{
    //VARS
    public GameObject dropdownMenu;

    [SerializeField] private GameObject interObj;
    private bool interacting = false;
    private RaycastHit hitPoint;
    private Vector3 screenPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

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

            Debug.Log("You can hack");

            if (Input.GetMouseButtonDown(1) && !interacting)
            {
                interacting = true;
                dropdownMenu.SetActive(true);
                dropdownMenu.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            }
        }
        else if(Input.GetMouseButtonDown(1) && interacting)
        {
            interacting = false;
            dropdownMenu.SetActive(false);
        }

    }

    void OpenDropdownMenu()
    {
        Object.Instantiate<GameObject>(dropdownMenu);
    }

    private void OnGUI()
    {
        
    }
}
