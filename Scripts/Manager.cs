using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float timeLimit = 15;

    public GameObject mess;
    private void Start()
    {
      

        StartCoroutine(Change());
    }

    public void ShowMessage()
    {
        mess.SetActive(true);
    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(timeLimit);
        foreach (var g in FindObjectsOfType<Dirt>())
        {
            yield return new WaitForSeconds(1);

            if(g!=null)
                g.Change();
        }
    }
    
}
