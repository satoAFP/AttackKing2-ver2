using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class now_player_damage : base_weapon
{
    [SerializeField,Header("�v���C���[")] public GameObject Player;
    [SerializeField, Header("�v���C���[����")] public GameObject NowWeapon;

    public int allstrength;

    private player p;
    private now_weapon nw;

    private void Start()
    {
        p = Player.GetComponent<player>();
        nw = NowWeapon.GetComponent<now_weapon>();
    }


    /// <summary>
    /// ��l���ŏI�U���͎擾�֐�
    /// </summary>
    /// <returns></returns>
    public int AllStrength()
    {
        //int AllStrength = 0;

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

}
