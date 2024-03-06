using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//tutorial fondo mov infitinito usando canvas raw image https://www.youtube.com/watch?v=CiUTHRVjBv0

public class BgMngr : MonoBehaviour
{
    public RawImage bg;
    public float x;
    public float y;

    void Update()
    {
        bg.uvRect = new Rect(bg.uvRect.position + new Vector2(x, y)* Time.deltaTime, bg.uvRect.size);
    }
}
