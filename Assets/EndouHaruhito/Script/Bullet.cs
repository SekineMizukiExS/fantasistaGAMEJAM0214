using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField]
    private GameObject bulletObject;
    [SerializeField]
    private float speed = 100.0f;
    [SerializeField]
    private string parentName;
    [SerializeField]
    private float timeLimit = 2;
    private float timer = 0;
    public bool Fired = false;
    public bool wallHit = false;
    public bool thisBomb;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeLimit && thisBomb == true)
        {
            //時間経過による消滅（爆弾のみ）
        }

        if (Fired == true && wallHit == false)
        {
            //前方に向かって移動
            Debug.Log("a");
            Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
            gameObject.transform.position += velocity * Time.deltaTime;
        }
        else if (wallHit == true && thisBomb == true)
        {
            //爆弾の弾だった場合の反射
            Debug.Log("b");
            Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
            gameObject.transform.position -= velocity * Time.deltaTime;
        }else if (wallHit == true && thisBomb == false)
        {
            //プレイヤーの飛ばした弾と壁が当たった場合の処理
        }
    }

    //弾の生成時の処理
    public void Fire(GameObject obj, bool bomb = false)
    {
        if (bomb)//爆弾の弾の移動
        {
            thisBomb = true;
            Fired = true;
        }
        else//プレイヤーの弾の移動
        { 
            //位置・角度・発射元の取得
            parentName = obj.name;
            thisBomb = false;
            Fired = true;
        }
    }

    //弾の当たり判定
    private void OnTriggerEnter(Collider other)
    {
        if (Fired == true)
        {
            if (other.name != parentName)
            {
                switch(other.tag)
                {
                    case "Wall":
                        wallHit = true;
                        break;
                    case "Players":
                        //相手プレイヤーとの衝突（ダメージ関数？）
                        break;
                    case "Bomb":
                        //爆弾との衝突（ダメージ関数？）
                        break;
                        
                }
            }
        }
    }
}
