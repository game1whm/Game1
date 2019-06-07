using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PlayerController : MonoBehaviour

{







    public float speed = 10.0f;

    public float boostforce = 30.0f;

    public float jumpforce = 30.0f;

    public Rigidbody rBody;

    // Start is called before the first frame update

    void Start()

    {

        rBody = GetComponent<Rigidbody>();

    }



    // Update is called once per frame

    void Update()

    {

        float turn = Input.GetAxis("Horizontal");

        transform.Rotate(0.0f, turn * 2, 0.0f, Space.Self);



        // Vorwärts/Rückwärts

        Vector3 controlSignal = Vector3.zero;

        controlSignal.z = Input.GetAxisRaw("Vertical");

        rBody.AddRelativeForce(controlSignal * speed);

    }

}
