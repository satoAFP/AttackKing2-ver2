using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : base_player
{
    public PlayerStatus ps=new PlayerStatus()//主人公基礎ステータス
    {
        job = (int)JOB_TYPE.WARRIOR,
        exe = 0,
        weapon = null,
        hp = 50,
        mp = 20,
        hp_regene = 0,
        mp_regene = 1,
        strength = 5,
        defense = 5,
        magic = 5,
        barrier = 5,
        attack_speed = 1.0f,
        move_speed = 3.0f,
        luc = 5,
    };

    public PlayerStatus allps = new PlayerStatus()//主人公合計ステータス
    {
        hp = 0,
        mp = 0,
        hp_regene = 0,
        mp_regene = 0,
        strength = 0,
        defense = 0,
        magic = 0,
        barrier = 0,
        attack_speed = 0,
        move_speed = 0,
        luc = 0,
    };

    //オブジェクト取得
    [SerializeField, Header("HPバー")] private Slider hpbar;
    [SerializeField, Header("MPバー")] private Slider mpbar;


    //共有変数
    [System.NonSerialized] public int DecreaseHp = 0;   //実際にHP減る用
    [System.NonSerialized] public int DecreaseMp = 0;   //実際にHP減る用


    //プライベート変数
    private Rigidbody2D rb;                     //リジットボディ取得
    private GameObject clickedGameObject = null;//クリックされたオブジェクト
    private now_weapon ChildObj = null;         //主人公所持武器
    private player_all_statu all_statu = null;  //主人公のステータスの合計計算用クラス
    private int RegeneCount = 0;                //リジェネ用カウント変数

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        ChildObj = transform.GetChild(0).gameObject.GetComponent<now_weapon>();
        all_statu= transform.GetChild(1).gameObject.GetComponent<player_all_statu>();
        ps.weapon = transform.GetChild(0).gameObject;

        //主人公の合計ステータス取得
        allps = StatusSet(all_statu, allps);
        DecreaseHp = allps.hp;
        DecreaseMp = allps.mp;

        //Sliderを満タンにする。
        hpbar.value = 1;
        mpbar.value = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //移動処理
        Move();

        //攻撃処理
        Attack();

        //武器取得処理
        GetWeapon();

        //自動回復処理
        Regene();


        //UI管理------------------------------------------------
        //hpバー、mpバーの表示
        hpbar.value = (float)DecreaseHp / (float)allps.hp;
        mpbar.value = (float)DecreaseMp / (float)allps.mp;
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, allps.move_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-allps.move_speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -allps.move_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(allps.move_speed, rb.velocity.y);
        }
    }

    /// <summary>
    /// 攻撃処理
    /// </summary>
    private void Attack()
    {
        //攻撃処理
        if (Input.GetMouseButton(0))
        {
            ps.weapon.gameObject.SetActive(true);

        }
    }


    /// <summary>
    /// 武器取得処理
    /// </summary>
    private void GetWeapon()
    {
        if (Input.GetMouseButton(1))
        {
            //カーソルの位置にレイを飛ばす
            clickedGameObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            
            if (hit2d)
            {
                //そのオブジェクトを格納
                clickedGameObject = hit2d.transform.gameObject;

                if (clickedGameObject.tag == "drop")
                {
                    //ステータス格納
                    ChildObj.wd = clickedGameObject.GetComponent<drop_weapon>().Wd;
                    ChildObj.As = clickedGameObject.GetComponent<drop_weapon>().As;

                    //持っている武器の初期化
                    ChildObj.atack_flag = true;
                    ChildObj.time = 0;
                    ChildObj.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ChildObj.gameObject.SetActive(false);

                    //主人公ステータスの更新
                    allps = StatusSet(all_statu, allps);

                    //右クリックしたアイテムを削除
                    Destroy(clickedGameObject);
                }
            }
        }
    }

    

    private void Regene()
    {
        if (RegeneCount == 60) 
        {
            if (DecreaseHp < allps.hp)
                DecreaseHp += allps.hp_regene;
            else
                DecreaseHp = allps.hp;

            if (DecreaseMp < allps.mp)
                DecreaseMp += allps.mp_regene;
            else
                DecreaseMp = allps.mp;

            RegeneCount = 0;
        }

        //フレームカウント
        RegeneCount++;
    }
    
}
