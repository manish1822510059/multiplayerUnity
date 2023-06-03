using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour
{
    // Start is called before the first frame update
 private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag =="Enemy"){
        print("Enter");
    }
    
}

}
