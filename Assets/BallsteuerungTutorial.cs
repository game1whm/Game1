using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BallsteuerungTutorial : MonoBehaviour

{
    public float speed = 10.0f;
    public float boostforce = 30.0f;
    public float jumpforce = 30.0f;
    public Rigidbody rBody;
    float countdown;
    public int countBlue;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        countBlue = 0;
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


        //Springen
            if (Input.GetKeyDown("space"))
            {
                if (countBlue == 4)
                {
                    Vector3 jump = Vector3.zero;
                    jump.y = 1f;
                    rBody.AddRelativeForce(jump * jumpforce);
                }
            }
        }

    void OnTriggerStay(Collider other)
    {
       /*if (other.gameObject.CompareTag("Sprung"))
        {
            if (Input.GetKeyDown("b"))
            {
                Vector3 boost = Vector3.zero;
                boost.z = Input.GetAxisRaw("Vertical");
                rBody.AddRelativeForce(boost * speed * boostforce);
            }
        }*/
    }
}


