using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool m_isFirstBowl;

    private void Awake()
    {
        m_isFirstBowl = true;
    }
}
