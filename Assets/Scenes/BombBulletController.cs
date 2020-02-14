using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBulletController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Bomb;
    public int FireBullet;//乱射する回数
    public int Fired;//乱射した回数
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CreateBombBullet();
    }
    void CreateBombBullet()//弾を生成する関数
    {

        if (FireBullet > Fired)
        {
            float z = Random.Range(0.0f, 360.0f);//回転のランダム
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, z));//オイラー角への変換
            bullet.GetComponent<Bullet>().Fire(gameObject, true);
            Fired++;
        }
    }
}
