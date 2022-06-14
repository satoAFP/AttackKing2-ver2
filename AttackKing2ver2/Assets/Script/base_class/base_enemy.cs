using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_enemy : MonoBehaviour
{
    public string name;
    public GameObject skill;
    public int hp;
    public int mp;
    public int mp_regene;
    public int strength;
    public int defense;
    public int magic;
    public int barrier;
    public float attack_speed;
    public float move_speed;
    public int drop_probability;


    /// <summary>
    /// 二点間の角度を求める関数
    /// </summary>
    /// <param name="p1">原点となるオブジェクト座標</param>
    /// <param name="p2">角度を求めたいオブジェクト座標</param>
    /// <returns>z二点間の角度</returns>
    public float GetAim(Vector3 p1, Vector3 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }


    /// <summary>
    /// 主人公から与えられるダメージ計算関数
    /// </summary>
    /// <param name="def">エネミーの防御力</param>
    /// <param name="getdamage">主人公の攻撃力</param>
    /// <returns>最終的に受けるダメージ</returns>
    public int GetDamage(int def,int getdamage)
    {
        if (def >= getdamage)
            return 1;
        else
            return getdamage - def;
    }


    /// <summary>
    /// 主人公に与えるダメージ計算関数
    /// </summary>
    /// <param name="getdef">主人公の防御力</param>
    /// <param name="str">エネミーの攻撃力</param>
    /// <returns>最終的に与えるメージ</returns>
    public int GiveDamage(int getdef, int str)
    {
        if (getdef >= str)
            return 1;
        else
            return str - getdef;
    }

}
