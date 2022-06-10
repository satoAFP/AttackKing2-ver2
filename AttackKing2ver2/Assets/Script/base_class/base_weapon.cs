using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class base_weapon : MonoBehaviour
{
    // ���X�e�[�^�X�ݒ�p >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// ����X�e�[�^�X
    /// </summary>
    public struct WeaponData
    {
        public string name;
        public Sprite image;
        public GameObject skill;
        public int strength;
        public int magic;
        public float weight;
        public int mp_cost;
    }

    /// <summary>
    /// �ǉ��X�e�[�^�X
    /// </summary>
    public struct AddStatus
    {
        public string[] addname;        //�ǉ��X�e�[�^�X�̖��O
        public float[] addvalue;        //�ǉ��X�e�[�^�X�̐��l
    }



    // �ǉ��X�e�[�^�X�o�^�p >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// �ǉ��X�e�[�^�X�ꗗ
    /// </summary>
    public enum ADD_STATUS_TYPE
    {
        HP,
        MP,
        STRENGTH,
        DEFENSE,
        MAGIC,
        BARRIER,
        SPEED,
        MOVE,
        LUC,
        HP_REGENE,
        MP_REGENE,
    }
    //�X�e�[�^�X���O���͗p
    [System.NonSerialized]public string[] add_status_type =
    {
        "HP","MP","STRENGTH","DEFENSE","MAGIC","BARRIER",
        "SPEED","MOVE","LUC","HP_REGENE","MP_REGENE"
    };



    // ����o�^�p >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// �����
    /// </summary>
    public enum WEAPON_TYPE
    {
        PROXIMITY,
        DISTANCE,
        MAGIC,
    }

    
}
