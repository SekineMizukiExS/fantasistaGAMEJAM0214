using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField]
    private GameObject bulletObject;
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private string parentName;
    public bool Fired = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Fired == true)
        {
            Debug.Log("a");
            Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
            gameObject.transform.position += velocity;
        }
    }

    //弾の生成時の処理
    public void Fire(GameObject obj, bool bomb = false)
    {
        if (bomb)//爆弾の弾の移動
        {

        }
        else//プレイヤーの弾の移動
        { 
            //位置・角度・発射元の取得
            parentName = obj.name;

            Fired = true;

        }
    }

    //弾の当たり判定
    private void OnTriggerEnter(Collider other)
    {
        if (Fired == true)
        {
            if (other.name != parentName && other.tag == "Wall" || other.tag == "Players")
            {

            }
        }
    }
}
