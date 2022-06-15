using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : base_player
{
    public PlayerStatus ps=new PlayerStatus()//��l����b�X�e�[�^�X
    {
        job = (int)JOB_TYPE.WARRIOR,
        exe = 0,
        weapon = null,
        hp = 50,
        mp = 20,
        hp_regene = 0,
        mp_regene = 1,
        strength = 5,
        defense = 5,
        magic = 5,
        barrier = 5,
        attack_speed = 1.0f,
        move_speed = 3.0f,
        luc = 5,
    };

    public PlayerStatus allps = new PlayerStatus()//��l�����v�X�e�[�^�X
    {
        hp = 0,
        mp = 0,
        hp_regene = 0,
        mp_regene = 0,
        strength = 0,
        defense = 0,
        magic = 0,
        barrier = 0,
        attack_speed = 0,
        move_speed = 0,
        luc = 0,
    };

    //�I�u�W�F�N�g�擾
    [SerializeField, Header("HP�o�[")] private Slider hpbar;
    [SerializeField, Header("MP�o�[")] private Slider mpbar;


    //���L�ϐ�
    [System.NonSerialized] public int DecreaseHp = 0;   //���ۂ�HP����p
    [System.NonSerialized] public int DecreaseMp = 0;   //���ۂ�HP����p


    //�v���C�x�[�g�ϐ�
    private Rigidbody2D rb;                     //���W�b�g�{�f�B�擾
    private GameObject clickedGameObject = null;//�N���b�N���ꂽ�I�u�W�F�N�g
    private now_weapon ChildObj = null;         //��l����������
    private player_all_statu all_statu = null;  //��l���̃X�e�[�^�X�̍��v�v�Z�p�N���X
    private int RegeneCount = 0;                //���W�F�l�p�J�E���g�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        ChildObj = transform.GetChild(0).gameObject.GetComponent<now_weapon>();
        all_statu= transform.GetChild(1).gameObject.GetComponent<player_all_statu>();
        ps.weapon = transform.GetChild(0).gameObject;

        //��l���̍��v�X�e�[�^�X�擾
        allps = StatusSet(all_statu, allps);
        DecreaseHp = allps.hp;
        DecreaseMp = allps.mp;

        //Slider�𖞃^���ɂ���B
        hpbar.value = 1;
        mpbar.value = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�ړ�����
        Move();

        //�U������
        Attack();

        //����擾����
        GetWeapon();

        //�����񕜏���
        Regene();


        //UI�Ǘ�------------------------------------------------
        //hp�o�[�Amp�o�[�̕\��
        hpbar.value = (float)DecreaseHp / (float)allps.hp;
        mpbar.value = (float)DecreaseMp / (float)allps.mp;
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, allps.move_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-allps.move_speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -allps.move_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(allps.move_speed, rb.velocity.y);
        }
    }

    /// <summary>
    /// �U������
    /// </summary>
    private void Attack()
    {
        //�U������
        if (Input.GetMouseButton(0))
        {
            ps.weapon.gameObject.SetActive(true);

        }
    }


    /// <summary>
    /// ����擾����
    /// </summary>
    private void GetWeapon()
    {
        if (Input.GetMouseButton(1))
        {
            //�J�[�\���̈ʒu�Ƀ��C���΂�
            clickedGameObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            
            if (hit2d)
            {
                //���̃I�u�W�F�N�g���i�[
                clickedGameObject = hit2d.transform.gameObject;

                if (clickedGameObject.tag == "drop")
                {
                    //�X�e�[�^�X�i�[
                    ChildObj.wd = clickedGameObject.GetComponent<drop_weapon>().Wd;
                    ChildObj.As = clickedGameObject.GetComponent<drop_weapon>().As;

                    //�����Ă��镐��̏�����
                    ChildObj.atack_flag = true;
                    ChildObj.time = 0;
                    ChildObj.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ChildObj.gameObject.SetActive(false);

                    //��l���X�e�[�^�X�̍X�V
                    allps = StatusSet(all_statu, allps);

                    //�E�N���b�N�����A�C�e�����폜
                    Destroy(clickedGameObject);
                }
            }
        }
    }

    

    private void Regene()
    {
        if (RegeneCount == 60) 
        {
            if (DecreaseHp < allps.hp)
                DecreaseHp += allps.hp_regene;
            else
                DecreaseHp = allps.hp;

            if (DecreaseMp < allps.mp)
                DecreaseMp += allps.mp_regene;
            else
                DecreaseMp = allps.mp;

            RegeneCount = 0;
        }

        //�t���[���J�E���g
        RegeneCount++;
    }
    
}
