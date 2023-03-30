using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    PinCount m_pinCount;
    GameManager m_gameManager;
    [SerializeField] private TMP_Text m_text;

    public int m_score;
    private int m_pinsKnockedDown;


    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_pinCount = GetComponent<PinCount>();
    }

    private void Update()
    {
        m_text.text = "Score : " + m_score;
    }

    public void CalculateScore()
    {
        int pinsStillUp = m_pinCount.CountPins();

        if (m_gameManager.m_isFirstBowl)
        {
            m_pinsKnockedDown = 10 - pinsStillUp;

            m_score += m_pinsKnockedDown;
        }
        else
        {
            m_pinsKnockedDown -= pinsStillUp;

            m_score += m_pinsKnockedDown;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            CalculateScore();
        }
    }
}
