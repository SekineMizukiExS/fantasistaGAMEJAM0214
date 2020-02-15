using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] float _finalJudgeTime = 0.5f;//最終判決　相打ち判定用に取る猶予時間
    [SerializeField] float _finalJudgeTimeCount = 0.0f;
    [SerializeField] bool _Phase_Judge;
    [SerializeField] bool _Phase_FinalJudged;

    [SerializeField] GameObject[] _1PwinUIs;
    [SerializeField] GameObject[] _2PwinUIs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _nowSpeed = _gameSpeed * Time.deltaTime;
        if (_Phase_Judge)
        {
            if(_finalJudgeTime <= _finalJudgeTimeCount)
            {
                _Phase_Judge = false;
                _Phase_FinalJudged = true;
                
                _gameSpeed = 0;
            }
            else
            {
                _finalJudgeTimeCount += 1 * Time.deltaTime;
            }
        }

        if (_Phase_FinalJudged)
        {
            if(_winner == Winner._1pWin)
            {
                _1PwinUIs[0].SetActive(true);
                _1PwinUIs[1].SetActive(true);
            }
            if (_winner == Winner._2pWin)
            {
                _2PwinUIs[0].SetActive(true);
                _2PwinUIs[1].SetActive(true);
            }
        }

        //Debugline();
    }

    public void Judge(Winner jwinner)
    {
        if (!_Phase_FinalJudged)
        {
            if (_winner == Winner._1pWin && jwinner == Winner._2pWin)
            {
                _winner = Winner._draw;
            }
            else if (_winner == Winner._2pWin && jwinner == Winner._1pWin)
            {
                _winner = Winner._draw;
            }
            else
            {
                _winner = jwinner;
            }
            _Phase_Judge = true;
        }
    }

    void Debugline()
    {
        Debug.Log("p1pad:" + Input.GetAxis("Horizontal_P1"));
        Debug.Log("p2pad:" + Input.GetAxis("Horizontal_P2"));
    }

}
