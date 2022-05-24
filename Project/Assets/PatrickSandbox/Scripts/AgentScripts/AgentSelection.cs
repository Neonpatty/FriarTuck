using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSelection : MonoBehaviour
{
    public GameObject selectedAgent;

    public void SelectedAgent(GameObject agentToSelect)
    {
        selectedAgent = agentToSelect;
    }

    public void DeselectAgent()
    {
        selectedAgent.GetComponent<AgentController>().DeselectAgent();
        selectedAgent = null;
    }
}
