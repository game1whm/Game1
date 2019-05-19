using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kameraverfolgt : MonoBehaviour
{
    public GameObject player;
    public float distanceBehind = 2f;
    public float heightAbove = 3f;
    public float lookAtBefore = 2f;
    Vector3 playerPrevPos, playerMoveDir;

    // Use this for initialization
    void Start()
    {
        playerPrevPos = player.transform.position;
    }
    void LateUpdate()
    {
        playerMoveDir = player.transform.position - playerPrevPos;
        if (playerMoveDir != Vector3.zero)
        {
            playerMoveDir.Normalize();
            playerMoveDir.Normalize();
            Vector3 newPos = player.transform.position - playerMoveDir * distanceBehind;
            Vector3 newLookat = player.transform.position + playerMoveDir * lookAtBefore;
            newPos.y += heightAbove; // required height
            transform.position = newPos;
            // where to look

            transform.LookAt(newLookat);

            playerPrevPos = player.transform.position;
        }
    }
}
