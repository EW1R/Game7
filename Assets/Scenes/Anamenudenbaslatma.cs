using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anamenudenbaslatma : MonoBehaviour
{
    public void Oyunubaslat()
    {
        SceneManager.LoadScene(1);
    }
    public void OyunuKapat()
    {
        Application.Quit();
    }
}
