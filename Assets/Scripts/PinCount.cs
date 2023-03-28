using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCount : MonoBehaviour
{
    //put on trigger at the back for when the ball goes through it?
    
    public GameObject[] m_activePins;

    private void CountPins()
    {
        m_activePins = GameObject.FindGameObjectsWithTag("Pin");
        Debug.Log(m_activePins.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            CountPins();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            CountPins();
        }
    }
}
