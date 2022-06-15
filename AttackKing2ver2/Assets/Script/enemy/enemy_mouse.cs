using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_mouse : base_enemy
{
    [SerializeField, Header("主人公感知のレイの速度")] private float RaySpeed;
    [SerializeField, Header("レイの距離")] private float raydistance;
    [SerializeField, Header("ドロップ武器のprefab")] private GameObject DropWeapon;


    private Rigidbody2D rb;                     //リジットボディ取得
    private Vector2 RayRotato;                  //レイの回転位置決定変数
    private float rotato = 0;                   //回転量
    private GameObject SearchGameObject;        //レイに触れたオブジェクト
    private player_all_statu PlayerAllStatu;   //主人公の合計ステータス取得用

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        PlayerAllStatu = GameObject.Find("player_all_statu").GetComponent<player_all_statu>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        Move();


        //死亡処理
        if (hp <= 0)
        {
            //武器ドロップ処理
            if ((float)drop_probability * (float)(PlayerAllStatu.AllLuc() / 10) > Random.Range(0, 100)) 
            {
                GameObject clone = Instantiate(DropWeapon, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
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

            }
        }
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player_skill")
        {
            //主人公に対しての攻撃処理(スキル)
            hp -= GetDamage(defense, PlayerAllStatu.AllStrength());
            //スキル削除
            Destroy(other.gameObject);
        }

        if (other.tag == "player_weapon")
        {
            //主人公に対しての攻撃処理(武器)
            hp -= GetDamage(defense, PlayerAllStatu.AllStrength());
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //主人公に対しての攻撃
        if (collision.gameObject.tag == "Player")
        {
            player p = collision.gameObject.GetComponent<player>();

            p.DecreaseHp -= GiveDamage(PlayerAllStatu.AllDefence(), strength);

        }
    }



}
