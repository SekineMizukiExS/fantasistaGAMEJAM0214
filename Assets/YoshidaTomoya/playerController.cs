using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float playerMoveSpeed = 0.0f;

    GameManager gm;

    Vector3 playerMove;
    Vector3 bulletMove;
    float delta;

    Vector3 stickPos;
    Vector3 normalized;
    Vector2 velocity2D = new Vector2(0.0f, 0.0f);
    Quaternion targetDirection = Quaternion.identity;
    float z;

    float frame = 0.0f;
    public float frameRate;

    Quaternion q;

    //public GameObject _bullet; // バレットのプレハブを入れる
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        delta = Time.deltaTime;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove.x = Input.GetAxis("Horizontal");
        playerMove.y = Input.GetAxis("Vertical");
        playerMove.Normalize();

        transform.localPosition += playerMove * playerMoveSpeed * delta;
        if (playerMove.magnitude >= 0.1f)
        {
            velocity2D = playerMove;
            targetDirection = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(Vector2.up, velocity2D));

        }
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetDirection, 0.1f);


        //if (Input.GetAxis("Vertical") > 0)
        //{
        //    playerMove.y += Input.GetAxis("Vertical") * playerMoveSpeed * delta;
        //}
        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    playerMove.x += Input.GetAxis("Horizontal") * playerMoveSpeed * delta;
        //}
        //if (Input.GetAxis("Vertical") < 0)
        //{
        //    playerMove.y += Input.GetAxis("Vertical") * playerMoveSpeed * delta;
        //}
        //if (Input.GetAxis("Horizontal") < 0)
        //{
        //    playerMove.x += Input.GetAxis("Horizontal") * playerMoveSpeed * delta;
        //}

        //playerMove.z = 1.0f;

        //playerMoveResult(playerMove);

        frame += 1.0f;

        stickPos.x = Input.GetAxis("Horizontal2");
        stickPos.y = Input.GetAxis("Vertical2");
        stickPos.Normalize();

        if (stickPos.magnitude >= 0.1f)
        {
            if (frame >= frameRate)
            {
                GameObject insB = Instantiate(bullet, transform.position, transform.localRotation);
                insB.GetComponent<M_Bullet>()._direction = stickPos;
                insB.GetComponent<M_Bullet>()._owner = M_Bullet.Owner._1p;

                frame = 0.0f;
            }
        }

        //if (Input.GetAxis("Vertical2") == 0 && Input.GetAxis("Horizontal2") == 0)
        //{
        //    Debug.Log("弾出てない");
        //}
        //else
        //{


        //pos.x = h;
        //pos.y = v;

        //Instantiate(bullet, transform.localPosition, q);//現在の角度で発射されるバージョン
        //bullet.GetComponent<Bullet>().Fire(gameObject, true);


        //Instantiate(bullet, transform.localPosition, transform.rotation.normalized);//現在の角度で発射されるバージョン

        //下の二行を実行してください。instantiateでは発射元の位置と角度を渡してください。Fireでは発射元のGameObjectと発射元が爆弾かどうかのboolを渡してください
        //Instantiate(bullet, normalized, q);//角度指定するバージョン
        //Instantiate(bullet, transform.position, transform.rotation);//現在の角度で発射されるバージョン
        //bullet.GetComponent<Bullet>().Fire(gameObject, true);

        //        if (Input.GetAxis("Vertical2") > 0)
        //        {
        //            var v = Input.GetAxis("Vertical2");
        //            var h = Input.GetAxis("Horizontal2");

        //            pos.x = h;
        //            pos.z = v;

        //            z = 90.0f;
        //            normalized = pos.normalized;

        //            q = Quaternion.Euler(0.0f, 0.0f, normalized.z * 90.0f);


        //            Instantiate(bullet, transform.position, q);//現在の角度で発射されるバージョン
        //            bullet.GetComponent<Bullet>().Fire(gameObject, true);

        //            //下記の40.0fを変更すれば回転角を指定できます。（ランダム値、右スティックの値など）
        //            //Quaternion q = Quaternion.Euler(0.0f, 40.0f, 0.0f);
        //            //下の二行を実行してください。instantiateでは発射元の位置と角度を渡してください。Fireでは発射元のGameObjectと発射元が爆弾かどうかのboolを渡してください
        //            //Instantiate(bullet, normalized, q);//角度指定するバージョン
        //            //                                   //Instantiate(bullet, transform.position, transform.rotation);//現在の角度で発射されるバージョン
        //            //bullet.GetComponent<Bullet>().Fire(gameObject, true);

        //        }
        //        else if (Input.GetAxis("Horizontal2") > 0)
        //        {
        //            var v = Input.GetAxis("Vertical2");
        //            var h = Input.GetAxis("Horizontal2");

        //            pos.x = h;
        //            pos.z = v;

        //            z = 0.0f;

        //            normalized = pos.normalized;

        //            q = Quaternion.Euler(0.0f, 0.0f,normalized.z * 180.0f);

        //            Instantiate(bullet, transform.position, q);//現在の角度で発射されるバージョン
        //            bullet.GetComponent<Bullet>().Fire(gameObject, true);

        //            Debug.Log("右に弾");
        //        }
        //        else if (Input.GetAxis("Vertical2") < 0)
        //        {
        //            var v = Input.GetAxis("Vertical2");
        //            var h = Input.GetAxis("Horizontal2");

        //            pos.x = h;
        //            pos.z = v;

        //            z = 270.0f;
        //            normalized = pos.normalized;

        //            q = Quaternion.Euler(0.0f,0.0f,normalized.z * 360.0f);

        //            Instantiate(bullet, transform.position, q);//現在の角度で発射されるバージョン
        //            bullet.GetComponent<Bullet>().Fire(gameObject, true);

        //            Debug.Log("後ろに弾");
        //        }
        //        else if (Input.GetAxis("Horizontal2") < 0)
        //        {
        //            var v = Input.GetAxis("Vertical2");
        //            var h = Input.GetAxis("Horizontal2");

        //            pos.x = h;
        //            pos.z = v;

        //            z = 180.0f;
        //            normalized = pos.normalized;

        //            q = Quaternion.Euler(0.0f, 0.0f, normalized.z * 270.0f);

        //            normalized = pos.normalized;

        //            Instantiate(bullet, transform.position, q);//現在の角度で発射されるバージョン
        //            bullet.GetComponent<Bullet>().Fire(gameObject, true);

        //            //Instantiate(bullet, transform.localPosition, transform.localRotation.normalized);//現在の角度で発射されるバージョン
        //            //bullet.GetComponent<Bullet>().Fire(gameObject, true);

        //            Debug.Log("左に弾");
        //        }
        //    
        //}
    }
    
    //public void playerMoveResult(Vector3 move)
    //{
    //    Transform transComp = GetComponent<Transform>();

    //    transComp.position = (move);
    //}
}
