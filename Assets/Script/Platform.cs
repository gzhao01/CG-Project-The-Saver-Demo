using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public float draftOffset;
    public float draftMag = 1;
    public float frequency;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(draftMag * 0.5f*Mathf.Cos(Time.time + draftOffset), draftMag * 0.25f*Mathf.Cos(Time.time/2 + draftOffset));
    }
}
