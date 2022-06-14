using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_all_statu : base_weapon
{
    [SerializeField,Header("プレイヤー")] public GameObject Player;
    [SerializeField, Header("プレイヤー武器")] public GameObject NowWeapon;


    private player p;       //プレイヤーのスクリプト格納
    private now_weapon nw;  //プレイヤーの所持武器のスクリプト格納

    private void Start()
    {
        p = Player.GetComponent<player>();
        nw = NowWeapon.GetComponent<now_weapon>();
    }


    /// <summary>
    /// 主人公最終HP取得関数
    /// </summary>
    /// <returns>最終HP</returns>
    public int AllHp()
    {
        int allhp = 0;

        allhp = p.hp;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが攻撃アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.HP)
            {
                allhp += (int)nw.As.addvalue[i];
            }
        }
        return allhp;
    }


    /// <summary>
    /// 主人公最終MP取得関数
    /// </summary>
    /// <returns>最終MP</returns>
    public int AllMp()
    {
        int allmp = 0;

        allmp = p.mp;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが攻撃アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.MP)
            {
                allmp += (int)nw.As.addvalue[i];
            }
        }
        return allmp;
    }


    /// <summary>
    /// 主人公最終攻撃力取得関数
    /// </summary>
    /// <returns>最終攻撃力</returns>
    public int AllStrength()
    {
        int allstrength = 0;

        allstrength = p.strength + nw.wd.strength;
        
        for (int i = 0; i < 5; i++) 
        {
            //追加ステータスが攻撃アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.STRENGTH)
            {
                allstrength += (int)nw.As.addvalue[i];
            }
        }
        return allstrength;
    }


    /// <summary>
    /// 主人公最終防御力取得関数
    /// </summary>
    /// <returns>最終防御力</returns>
    public int AllDefence()
    {
        int alldefence = 0;

        alldefence = p.defense;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが防御アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.DEFENSE)
            {
                alldefence += (int)nw.As.addvalue[i];
            }
        }
        return alldefence;
    }


    /// <summary>
    /// 主人公最終魔法攻撃力取得関数
    /// </summary>
    /// <returns>最終魔法攻撃力</returns>
    public int AllMagic()
    {
        int allmagic = 0;

        allmagic = p.magic + nw.wd.magic;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが防御アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.MAGIC)
            {
                allmagic += (int)nw.As.addvalue[i];
            }
        }
        return allmagic;
    }


    /// <summary>
    /// 主人公最終魔法防御力取得関数
    /// </summary>
    /// <returns>最終魔法防御力</returns>
    public int AllBarrier()
    {
        int allbarrier = 0;

        allbarrier = p.barrier;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが防御アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.BARRIER)
            {
                allbarrier += (int)nw.As.addvalue[i];
            }
        }
        return allbarrier;
    }


    /// <summary>
    /// 主人公最終攻撃速度取得関数
    /// </summary>
    /// <returns>最終攻撃速度</returns>
    public float AllSpeed()
    {
        float alldpeed = 0;

        alldpeed = p.attack_speed;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが防御アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.SPEED)
            {
                alldpeed += nw.As.addvalue[i] / 10;
            }
        }
        return alldpeed;
    }


    /// <summary>
    /// 主人公最終移動速度取得関数
    /// </summary>
    /// <returns>最終移動速度</returns>
    public float AllMove()
    {
        float allmove = 0;

        allmove = p.move_speed;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが防御アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.MOVE)
            {
                allmove += nw.As.addvalue[i];
            }
        }
        return allmove;
    }


    /// <summary>
    /// 主人公最終運取得関数
    /// </summary>
    /// <returns>最終運</returns>
    public float AllLuc()
    {
        float allluc = 0;

        allluc = p.luc;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが防御アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.LUC)
            {
                allluc += nw.As.addvalue[i];
            }
        }
        return allluc;
    }


    /// <summary>
    /// 主人公最終HP自動回復量取得関数
    /// </summary>
    /// <returns>最終HP自動回復量</returns>
    public float AllHpRegene()
    {
        float allhpregene = 0;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが防御アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.HP_REGENE)
            {
                allhpregene += nw.As.addvalue[i];
            }
        }
        return allhpregene;
    }


    /// <summary>
    /// 主人公最終MP自動回復量取得関数
    /// </summary>
    /// <returns>最終MP自動回復量</returns>
    public float AllMpRegene()
    {
        float allmpregene = 0;

        allmpregene = p.mp_regene;

        for (int i = 0; i < 5; i++)
        {
            //追加ステータスが防御アップの時
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.MP_REGENE)
            {
                allmpregene += nw.As.addvalue[i];
            }
        }
        return allmpregene;
    }
}
