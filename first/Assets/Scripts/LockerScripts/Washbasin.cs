using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washbasin : MonoBehaviour
{
    public GameObject handWash;


    //  IEnumerator coroutine;

   
    private void OnMouseDown()
    {
        handWash.SetActive(true);
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
