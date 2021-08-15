using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerLabel;
    public Slider TimeSlider;

    private float time;
    private float levelTotalTime = 60f;   // Total seconds

    private void Start()
    {
        TimeSlider.value = levelTotalTime;
        TimeSlider.maxValue = levelTotalTime;
    }
    void Update()
    {
        time += Time.deltaTime;

        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.
        var fraction = (time * 100) % 100;

        var minutesLeft = (levelTotalTime - time) / 60-1 ;
        var secondsLeft = (levelTotalTime - time) % 60;

        //update the label value
        timerLabel.text = string.Format("{0:00} : {1:00}", minutesLeft, secondsLeft);
        TimeSlider.value = levelTotalTime - time;
    }
}