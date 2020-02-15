using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlescript : MonoBehaviour
{
    [SerializeField] string _Stagename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ButtonA_P1"))
        {
            playerSetter.playerPad1 = 1;
            playerSetter.playerPad2 = 2;
            SceneManager.LoadScene(_Stagename);
        }
        if (Input.GetButtonDown("ButtonA_P2"))
        {
            playerSetter.playerPad1 = 2;
            playerSetter.playerPad2 = 1;
            SceneManager.LoadScene(_Stagename);
        }
    }
}
