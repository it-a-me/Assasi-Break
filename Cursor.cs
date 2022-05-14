using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private void Start()
    {
        UnityEngine.Cursor.visible = false;
    }

    public void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

    }
    private void OnDestroy()
    {
        UnityEngine.Cursor.visible = true;
    }
}