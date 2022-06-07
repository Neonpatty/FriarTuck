using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMenu : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI tMP;
    [SerializeField] private string inputText;

    private void Awake()
    {
        tMP = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void GetInput()
    {
        inputText = tMP.text;
        Debug.Log(inputText);

        if (inputText == "HELLO")
        {
            Debug.Log("Loading Level");
        }
    }
}
