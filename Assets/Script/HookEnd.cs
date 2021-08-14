using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookEnd : MonoBehaviour
{

    [SerializeField]private Transform hookDirection;
    [SerializeField]private Transform hookStart;

    public bool isFiringHook;
    public bool afterHook;

    public bool touchPeople { get; private set; }
    public bool touchPoint { get; private set; }
    public bool touchPlayer;
    public bool touchNull;

    private GameObject touchObject;
    public Vector2 hookEnd2PlayerDir { get; private set; }

    private SpriteRenderer sr;
    private LineRenderer lr;
    public Rigidbody2D rb { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0,hookStart.transform.position);
        lr.SetPosition(1,transform.position);
        lr.material.SetTexture("_MainTex",sr.sprite.texture);
    }

    private void FixedUpdate()
    {
        hookEnd2PlayerDir = (transform.position - hookStart.position).normalized;
        if (touchPeople)
        {
            touchObject.transform.position = transform.position;
        }
        if (touchPoint)
        {
            transform.position = touchObject.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isFiringHook && collision.tag == "People")
        {
            isFiringHook = false;
            touchPeople = true;
            touchObject = collision.gameObject;
        }
        else if(isFiringHook && collision.tag == "Point")
        {
            isFiringHook = false;
            touchPoint = true;
            touchObject = collision.gameObject;
        }
        else if(afterHook && collision.tag == "Player" && touchPeople)
        {
            afterHook = false;
            touchPeople = false;
            Destroy(touchObject);
            touchObject = null;
            touchPlayer = true;
        }
        else if(afterHook && collision.tag == "Player" && touchPoint)
        {
            afterHook = false;
            touchPoint = false;
            touchObject = null;
            touchPlayer = true;
        }
        else if(afterHook && collision.tag == "Player" && touchNull)
        {
            afterHook = false;
            touchNull = false;
            touchObject = null;
            touchPlayer = true;
        }
    }

}
