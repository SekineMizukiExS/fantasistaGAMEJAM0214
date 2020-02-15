using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Player : MonoBehaviour
{
    GameManager _gm;
    Vector3 _inputAxis;
    Vector3 _inputAxis2;
    [SerializeField] float _speed = 3.0f;
    Vector2 velocity2D = new Vector2(0,0);
    Quaternion targetDirection = Quaternion.identity;

    [SerializeField] GameObject _bullet;


    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputAxis.x = Input.GetAxis("Horizontal");
        _inputAxis.y = Input.GetAxis("Vertical");
        _inputAxis.Normalize();


        transform.position += _inputAxis * _speed * _gm._nowSpeed;
        if (_inputAxis.magnitude >= 0.1f) {
            velocity2D = (Vector2)_inputAxis;
            targetDirection = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(Vector2.up, velocity2D));
            
        }
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetDirection, 0.1f);


        _inputAxis2.x = Input.GetAxis("Horizontal２");
        _inputAxis2.y = Input.GetAxis("Vertical2");
        _inputAxis2.Normalize();

        if (_inputAxis2.magnitude >= 0.1f)
        {
            GameObject insB = Instantiate(_bullet, transform.position, transform.localRotation);
            insB.GetComponent<M_Bullet>()._direction = _inputAxis2;
            insB.GetComponent<M_Bullet>()._owner = M_Bullet.Owner._1p;
        }
    }
}
