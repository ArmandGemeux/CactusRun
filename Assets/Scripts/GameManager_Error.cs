using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Error : MonoBehaviour
{
    public bool fatalInvoke;
    public int timeBeforePopUpgrade = 15;
    public float timeBeforePopupSpawn = 2.5f;
    public bool canPopupSpawn;

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
        if(Input.GetKeyDown(KeyCode.A))
        {
            InstancePopup();
        }

        if(Time.time > timeBeforePopupSpawn && canPopupSpawn)
        {
            timeBeforePopupSpawn += Time.time;
            InstancePopup();
        }
    }

    public Pops SendPop()
    {
        if (Time.time > timeBeforePopUpgrade*2)
        {
            if(fatalInvoke == false)
            {
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
            else
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
                }
                if (rand == 1)
                {
                    return pub[Random.Range(0, pub.Length)];
                }
                fatalInvoke = false;
            }
            
        }
        else if(Time.time > timeBeforePopUpgrade)
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
            }
            if (rand == 1)
            {
                return pub[Random.Range(0, pub.Length)];
            }
        }
        else
        {
            return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
        }
        return null;
    }

    public Vector2 RandomRange()
    {
        Vector2 range;
        range.x = Random.Range(0, Screen.width);
        range.y = Random.Range(0, Screen.height);
        
        return range;
    }

    public void InstancePopup()
    {
        Instantiate(popInstance, popupParent); 
    }
}
