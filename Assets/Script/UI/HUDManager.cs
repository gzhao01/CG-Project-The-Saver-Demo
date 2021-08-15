using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    static public HUDManager m_Instance;

    public TMP_Text saveCountText;
    public TMP_Text pointText;

    protected GameManager gameManager;

    private void Awake()
    {
        m_Instance = this;
    }

    private void Start()
    {

    }


    public void UpdateSaveCount(int count)
    {
        // ���µþ�����
        saveCountText.text = count.ToString();
    }

    public void UpdatePoint(int point)
    {
        // ���·���
        pointText.text = point.ToString();
    }

}
