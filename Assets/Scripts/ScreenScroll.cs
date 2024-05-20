using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScroll : MonoBehaviour
{
    RawImage background;
    public float valueX, ValueY;

    void Start()
    {
        background = GetComponent<RawImage>();
    }

    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(valueX, ValueY) * Time.deltaTime, background.uvRect.size);

    }
}
