using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUIManager : MonoBehaviour
{
    [SerializeField] Vector3 mouse;

    [SerializeField,Header("ステータス表示用パネル")] GameObject StatusPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;

        if (mouse.x > 0 && mouse.x < 254 && mouse.y < 576 && mouse.y > 540)
            StatusPanel.SetActive(true);
        else
            StatusPanel.SetActive(false);
    }
}
