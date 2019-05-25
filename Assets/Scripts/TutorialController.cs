using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TutorialController : MonoBehaviour

{
   



    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        // Restart einleiten
        if (Input.GetKey("r"))
        {
            Restart();
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

   

    //Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
