using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int saveCount;
    public int pointPerMan = 10;
    public int currentPoint = 0;
    public GameObject debuffObj;

    public int nextLevelNeedNum=0;


    public float restartDelay;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        saveCount = 0;
        currentPoint = 0;
        ShowDebuff(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(saveCount == nextLevelNeedNum)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FreezeTime(float duration)
    {
        StartCoroutine(FreezeTimeCoroutine(duration));
    }

    private IEnumerator FreezeTimeCoroutine(float duration)
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1.0f;
    }

    public void EndGame()
    {
        //other operation
        //GuiManager.Instance.EndGameImg();
        //FreezeTime(2.0f);
        //
        DOVirtual.DelayedCall(2.0f,()=>RestartGame());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //load current scene
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene(3);
    }


    // 得分
    public void AddPoints()
    {
        currentPoint += pointPerMan;
        HUDManager.m_Instance.UpdatePoint(currentPoint);
    }
    
    // 救人
    public void AddSaveCount()
    {
        saveCount++;
        HUDManager.m_Instance.UpdateSaveCount(saveCount);
    }

    public void AddSaveCount(int saveCount)
    {
        this.saveCount += saveCount;
        HUDManager.m_Instance.UpdateSaveCount(this.saveCount);
    }

    public void ShowDebuff(bool isShow)
    {
        debuffObj.SetActive(isShow);
    }

    // 场景切换
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
