using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : base_player
{
    private JOB_TYPE JOB;
    private Rigidbody2D rb;
    private GameObject clickedGameObject = null;//�N���b�N���ꂽ�I�u�W�F�N�g
    private now_weapon ChildObj = null;

    // Start is called before the first frame update
    void Start()
    {
        job = (int)JOB_TYPE.WARRIOR;
        exe = 0;
        //weapon = null;
        hp = 50;
        mp = 20;
        mp_regene = 1;
        strength = 5;
        defense = 5;
        magic = 5;
        barrier = 5;
        attack_speed = 1.0f;
        move_speed = 3.0f;
        luc = 5;

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        ChildObj = transform.GetChild(0).gameObject.GetComponent<now_weapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        Attack();

        

        GetWeapon();
    }



    /// <summary>
    /// �ړ�����
    /// </summary>
    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, move_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-move_speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -move_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(move_speed, rb.velocity.y);
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
            weapon.gameObject.SetActive(true);

            //�U������ƃN�[���^�C��������
            //sord_time = sord_cool;
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

                    //�E�N���b�N�����A�C�e�����폜
                    Destroy(clickedGameObject);
                }
            }
        }
    }

    

    
}
