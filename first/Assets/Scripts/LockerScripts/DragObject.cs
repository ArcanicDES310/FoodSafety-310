using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX,offsetY;
    public static bool mouseButtonReleased;


  //  public void Update()
  //  {
  //      transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8.8f, 8.8f), Mathf.Clamp(transform.position.y, -5f, 5f));
  //  }
    public void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY= Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }





  
}