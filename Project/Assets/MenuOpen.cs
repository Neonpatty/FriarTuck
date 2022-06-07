using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] private Animator menuAni;
    private bool isOpen = false;

    private void Awake()
    {
        menuAni = gameObject.GetComponent<Animator>();    
    }

    public void OpenMenu()
    {
        if (!isOpen)
        {
            menuAni.SetBool("clicked", true);
            isOpen = true;
        }
        else
        {
            menuAni.SetBool("clicked", false);
            isOpen= false;
        } 
    }
}