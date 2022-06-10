using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_srash : MonoBehaviour
{
    [Header("������܂ł̎���")]
    public int delete_time;
    [Header("�ړ����x")]
    public float skill_speed;
    [Header("������")]
    public float slow_power;

    Vector3 shotForward;

    // Start is called before the first frame update
    void Start()
    {

        // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �����̐����iZ�����̏����Ɛ��K���j
        shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

        // �e�ɑ��x��^����
        this.gameObject.GetComponent<Rigidbody2D>().velocity = shotForward * skill_speed;

        // transform���擾
        Transform cloneTransform = this.gameObject.transform;

        // ���[���h���W����ɁA��]���擾
        Vector3 worldAngle = cloneTransform.eulerAngles;
        worldAngle.z = GetAim(transform.position, mouseWorldPos) - 45; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
        cloneTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = shotForward * skill_speed;

        if (skill_speed >= slow_power)
        {
            skill_speed -= slow_power;
        }

        delete_time--;

        if (delete_time == 0)
        {
            Destroy(this.gameObject);
        }
    }

    //��_�Ԃ̊p�x�����߂�֐�
    //����1�@���_�ƂȂ�I�u�W�F�N�g���W
    //����2�@�p�x�����߂����I�u�W�F�N�g���W
    public float GetAim(Vector3 p1, Vector3 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
