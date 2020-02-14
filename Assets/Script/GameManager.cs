using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Winner
    {
        _battle,//戦闘中、勝敗未決
        _1pWin,    // プレイヤーAの勝利
        _2pWin,  // プレイヤーBの勝利
        _draw,    // 引き分け
    }
    [SerializeField] Winner _winner = 0;
    [SerializeField] int _bombsCount = 0;//爆弾の総数
    [SerializeField] float _gameSpeed = 1.0f;
    [SerializeField] float _startTimer = 5.0f;
    public float _nowSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _nowSpeed = _gameSpeed * Time.deltaTime;
    }


}
