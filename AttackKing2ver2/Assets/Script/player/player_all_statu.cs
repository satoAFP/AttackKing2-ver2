using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_all_statu : base_weapon
{
    [SerializeField,Header("�v���C���[")] public GameObject Player;
    [SerializeField, Header("�v���C���[����")] public GameObject NowWeapon;


    private player p;       //�v���C���[�̃X�N���v�g�i�[
    private now_weapon nw;  //�v���C���[�̏�������̃X�N���v�g�i�[

    private void Start()
    {
        p = Player.GetComponent<player>();
        nw = NowWeapon.GetComponent<now_weapon>();
    }


    /// <summary>
    /// ��l���ŏIHP�擾�֐�
    /// </summary>
    /// <returns>�ŏIHP</returns>
    public int AllHp()
    {
        int allhp = 0;

        allhp = p.hp;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���U���A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.HP)
            {
                allhp += (int)nw.As.addvalue[i];
            }
        }
        return allhp;
    }


    /// <summary>
    /// ��l���ŏIMP�擾�֐�
    /// </summary>
    /// <returns>�ŏIMP</returns>
    public int AllMp()
    {
        int allmp = 0;

        allmp = p.mp;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���U���A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.MP)
            {
                allmp += (int)nw.As.addvalue[i];
            }
        }
        return allmp;
    }


    /// <summary>
    /// ��l���ŏI�U���͎擾�֐�
    /// </summary>
    /// <returns>�ŏI�U����</returns>
    public int AllStrength()
    {
        int allstrength = 0;

        allstrength = p.strength + nw.wd.strength;
        
        for (int i = 0; i < 5; i++) 
        {
            //�ǉ��X�e�[�^�X���U���A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.STRENGTH)
            {
                allstrength += (int)nw.As.addvalue[i];
            }
        }
        return allstrength;
    }


    /// <summary>
    /// ��l���ŏI�h��͎擾�֐�
    /// </summary>
    /// <returns>�ŏI�h���</returns>
    public int AllDefence()
    {
        int alldefence = 0;

        alldefence = p.defense;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���h��A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.DEFENSE)
            {
                alldefence += (int)nw.As.addvalue[i];
            }
        }
        return alldefence;
    }


    /// <summary>
    /// ��l���ŏI���@�U���͎擾�֐�
    /// </summary>
    /// <returns>�ŏI���@�U����</returns>
    public int AllMagic()
    {
        int allmagic = 0;

        allmagic = p.magic + nw.wd.magic;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���h��A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.MAGIC)
            {
                allmagic += (int)nw.As.addvalue[i];
            }
        }
        return allmagic;
    }


    /// <summary>
    /// ��l���ŏI���@�h��͎擾�֐�
    /// </summary>
    /// <returns>�ŏI���@�h���</returns>
    public int AllBarrier()
    {
        int allbarrier = 0;

        allbarrier = p.barrier;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���h��A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.BARRIER)
            {
                allbarrier += (int)nw.As.addvalue[i];
            }
        }
        return allbarrier;
    }


    /// <summary>
    /// ��l���ŏI�U�����x�擾�֐�
    /// </summary>
    /// <returns>�ŏI�U�����x</returns>
    public float AllSpeed()
    {
        float alldpeed = 0;

        alldpeed = p.attack_speed;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���h��A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.SPEED)
            {
                alldpeed += nw.As.addvalue[i] / 10;
            }
        }
        return alldpeed;
    }


    /// <summary>
    /// ��l���ŏI�ړ����x�擾�֐�
    /// </summary>
    /// <returns>�ŏI�ړ����x</returns>
    public float AllMove()
    {
        float allmove = 0;

        allmove = p.move_speed;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���h��A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.MOVE)
            {
                allmove += nw.As.addvalue[i];
            }
        }
        return allmove;
    }


    /// <summary>
    /// ��l���ŏI�^�擾�֐�
    /// </summary>
    /// <returns>�ŏI�^</returns>
    public float AllLuc()
    {
        float allluc = 0;

        allluc = p.luc;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���h��A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.LUC)
            {
                allluc += nw.As.addvalue[i];
            }
        }
        return allluc;
    }


    /// <summary>
    /// ��l���ŏIHP�����񕜗ʎ擾�֐�
    /// </summary>
    /// <returns>�ŏIHP�����񕜗�</returns>
    public float AllHpRegene()
    {
        float allhpregene = 0;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���h��A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.HP_REGENE)
            {
                allhpregene += nw.As.addvalue[i];
            }
        }
        return allhpregene;
    }


    /// <summary>
    /// ��l���ŏIMP�����񕜗ʎ擾�֐�
    /// </summary>
    /// <returns>�ŏIMP�����񕜗�</returns>
    public float AllMpRegene()
    {
        float allmpregene = 0;

        allmpregene = p.mp_regene;

        for (int i = 0; i < 5; i++)
        {
            //�ǉ��X�e�[�^�X���h��A�b�v�̎�
            if (nw.As.statunumber[i] == (int)ADD_STATUS_TYPE.MP_REGENE)
            {
                allmpregene += nw.As.addvalue[i];
            }
        }
        return allmpregene;
    }
}
