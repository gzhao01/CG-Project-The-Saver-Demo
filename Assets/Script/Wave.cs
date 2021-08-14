using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wave : MonoBehaviour
{
    public float waveMoveDisStep;
    public float waveMoveTimeStep;
    public float waveMoveCostTime;
    private float lastMoveTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Time.time > lastMoveTime + waveMoveTimeStep)
        {
            transform.DOMoveY(transform.position.y+waveMoveDisStep,waveMoveCostTime);
            lastMoveTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "People")
        {
            GameManager.Instance.EndGame();
        }
    }
}
