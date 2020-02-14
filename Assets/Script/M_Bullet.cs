using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Bullet : MonoBehaviour
{
    public enum Owner
    {
        _bomb,//爆弾から出た弾
        _1p,    // プレイヤーAの弾
        _2p,  // プレイヤーBの弾
    }


    GameManager _gm;//ゲームマネージャー

    [SerializeField] public Vector3 _direction;//進行方向
    [SerializeField] float _speed = 1.0f;//進行速度
    [SerializeField] public Owner _owner = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = _direction;
        transform.position += _direction * _speed * _gm._nowSpeed;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_owner == Owner._1p || _owner == Owner._2p)
        {
            if (collision.gameObject.tag == "Bomb")
            {
                collision.GetComponent<M_bomb>().Explosion();
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
