using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{
    [SerializeField] private GameObject tutOne;
    [SerializeField] private GameObject tutTwo;
    private bool done = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Agent" && !done)
        {
            tutOne.SetActive(false);
            tutTwo.SetActive(true);
            done = true;
        }
    }
}
