using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttonUIManager : MonoBehaviour
{
    [SerializeField, Header("�`�F�X�g")] GameObject chest;


    public void ChestOpen()
    {
        if (!chest.activeSelf)
            chest.SetActive(true);
        else
            chest.SetActive(false);
    }

}
