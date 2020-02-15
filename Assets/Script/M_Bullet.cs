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
    bool _reflected = false;

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


private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bomb")
        {
            collision.gameObject.GetComponent<M_bomb>().Explosion();
        }

        if (collision.gameObject.tag == "Players")
        {
            var hitplayer = collision.gameObject.GetComponent<M_Player>();
            if (_owner == Owner._1p)
            {
                if (2 == hitplayer.GetPlayerNo())
                {
                    hitplayer.AddDamage(1);
                    Destroy(gameObject);
                }
            }
            if (_owner == Owner._2p)
            {
                if (1 == hitplayer.GetPlayerNo())
                {
                    hitplayer.AddDamage(1);
                    Destroy(gameObject);
                }
            }
            if (_owner == Owner._bomb)
            {
                hitplayer.AddDamage(1);

                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (_reflected || _owner != Owner._bomb) {
                Destroy(gameObject);
                }
            else
            {
                Vector2 inNormal = collision.contacts[0].normal;
                Vector2 newVelocity = Vector2.Reflect(_direction, inNormal);
                _direction = newVelocity;
                _reflected = true;
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
