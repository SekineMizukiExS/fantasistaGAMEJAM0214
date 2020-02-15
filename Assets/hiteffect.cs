using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiteffect : MonoBehaviour
{
    float _count = 0.0f;
    float _deleteTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_count <= _deleteTime)
        {
            _count += 1 * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
