using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHack : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private bool hacked = false;

    private void OnMouseOver()
    {
        gameObject.GetComponent<Outline>().enabled = true;

        if(Input.GetMouseButtonDown(1) && !hacked)
        {
            hacked = true;
            HackDoor();
            ButtonColour();
        }
        else if (Input.GetMouseButtonDown(1) && hacked)
        {
            hacked = false;
            HackDoor();
            ButtonColour();
        }
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }

    private void HackDoor()
    {
        Animator ani = door.GetComponent<Animator>();
        if (ani.GetBool("Hacked") == false)
            ani.SetBool("Hacked", true);
        else
            ani.SetBool("Hacked", false);
    }

    private void ButtonColour()
    {
        var cubeColour = gameObject.GetComponent<Renderer>().material;
        if (!hacked)
            cubeColour.color = Color.red;
        else
            cubeColour.color = Color.green;
    }
}
