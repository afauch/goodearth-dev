using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag
{
    public enum Type {Current, Past, Interest};
    public string Content { get; set; }
    public bool bShow { get; set; }
}
