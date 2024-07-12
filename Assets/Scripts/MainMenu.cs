using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public static string mod;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    public void ModSec(string secim)
    {

        mod = secim; 

    }

    public void PlayGame() 
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
