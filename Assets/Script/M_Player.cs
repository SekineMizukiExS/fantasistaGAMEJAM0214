using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Player : MonoBehaviour
{
    [SerializeField] int _playerNo;
    [SerializeField] int _HP = 10;

    GameManager _gm;
    public Vector3 _inputAxis;
    public Vector3 _inputAxis2;
    [SerializeField] float _speed = 3.0f;
    Vector2 velocity2D = new Vector2(0,0);
    Quaternion targetDirection = Quaternion.identity;

    [SerializeField] GameObject _bullet;
    [SerializeField] float _shotCT = 0.5f;
    [SerializeField] float _shotCTcount = 0.0f;

    [SerializeField] GameObject _visual;
    [SerializeField] Image _HPbar;

    int _padNo = 1;

    AudioSource _audioSource;
    [SerializeField]AudioClip[] _audioclips;
                         
    void Start()                         
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(_playerNo == playerSetter.playerPad1)
        {
            _padNo = 1;
        }else if (_playerNo == playerSetter.playerPad2)
        {
            _padNo = 2;
        }
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHP();
        if (_padNo == 1) {
            PlayerMove(1);
            PlayerShot(1);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
        }else if (_padNo == 2) { 
            PlayerMove(2);
            PlayerShot(2);
            
        }

    }

    public void PlayerMove(int no)
    {

        _inputAxis.x = Input.GetAxis("Horizontal_P" + no.ToString());
        _inputAxis.y = Input.GetAxis("Vertical_P" + no.ToString());
        _inputAxis.Normalize();


        transform.position += _inputAxis * _speed * _gm._nowSpeed;
        if (_inputAxis.magnitude >= 0.1f)
        {
            velocity2D = (Vector2)_inputAxis;
            targetDirection = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(Vector2.up, velocity2D));

        }
        _visual.transform.localRotation = Quaternion.Slerp(_visual.transform.localRotation, targetDirection, 0.1f);


    }
    void PlayerShot(int no)
    {
        _inputAxis2.x = Input.GetAxis("Horizontal2_P" + no.ToString());
        _inputAxis2.y = Input.GetAxis("Vertical2_P" + no.ToString());
        _inputAxis2.Normalize();

        if (_inputAxis2.magnitude >= 0.1f && _shotCT < _shotCTcount)
        {
            _audioSource.PlayOneShot(_audioclips[0]);

            GameObject insB = Instantiate(_bullet, transform.position, transform.localRotation);
            insB.GetComponent<M_Bullet>()._direction = _inputAxis2;
            switch (_playerNo) {
                case 1:
                    insB.GetComponent<M_Bullet>()._owner = M_Bullet.Owner._1p;
                    break;
                case 2:
                    insB.GetComponent<M_Bullet>()._owner = M_Bullet.Owner._2p;
                    break;
            }
            _shotCTcount = 0;
        }
        else
        {
            _shotCTcount += 1 * Time.deltaTime;
        }
    }


    public int GetPlayerNo()
    {
        return _playerNo;
    }

    public void SetPlayerNo(int n)
    {
        _playerNo = n;
    }

    public void SetHP(int hp)
    {
        _HP = hp;
    }
    public void AddDamage(int damage)
    {
        _audioSource.PlayOneShot(_audioclips[1]);
        _HP -= damage;
    }
    public void CheckHP()
    {
        _HPbar.fillAmount = (float)_HP / 10.0f;

        if(_HP <= 0)
        {
            switch (_playerNo)
            {
                case 1:
                    _gm.Judge(GameManager.Winner._2pWin);
                    break;
                case 2:
                    _gm.Judge(GameManager.Winner._1pWin);
                    break;
            }

        }
    }


}
