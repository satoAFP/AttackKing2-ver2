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
    /// ��_�Ԃ̊p�x�����߂�֐�
    /// </summary>
    /// <param name="p1">���_�ƂȂ�I�u�W�F�N�g���W</param>
    /// <param name="p2">�p�x�����߂����I�u�W�F�N�g���W</param>
    /// <returns>z��_�Ԃ̊p�x</returns>
    public float GetAim(Vector3 p1, Vector3 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
