using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskScript : MonoBehaviour
{
    private GameObject myPop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMyPop(GameObject newPop)
    {
        myPop = newPop;
    }

    public void DeleteButton()
    {
        Destroy(myPop);
        gameObject.SetActive(false);
    }
}