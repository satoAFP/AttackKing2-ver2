using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_skill : MonoBehaviour
{
    public enum ATTACK_TYPE
    {
        STRAIGHT,   //�^��������ԍU��
        TAP_POINT,  //�N���b�N�����ꏊ�ɍU��
        AROUND,     //���g�̎�����U��
        BUFF,       //�o�t
    }

    public string name;
    public int strength;
    public int magic;
    public float move_speed;
}
