using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washbasin : MonoBehaviour
{
    public GameObject handWash;
    public BoxCollider2D boxCollider; 
    

    //  IEnumerator coroutine;

   
    private void OnMouseDown()
    {
        handWash.SetActive(true);
        boxCollider.enabled = false;
         Destroy(handWash, 5f);
        
        TriggerCondition.taskCount--;
      //  StartCoroutine(delayTime());
    }

    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(5f);
        handWash.SetActive(false);
    }


}
