using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager _gm;
    Vector3 _inputAxis;
    [SerializeField] float _speed = 3.0f;
    public Quaternion rot;

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
            var velocity2D = (Vector2)_inputAxis;
            var targetDirection = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(Vector2.up, velocity2D));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetDirection, 0.1f);
        }
    }
}
