using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_mouse : base_enemy
{
    [SerializeField, Header("主人公感知のレイの速度")] private float RaySpeed;
    [SerializeField, Header("レイの距離")] private float raydistance;


    private Rigidbody2D rb;                     //リジットボディ取得
    private Vector2 RayRotato;                  //レイの回転位置決定変数
    private float rotato = 0;                   //回転量
    private GameObject SearchGameObject;        //レイに触れたオブジェクト
    private now_player_damage PlayerAllStatu;   //主人公の合計ステータス取得用

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        PlayerAllStatu = GameObject.Find("now_player_damage").GetComponent<now_player_damage>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        Move();


        //死亡処理
        if (hp <= 0)
            Destroy(gameObject);
    }


    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        //オブジェクトから右側にRayを伸ばす
        Ray2D ray = new Ray2D(transform.position, transform.right);
        SearchGameObject = null;
        RaycastHit2D hit;

        //Corgi、Shibaレイヤーとだけ衝突する
        int layerMask = LayerMask.GetMask(new string[] { "Player"});

        //レイの回転の初期化
        rotato += RaySpeed;
        RayRotato = new Vector2(Mathf.Cos(rotato), Mathf.Sin(rotato));
        //レイを飛ばす
        hit = Physics2D.Raycast(ray.origin + RayRotato, RayRotato * raydistance, raydistance, layerMask);
        Debug.DrawRay(ray.origin + RayRotato, RayRotato * raydistance, Color.green);

        if (hit.collider)
        {
            SearchGameObject = hit.collider.gameObject;

            if (SearchGameObject.tag == "Player")
            {
                // 向きの生成（Z成分の除去と正規化）
                Vector3 shotForward = Vector3.Scale((SearchGameObject.transform.position - transform.position), new Vector3(1, 1, 0)).normalized;

                // 弾に速度を与える
                rb.velocity = shotForward * move_speed;

                if (RayRotato.x >= 0)
                    transform.localScale = new Vector3(-3, 3, 1);
                else
                    transform.localScale = new Vector3(3, 3, 1);

                // transformを取得
                //Transform cloneTransform = this.gameObject.transform;

                //// ワールド座標を基準に、回転を取得
                //Vector3 worldAngle = cloneTransform.eulerAngles;
                //worldAngle.z = GetAim(transform.position, SearchGameObject.transform.position) + 180; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
                //cloneTransform.eulerAngles = worldAngle; // 回転角度を設定

            }
        }
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player_skill")
        {
            if (defense >= PlayerAllStatu.AllStrength())
                hp -= 1;
            else
                hp -= PlayerAllStatu.AllStrength() - defense;

            Destroy(other.gameObject);
        }

        if (other.tag == "player_weapon")
        {
            if (defense >= PlayerAllStatu.AllStrength())
                hp -= 1;
            else
                hp -= PlayerAllStatu.AllStrength() - defense;
        }
    }
}
