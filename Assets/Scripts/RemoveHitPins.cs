using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHitPins : MonoBehaviour
{
    Pins[] m_pins;
    public bool m_bowling = true;
    // TODO: NEED SOMETHING TO LET THIS KNOW TO GET ARRAY OF PINS ON FIRST ROLL< NEED BOOL SOMEWHERE

    public GameObject[] m_activePins; // TODO: could turn to a list once instantiating pins is implemented
  
    private void Update()
    {
        if (m_bowling)
        {
            m_bowling = false;

            m_pins = GameObject.Find("Pins").GetComponentsInChildren<Pins>();
        }
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
            for (int i = 0; i < m_pins.Length; i++)
            {
                if (m_pins[i].m_isKnockedOver)
                {
                    Destroy(m_pins[i].gameObject);
                    m_bowling = true;
                    Invoke(nameof(CountPins), 0.5f);
                }
            }
        }
    }

    private void CountPins()
    {
        m_activePins = GameObject.FindGameObjectsWithTag("Pin");
        Debug.Log(m_activePins.Length);
    }
}
