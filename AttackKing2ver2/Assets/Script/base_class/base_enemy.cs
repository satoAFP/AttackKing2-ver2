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
    public int luc;


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
}
