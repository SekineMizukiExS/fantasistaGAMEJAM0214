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
            //下記の40.0fを変更すれば回転角を指定できます。（ランダム値、右スティックの値など）
            //Quaternion q = Quaternion.Euler(0.0f, 40.0f, 0.0f);
            //下の二行を実行してください。instantiateでは発射元の位置と角度を渡してください。Fireでは発射元のGameObjectと発射元が爆弾かどうかのboolを渡してください
            //Instantiate(bullet,transform.position,q);//角度指定するバージョン
            Instantiate(bullet, transform.position, transform.rotation);//現在の角度で発射されるバージョン
            bullet.GetComponent<Bullet>().Fire(gameObject,true);
        }
    }
}
