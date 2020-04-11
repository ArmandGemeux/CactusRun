using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    private bool selected;

    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == true)
        {

        }
    }

    private void OnMouseDrag()
    {
        Vector2 cursorPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cursorPose.x = Mathf.Clamp(cursorPose.x, minX, maxX);
        cursorPose.y = Mathf.Clamp(cursorPose.y, minY, maxY);

        transform.position = new Vector2(cursorPose.x, cursorPose.y + -2.73f);
    }
}
