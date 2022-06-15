using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_player : MonoBehaviour
{
    /// <summary>
    /// 職業
    /// </summary>
    public enum JOB_TYPE
    {
        WARRIOR,    //戦士
        ARCHER,     //弓士
        MAGICIAN,   //魔法使い
    }


    public struct PlayerStatus
    {
        public int job;
        public int exe;
        public GameObject weapon;
        public int hp;
        public int mp;
        public int hp_regene;
        public int mp_regene;
        public int strength;
        public int defense;
        public int magic;
        public int barrier;
        public float attack_speed;
        public float move_speed;
        public int luc;
    }



    /// <summary>
    /// 合計ステータスを返してくれる
    /// </summary>
    /// <param name="pas_func">合計値を呼び出してくれる関数があるクラス</param>
    /// <param name="ps">合計値を入れる用の構造体</param>
    /// <returns>合計値の構造体</returns>
    public PlayerStatus StatusSet(player_all_statu pas_func, PlayerStatus ps)
    {
        ps.hp = pas_func.AllHp();
        ps.mp = pas_func.AllMp();
        ps.hp_regene = pas_func.AllHpRegene();
        ps.mp_regene = pas_func.AllMpRegene();
        ps.strength = pas_func.AllStrength();
        ps.defense = pas_func.AllDefence();
        ps.magic = pas_func.AllMagic();
        ps.barrier = pas_func.AllBarrier();
        ps.attack_speed = pas_func.AllSpeed();
        ps.move_speed = pas_func.AllMove();
        ps.luc = pas_func.AllLuc();

        return ps;
    }
}
