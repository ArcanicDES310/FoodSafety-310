using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject2 : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased;

    public GameObject charShoe;
    public GameObject lockerShoe;



    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -17.5f, 17.5f), Mathf.Clamp(transform.position.y, -4.1f, 4.1f));
    }
    public void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
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


     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "shelfCollider")
         {
             lockerShoe.SetActive(true);
             charShoe.SetActive(false);
         }
     }

}