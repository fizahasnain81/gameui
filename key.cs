using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
 
public class key : MonoBehaviour
{
    public Image[] keys;
    int count = 3;
    //public Image door;
    public int keysremaining;
    //Animator animator2;
    // Start is called before the first frame update
    public int losekey()
    {
        /*if (keysremaining > 0)
        {
            keysremaining--;
            keys[keysremaining].enabled = false;
            return false;
        }*/
        count = count - 1;
        keysremaining--;
        keys[keysremaining].enabled = false;
        if (keysremaining == 0)
        {
            Debug.Log("door opened");
            //return true;
            //animator2.SetTrigger("door_open");
             
        }
        /* else
          {
              count = count - 1;
              keysremaining--;
              keys[keysremaining].enabled = false;
              return 
              //return false;
          }*/
        return count;
    }
     

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            losekey();
        }
    }*/
}
