using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Aramenuscript : MonoBehaviour
{
    public TextMeshProUGUI time1text;
    public TextMeshProUGUI time2text;

    public void devamet()
    {
        SceneManager.LoadScene(3);
    }
    
    void Update()
    {
        float zaman1 = PlayerPrefs.GetFloat("Time1");
        int dakikalar = Mathf.FloorToInt(zaman1 / 60);
        int saniyeler = Mathf.FloorToInt(zaman1 % 60);
        time1text.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);
        float zaman2 = PlayerPrefs.GetFloat("Time2");
        int dakikalar2 = Mathf.FloorToInt(zaman2 / 60);
        int saniyeler2 = Mathf.FloorToInt(zaman2 % 60);
        time2text.text = string.Format("{0:00}:{1:00}", dakikalar2, saniyeler2);
    }
}
