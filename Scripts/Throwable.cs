using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{ 

    // Update is called once per frame
    public void Throw()
    {
        var p = Resources.Load<GameObject>("Eff");
       Destroy( Instantiate(p, transform.position, Quaternion.identity),3);


        Destroy(gameObject);
    }
}
