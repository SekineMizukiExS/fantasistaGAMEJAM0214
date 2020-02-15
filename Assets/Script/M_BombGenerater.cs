using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_BombGenerater : MonoBehaviour
{

    float _count = 0.0f;
    float _genCooltime = 5.0f;

    [SerializeField] GameObject _bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_genCooltime < _count)
        {
            Generate();
            _count = 0;
            if (_genCooltime >= 2.5f)
            {
                _genCooltime -= 0.5f;
            }
        }
        else
        {
            _count += 1 * Time.deltaTime;
        }
    }

    void Generate()
    {
        Vector2 genpos = new Vector2(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f));

        Instantiate(_bomb, genpos, Quaternion.identity);
    }
}
