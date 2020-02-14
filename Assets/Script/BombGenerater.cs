using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerater : MonoBehaviour
{
    [SerializeField] GameObject _bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 genpos = new Vector2(Random.Range(-30.0f,30.0f),Random.Range(-30.0f,30.0f));

        Instantiate(_bomb, genpos, Quaternion.identity);
    }
}
