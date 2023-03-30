using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperButton : MonoBehaviour
{
    [SerializeField] private GameObject[] m_bumpers;

    public void ButtonPressed()
    {
        Debug.Log("Pressed");

        for (int i = 0; i < m_bumpers.Length; i++)
        {
            if (m_bumpers[i].activeInHierarchy)
            {
                m_bumpers[i].SetActive(false);
            }
            else
            {
                m_bumpers[i].SetActive(true);
            }
        }
    }

    public void ButtonReleased()
    {
        Debug.Log("Released");
    }
}
