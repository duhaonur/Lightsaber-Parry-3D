using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextController : MonoBehaviour
{
    TMP_Text text;
    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    public void LightsabersCollidingText()
    {
        text.text = "Lightsabers will collide";
    }
    public void LightsabersNotCollidingText()
    {
        text.text = "Lightsabers won't collide";
    }

    public void DisplayText()
    {
        text.enabled = true;
    }
    public void HideText()
    {
        text.enabled = false;
    }

}
