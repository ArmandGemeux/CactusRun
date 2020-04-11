﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Error : MonoBehaviour
{
    public int timeBeforePopUpgrade = 10;

    public GameObject popInstance;
    public Transform popupParent;

    public Pops[] erreurSysteme;
    public Pops[] pub;
    public Pops[] fatalErreurSysteme;

    public static GameManager_Error Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Pops SendPop()
    {
        Debug.Log("send");
        if(Time.deltaTime < timeBeforePopUpgrade)
        {
            Debug.Log("erreur1");
            return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
            
        }
        else
        {
            Debug.Log("erreur2");
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
            }
            if (rand == 1)
            {
                return pub[Random.Range(0, pub.Length)];
            }
            if (rand == 2)
            {
                return fatalErreurSysteme[Random.Range(0, fatalErreurSysteme.Length)];
            }
        }
        return null;
    }

    public void QuitSysteme()
    {
        /*if (popInstance.GetComponent<Component>().PopDisplay().myType == popType.ErreurSysteme)
        {
            Destroy(popInstance);
        }

        else if (popInstance.GetComponent<Component>().PopDisplay().myType == popType.FatalErreurSysteme)
        {
            Destroy(popInstance);
            Instantiate(popInstance, popupParent);
        }

        else
        {
            return;
        }*/
    }

    public Vector2 RandomRange()
    {
        Vector2 range;
        range.x = Random.Range(0, Screen.width);
        range.y = Random.Range(0, Screen.height);
        
        return range;
    }

    private void InstancePopup()
    {
        Instantiate(popInstance, popupParent); 
    }
}
