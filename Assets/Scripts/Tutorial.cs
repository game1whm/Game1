﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Tutorial : MonoBehaviour

{
    public float speed = 10.0f;
    public float boostforce = 30.0f;
    public float jumpforce = 30.0f;
    float countdown;
    public Rigidbody rBody;
    public Rigidbody rb;
    public GameObject Portal;
    public GameObject Magicfireproblue1;
    public GameObject Magicfireproblue2;
    public GameObject Magicfireproblue3;
    public GameObject Magicfireproblue4;
    public GameObject Magicfireproblue5;
    public GameObject Magicfire31;
    public GameObject Magicfire32;
    public GameObject Magicfire33;
    public GameObject Magicfire34;
    public GameObject Magicfire35;
    public GameObject BlueWall;
    public int countBlue;
    //private int countRed;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        countBlue = 0;
        //countRed = 0;
        countdown = 1;

        Magicfireproblue1.SetActive(false);
        Magicfireproblue2.SetActive(false);
        Magicfireproblue3.SetActive(false);
        Magicfireproblue4.SetActive(false);
        Magicfireproblue5.SetActive(false);
        Magicfire31.SetActive(true);
        Magicfire32.SetActive(true);
        Magicfire33.SetActive(true);
        Magicfire34.SetActive(true);
        Magicfire35.SetActive(true);

        Portal.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

        // Drehen
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0.0f, turn * 2, 0.0f, Space.Self);

        // Vorwärts/Rückwärts
        Vector3 controlSignal = Vector3.zero;
        controlSignal.z = Input.GetAxisRaw("Vertical");
        rBody.AddRelativeForce(controlSignal * speed);



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

        //Springen
        if (Input.GetKeyDown("space"))
        {
            if (countdown < 1)
            {
                Vector3 jump = Vector3.zero;
                jump.y = 1f;
                rBody.AddRelativeForce(jump * jumpforce);
                countdown = 1;

            }



        }
    }
    public void LateUpdate()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TargetBlue"))
        {
            other.gameObject.SetActive(false);
            countBlue = countBlue + 1;
            if (countBlue == 5)
            {
                BlueWall.gameObject.SetActive(false);
                Portal.gameObject.SetActive(true);
            }
        }
        if (countBlue == 1)
        {
            Magicfireproblue1.SetActive(true);
            Magicfire31.SetActive(false);
        }
        if (countBlue == 2)
        {
            Magicfireproblue2.SetActive(true);
            Magicfire32.SetActive(false);
        }
        if (countBlue == 3)
        {
            Magicfireproblue3.SetActive(true);
            Magicfire33.SetActive(false);
        }
        if (countBlue == 4)
        {
            Magicfireproblue4.SetActive(true);
            Magicfire34.SetActive(false);

        }

        if (countBlue == 5)
        {
            Magicfireproblue5.SetActive(true);
            Magicfire35.SetActive(false);

        }
        if (other.gameObject.CompareTag("Sprung"))
        {
            countdown = 0f;
        }


        if (other.gameObject.CompareTag("FLAMMENDESTODES"))
        {
            Restart();
        }

        if (other.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("OverWorld");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            if (Input.GetKeyDown("b"))
            {
                Vector3 boost = Vector3.zero;
                boost.z = Input.GetAxisRaw("Vertical");
                rBody.AddRelativeForce(boost * speed * boostforce);
            }
        }
        if (other.gameObject.CompareTag("Sprung"))
        {
            countdown = 0f;
        }

    }


    //Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
