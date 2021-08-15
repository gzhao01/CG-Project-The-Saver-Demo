using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    private Queue<string> sentences;

    public TMP_Text dialogText;
    public GameObject dialogBox;

    public Animator animator;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        //Debug.Log("Start conversation");
        animator.SetBool("isOpen", true);
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();

        // dialogText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void OnShowNextSentence()
    {
        DisplayNextSentence();
    }

    public void EndDialog()
    {
        Debug.Log("Dialog ends");
        animator.SetBool("isOpen", false);

        // 等待2s后自动进入游戏场景
        StartCoroutine(Waiter());

        SceneManager.LoadScene("SampleScene");
    }
    IEnumerator Waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);

    }
}
