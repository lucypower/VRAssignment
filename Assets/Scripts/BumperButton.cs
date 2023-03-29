using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperButton : MonoBehaviour
{
    public void ButtonPressed()
    {
        Debug.Log("Pressed");
    }

    public void ButtonReleased()
    {
        Debug.Log("Released");
    }
}
