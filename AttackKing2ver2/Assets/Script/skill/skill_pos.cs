using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_pos : MonoBehaviour
{

    //���L�ϐ�
    [System.NonSerialized] public GameObject skill;
    [System.NonSerialized] public bool AttackStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackStart)
        {
            //�X�L���������Ƃ��̓N���[�����Ȃ�
            if (skill != null)
            {
                //�X�L���̐���
                GameObject clone = Instantiate(skill, transform.position, Quaternion.identity);
            }

            AttackStart = false;
        }
    }
}
