using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D steak;
    public Texture2D water;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void makeSteak()
    {
        Cursor.SetCursor(steak, Vector2.zero, CursorMode.Auto);
    }
    public void makeWater()
    {
        Cursor.SetCursor(water, Vector2.zero, CursorMode.Auto);
    }
    public void makeDefault()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
