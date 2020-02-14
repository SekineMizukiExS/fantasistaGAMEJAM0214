using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController2 : MonoBehaviour
{
    public GameObject[] DoubutuT;
    public GameObject dropanimal;
    public float timeOut;
    public float timeElapsed;
    private ParticleSystem particle;//パーティクル
    public int Hp;//Ｈｐの格納変数
    public bool HpZero;//Hpが0かどうか
    // Use this for initialization
    void Start()
    {
        timeOut = 5.0f;
        HpZero = false;
    }

    // Update is called once per frame
    void Update()
    {
        CreateBomb();
        HpMgr();
    }
    void CreateBomb()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            float x = Random.Range(-10.0f, 10.0f);
            float y = Random.Range(-10.0f, 10.0f);
            float z = Random.Range(-10.0f, 10.0f);
            dropanimal = DoubutuT[Random.Range(0, DoubutuT.Length)];
            Instantiate(dropanimal, new Vector3(x, y, z), transform.rotation);
            timeElapsed = 0.0f;
            if (timeOut > 2.0f)
            {
                timeOut -= 0.5f;
            }
        }

    }
    void HitPlayerBullet()
    {
        Hp = 0;
    }
    void HitBombBullet()
    {
        Hp--;
    }
    void HpMgr()
    {
        if(Hp <= 0)
        {
            HpZero = true;
        }
        if(Input.anyKey)
        {
            HpZero = true;
        }
    }
   public bool GetHpZero()
    {
        return HpZero;
    }
}

