using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_bomb : MonoBehaviour
{

    //[SerializeField] float _deleteTime = 2.0f;
    [SerializeField] GameObject _bullet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explosion()
    {
        for(int i = 0; i < 50; i++) {

            Vector3 direction = new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f, 1.0f),0);
            direction.Normalize();

            GameObject insB = Instantiate(_bullet,transform.position,Quaternion.identity);
            insB.GetComponent<M_Bullet>()._direction = direction;

        }
    }
}
