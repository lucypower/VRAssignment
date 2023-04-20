using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    GameManager m_gameManager;
    Pins[] m_pinsActive;

    [SerializeField] private GameObject m_pins;
    [SerializeField] private Transform m_pinsSpawn;

    [SerializeField] private GameObject m_pinSpawned;

    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnPins();
    }

    public void SpawnPins()
    {
        m_pinSpawned = Instantiate(m_pins, m_pinsSpawn.transform.position, Quaternion.identity);
        m_pinsActive = GameObject.Find("Pins(Clone)").GetComponentsInChildren<Pins>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (m_gameManager.m_isFirstBowl)
            {
                m_gameManager.m_isFirstBowl = false;
            }
            else
            {
                m_gameManager.m_isFirstBowl = true;

                Destroy(m_pinSpawned, 1.5f);

                Invoke(nameof(SpawnPins), 2.0f);
            }
        }
    }
}
