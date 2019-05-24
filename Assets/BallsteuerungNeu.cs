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
    public Rigidbody rBody;
    public Rigidbody rb;
    public GameObject BlueWall;
    public GameObject Explosion_A;
    public int countBlue;
    private int countRed;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        countBlue = 0;
        countRed = 0;
        countdown = 0;
        Explosion_A.SetActive(false);


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
            if (countBlue == 3)
            {
                BlueWall.SetActive(false);
                Explosion_A.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("Sprung"))
        {
            countdown = 0f;
        }
        if (other.gameObject.CompareTag("FLAMMENDESTODES"))
        {
            Restart();
        }
    }


    //Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
