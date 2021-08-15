using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialog
{
    public string name;
    //public Vector2 position;

    [TextArea(3, 10)]
    public string[] sentences;

}
