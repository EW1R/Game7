using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimerScript : MonoBehaviour
{
    public float gecenzaman;
    public TextMeshProUGUI timerText;
   
    void Update()
    {
        int minutes = Mathf.FloorToInt(gecenzaman / 60);
        int seconds = Mathf.FloorToInt(gecenzaman % 60);
        
        gecenzaman += Time.deltaTime;
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
