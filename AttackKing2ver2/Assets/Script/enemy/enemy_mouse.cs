using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_mouse : base_enemy
{
    [SerializeField, Header("��l�����m�̃��C�̑��x")] private float RaySpeed;
    [SerializeField, Header("���C�̋���")] private float raydistance;


    private Rigidbody2D rb;                     //���W�b�g�{�f�B�擾
    private Vector2 RayRotato;                  //���C�̉�]�ʒu����ϐ�
    private float rotato = 0;                   //��]��
    private GameObject SearchGameObject;        //���C�ɐG�ꂽ�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�����
        Move();


        //���S����
        if (hp <= 0)
            Destroy(gameObject);


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

                // transform���擾
                //Transform cloneTransform = this.gameObject.transform;

                //// ���[���h���W����ɁA��]���擾
                //Vector3 worldAngle = cloneTransform.eulerAngles;
                //worldAngle.z = GetAim(transform.position, SearchGameObject.transform.position) + 180; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
                //cloneTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�

            }
        }
    }
}