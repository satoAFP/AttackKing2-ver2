using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class now_player_damage : base_weapon
{
    [SerializeField,Header("プレイヤー")] public GameObject Player;
    [SerializeField, Header("プレイヤー武器")] public GameObject NowWeapon;

    public int allstrength;

    private player p;
    private now_weapon nw;

    private void Start()
    {
        p = Player.GetComponent<player>();
        nw = NowWeapon.GetComponent<now_weapon>();
    }


    /// <summary>
    /// 主人公最終攻撃力取得関数
    /// </summary>
    /// <returns></returns>
    public int AllStrength()
    {
        //int AllStrength = 0;

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

}
