 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Ballsteuerung : MonoBehaviour
{
    public float speed = 10.0f;
    public float boostforce = 30.0f;
    Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Drehen
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0.0f, turn, 0.0f, Space.Self);
        // Vorwärts/Rückwärts
        Vector3 controlSignal = Vector3.zero;
        controlSignal.z = Input.GetAxisRaw("Vertical");
        rBody.AddRelativeForce(controlSignal * speed);

        //Boost
        if (Input.GetKeyDown("b"))
        {
            Vector3 boost = Vector3.zero;
            boost.z = Input.GetAxisRaw("Vertical");
            rBody.AddRelativeForce(boost * speed * boostforce);
        }

        // Restart einleiten
        if (Input.GetKey("r"))
        {
            Restart();
        }

        if (transform.position.y < -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Quit Game
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

