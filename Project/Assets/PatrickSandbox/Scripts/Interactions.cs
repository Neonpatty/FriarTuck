using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Interactions : MonoBehaviour
{
    //VARS
    public GameObject dropdownMenu;
    public GameObject buttonOutline;

    [SerializeField] private GameObject interObj;
    private bool interacting = false;
    private RaycastHit hitPoint;


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
            buttonOutline.GetComponent<Outline>().enabled = true;

            if (Input.GetMouseButtonDown(1) && !interacting)
            {
                interacting = true;
                dropdownMenu.SetActive(true);
                dropdownMenu.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
        }
        else if(Input.GetMouseButtonDown(1) && interacting)
        {
            interacting = false;
            dropdownMenu.SetActive(false);
        }
        else
        {
            buttonOutline.GetComponent<Outline>().enabled = false;
            return;
        }

    }

    public void OnMouseOver(Collider collider)
    {
        if(collider.gameObject.tag == "Interactable")
        {
            buttonOutline.GetComponent<Outline>().enabled = true;
            Debug.Log("Hello");
        }
        else
        {
            buttonOutline.GetComponent<Outline>().enabled = false;
        }
    }
}
