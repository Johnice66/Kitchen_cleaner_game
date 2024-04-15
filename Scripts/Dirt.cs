using SamDriver.Decal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    public GameObject bacterium;
     
    private float currLife = 1;

    private void Start()
    {
       
    }
    
    public void Change() 
    { 
        Vector3 pos = transform.position - transform.forward * 1f;
        Instantiate(bacterium, pos, Quaternion.identity);

        Destroy(gameObject);
    }

    public void Kill()
    {
        currLife -= 0.2f;

        GetComponentInChildren<DecalMesh>().Opacity= currLife;

        if(currLife <= 0)
        {
            Destroy(gameObject);
        }
    }


}
