using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class now_weapon : base_weapon
{
    public WeaponData wd = new WeaponData()             //����f�[�^�쐬
    {
        name = "", image = null, skill = null,
        strength = 0, magic = 0, weight = 0, mp_cost = 0
    };


    private GameObject clone;               //�N���[������I�u�W�F�N�g
    private int time = 0;                   //�܂�Ԃ��܂ł̎���
    private bool atack_flag = true;         //���ꂪ�^�̂Ƃ��U���ł���
    private Vector3 mem_shotForward;        //�U����������x�N�g��
    private float sord_speed = 0;           //�U�����x
    private Rigidbody2D rb;                 //���W�b�g�{�f�B�擾�p
    private player player;                  //�v���C���[�擾�p
    private skill_pos sp;                   //�X�L���|�X�̎擾�p

    // Start is called before the first frame update
    void Start()
    {
        wd.weight = 50;
        Debug.Log(System.Enum.GetValues(typeof(ADD_STATUS_TYPE)).Length);

        //������
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = transform.parent.gameObject.GetComponent<player>();
        sp = transform.parent.gameObject.GetComponent<skill_pos>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(wd.name);
        Debug.Log(wd.image);
        Debug.Log(wd.skill);
        Debug.Log(wd.strength);
        Debug.Log(wd.magic);
        Debug.Log(wd.weight);
        //�U������
        if (atack_flag == true)
        {
            //����̑��x����
            sord_speed = 100 / (wd.weight * 2);

            // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �����̐����iZ�����̏����Ɛ��K���j
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;
            mem_shotForward = shotForward;

            // �e�ɑ��x��^����
            rb.velocity = shotForward * sord_speed;

            // transform���擾
            Transform cloneTransform = this.gameObject.transform;

            // ���[���h���W����ɁA��]���擾
            Vector3 worldAngle = cloneTransform.eulerAngles;
            worldAngle.z = GetAim(transform.position, mouseWorldPos) - 45; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
            cloneTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�



            //�g�p����X�L������
            sp.skill = wd.skill;
            //�X�L���̍U���J�n����
            sp.AttackStart = true;
            //�U�������I��
            atack_flag = false;
        }

        //�o�����Ԃ̐܂�Ԃ��܂ł���Ɩ߂��Ă���
        if (time == (wd.weight))
        {
            rb.velocity = -mem_shotForward * sord_speed;
        }
        
        //����
        time++;
        if (time == wd.weight * 2) 
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            atack_flag = true;
            time = 0;
        }

        //��l���Ƃ̂�����C��
        MoveCorrection();
    }

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

    /// <summary>
    /// ���킪��l���ɂ��Ă���悤�ɏC���p
    /// </summary>
    private void MoveCorrection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += new Vector3(0, 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += new Vector3(-0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += new Vector3(0, -0.01f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(0.01f, 0, 0);
        }
    }
}
