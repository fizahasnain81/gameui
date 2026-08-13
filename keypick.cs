using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class keypick : MonoBehaviour
{
    // Start is called before the first frame update
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
