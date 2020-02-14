using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float playerMoveSpeed = 0.0f;

    Vector3 playerMove;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
        }
        else
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                playerMove.y += Input.GetAxis("Vertical") * playerMoveSpeed;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                playerMove.x += Input.GetAxis("Horizontal") * playerMoveSpeed;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                playerMove.y += Input.GetAxis("Vertical") * playerMoveSpeed;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                playerMove.x += Input.GetAxis("Horizontal") * playerMoveSpeed;
            }

            playerMove.z = 1.0f;

            playerMoveResult(playerMove);

        }
    }

    public void playerMoveResult(Vector3 move)
    {
       Transform transComp = GetComponent<Transform>();

       transComp.localPosition = (move); 
    }
}
