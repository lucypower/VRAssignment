using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBalls : MonoBehaviour
{
    GameManager m_gameManager;
    [SerializeField] private GameObject m_balls;
    [SerializeField] private GameObject[] m_spawnLocations;
    private bool m_ballsSpawned;

    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_ballsSpawned = false;
    }

    private void Update()
    {
        if (m_gameManager.m_isFirstBowl && !m_ballsSpawned)
        {
            m_ballsSpawned = true;

            SpawnBalls();
        }
        else if (!m_gameManager.m_isFirstBowl)
        {
            m_ballsSpawned = false;
        }
    }

    private void SpawnBalls()
    {
        for (int i = 0; i < m_spawnLocations.Length; i++)
        {
            Instantiate(m_balls, m_spawnLocations[i].transform.position, Quaternion.identity);
        }
    }
}
