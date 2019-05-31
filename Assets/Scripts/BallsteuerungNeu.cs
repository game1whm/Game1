using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BallsteuerungNeu : MonoBehaviour

{
    public float speed = 10.0f;
    public float boostforce = 30.0f;
    public float jumpforce = 30.0f;
    float countdown;
    private int lives;
    float countHeart;
    private Rigidbody rBody;
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
    public GameObject Heart;
    public GameObject HeartAdd;
    public int countBlue;
    public Text Leben;

    //private int countRed;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        //rb = GetComponent<Rigidbody>();
        countBlue = 0;
        //countRed = 0;
        countdown = 0;

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

        Heart.SetActive(false);
        HeartAdd.SetActive(true);
        lives = 5;
        Leben.text = "Leben : " + lives.ToString();
    }
    // Update is called once per frame
    void Update()
    {
     
        countHeart++;

        if (countHeart == 60)
        {
            Heart.SetActive(false);
        }

        if (lives == 0)
        {
            Restart();
        }


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
        if (transform.position.y < -25
        )
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
            if (countBlue == 4)
            {
                Portal.SetActive(true);
            }
        }
        if(countBlue==1)
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

        if ( countBlue== 5)
        {
            Magicfireproblue5.SetActive(true);
            Magicfire35.SetActive(false);
            Portal.SetActive(true);
        }
        if (other.gameObject.CompareTag("Sprung"))
        {
            countdown = 0f;
        }


        if (other.gameObject.CompareTag("FLAMMENDESTODES"))
        {
            lives--;
            Heart.SetActive(true);
            countHeart = 0;
            Leben.text = "Leben : " + lives.ToString();
            transform.position = new Vector3(1f, 3f, 90f);
        }

        if (other.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("OpenWorld");
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            lives++;
            HeartAdd.SetActive(false);
            Leben.text = "Leben : " + lives.ToString();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Sprung"))
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
