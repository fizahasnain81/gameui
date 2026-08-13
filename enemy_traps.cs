using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class enemy_traps : MonoBehaviour
{

    // Start is called before the first frame update
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="e")
        {
            Debug.Log("Trap triggered");
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
