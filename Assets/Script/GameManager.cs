using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float restartDelay;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
