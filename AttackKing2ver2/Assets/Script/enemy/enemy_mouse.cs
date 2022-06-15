using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_mouse : base_enemy
{
    [SerializeField, Header("��l�����m�̃��C�̑��x")] private float RaySpeed;
    [SerializeField, Header("���C�̋���")] private float raydistance;
    [SerializeField, Header("�h���b�v�����prefab")] private GameObject DropWeapon;


    private Rigidbody2D rb;                     //���W�b�g�{�f�B�擾
    private Vector2 RayRotato;                  //���C�̉�]�ʒu����ϐ�
    private float rotato = 0;                   //��]��
    private GameObject SearchGameObject;        //���C�ɐG�ꂽ�I�u�W�F�N�g
    private player_all_statu PlayerAllStatu;   //��l���̍��v�X�e�[�^�X�擾�p

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        PlayerAllStatu = GameObject.Find("player_all_statu").GetComponent<player_all_statu>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�����
        Move();


        //���S����
        if (hp <= 0)
        {
            //����h���b�v����
            if ((float)drop_probability * (float)(PlayerAllStatu.AllLuc() / 10) > Random.Range(0, 100)) 
            {
                GameObject clone = Instantiate(DropWeapon, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// �ړ�����
    /// </summary>
    private void Move()
    {
        //�I�u�W�F�N�g����E����Ray��L�΂�
        Ray2D ray = new Ray2D(transform.position, transform.right);
        SearchGameObject = null;
        RaycastHit2D hit;

        //Corgi�AShiba���C���[�Ƃ����Փ˂���
        int layerMask = LayerMask.GetMask(new string[] { "Player"});

        //���C�̉�]�̏�����
        rotato += RaySpeed;
        RayRotato = new Vector2(Mathf.Cos(rotato), Mathf.Sin(rotato));
        //���C���΂�
        hit = Physics2D.Raycast(ray.origin + RayRotato, RayRotato * raydistance, raydistance, layerMask);
        Debug.DrawRay(ray.origin + RayRotato, RayRotato * raydistance, Color.green);

        if (hit.collider)
        {
            SearchGameObject = hit.collider.gameObject;

            if (SearchGameObject.tag == "Player")
            {
                // �����̐����iZ�����̏����Ɛ��K���j
                Vector3 shotForward = Vector3.Scale((SearchGameObject.transform.position - transform.position), new Vector3(1, 1, 0)).normalized;

                // �e�ɑ��x��^����
                rb.velocity = shotForward * move_speed;

                if (RayRotato.x >= 0)
                    transform.localScale = new Vector3(-3, 3, 1);
                else
                    transform.localScale = new Vector3(3, 3, 1);

            }
        }
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player_skill")
        {
            //��l���ɑ΂��Ă̍U������(�X�L��)
            hp -= GetDamage(defense, PlayerAllStatu.AllStrength());
            //�X�L���폜
            Destroy(other.gameObject);
        }

        if (other.tag == "player_weapon")
        {
            //��l���ɑ΂��Ă̍U������(����)
            hp -= GetDamage(defense, PlayerAllStatu.AllStrength());
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //��l���ɑ΂��Ă̍U��
        if (collision.gameObject.tag == "Player")
        {
            player p = collision.gameObject.GetComponent<player>();

            p.DecreaseHp -= GiveDamage(PlayerAllStatu.AllDefence(), strength);

        }
    }



}
