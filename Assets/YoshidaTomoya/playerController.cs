using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float playerMoveSpeed = 0.0f;

    Vector3 playerMove;
    float delta;

    // Start is called before the first frame update
    void Start()
    {
        delta = Time.deltaTime;
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
                playerMove.y += Input.GetAxis("Vertical") * playerMoveSpeed * delta;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                playerMove.x += Input.GetAxis("Horizontal") * playerMoveSpeed * delta;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                playerMove.y += Input.GetAxis("Vertical") * playerMoveSpeed * delta;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                playerMove.x += Input.GetAxis("Horizontal") * playerMoveSpeed * delta;
            }

            playerMove.z = 1.0f;

            playerMoveResult(playerMove);

        }

        if(Input.GetAxis("Vertical2") == 0 && Input.GetAxis("Horizontal2") == 0)
        {
            Debug.Log("弾出てない");
        }
        else
        {
            if (Input.GetAxis("Vertical2") > 0)
            {
                Debug.Log("前に弾");
            }
            if (Input.GetAxis("Horizontal2") > 0)
            {
                Debug.Log("右に弾");
            }
            if (Input.GetAxis("Vertical2") < 0)
            {
                Debug.Log("後ろに弾");
            }
            if (Input.GetAxis("Horizontal2") < 0)
            {
                Debug.Log("左に弾");
            }

        }
    }

    public void playerMoveResult(Vector3 move)
    {
       Transform transComp = GetComponent<Transform>();

       transComp.localPosition = (move); 
    }
}
