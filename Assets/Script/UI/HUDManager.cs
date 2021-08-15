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
        // 更新得救人数
        saveCountText.text = count.ToString();
    }

    public void UpdatePoint(int point)
    {
        // 更新分数
        pointText.text = point.ToString();
    }

}
