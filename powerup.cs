using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class powerup : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    // Start is called before the first frame update
     

    // Update is called once per frame
    void Update()
    {
        
    }
}
