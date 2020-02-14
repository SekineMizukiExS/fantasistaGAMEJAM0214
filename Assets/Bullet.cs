using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameManager _gm;//ゲームマネージャー

    [SerializeField] Vector3 _direction;//進行方向
    [SerializeField] float _speed = 1.0f;//進行速度

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * _speed * _gm._nowSpeed;
    }
}
