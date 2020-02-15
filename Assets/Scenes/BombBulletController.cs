using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBulletController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Bomb;
    public int FireBullet;//乱射する回数
    public int Fired;//乱射した回数
    public int Hp;//Ｈｐの格納変数
    public bool HpZero;//Hpが0かどうか
    // Start is called before the first frame update
    void Start()
    {
        HpZero = false;
    }

    // Update is called once per frame
    void Update()
    {
        CreateBombBullet();
        HpMgr();

    }
    public  void CreateBombBullet()//弾を生成する関数
    {

        if (FireBullet > Fired && HpZero == true)
        {
            float z = Random.Range(0.0f, 360.0f);//回転のランダム
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, z));//オイラー角への変換
            bullet.GetComponent<Bullet>().Fire(gameObject, true);
            Fired++;
        }
    }
    public void HitPlayerBullet()
    {
        Hp = 0;
    }
    public void HitBombBullet()
    {
        Hp--;
    }
    public void HpMgr()
    {
        if (Hp <= 0)
        {
            HpZero = true;
        }
        if (Input.anyKey)
        {
            HpZero = true;
        }
    }
    public bool GetHpZero()
    {
        return HpZero;
    }

}
