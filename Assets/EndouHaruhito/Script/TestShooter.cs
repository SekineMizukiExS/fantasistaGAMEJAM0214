using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShooter : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            //下の二行を実行してください。instantiateでは発射元の位置と角度を渡してください。Fireでは発射元のGameObjectと発射元が爆弾かどうかのboolを渡してください
            Instantiate(bullet,transform.position,transform.rotation);
            bullet.GetComponent<Bullet>().Fire(gameObject,true);
        }
    }
}
