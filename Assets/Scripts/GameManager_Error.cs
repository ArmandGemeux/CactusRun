using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Error : MonoBehaviour
{
    public int timeBeforePopUpgrade = 10;

    public GameObject popInstance;

    public Pops[] erreurSysteme;
    public Pops[] pub;
    public Pops[] fatalErreurSysteme;

    private Vector2 range;

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

    public void SendPop(Pops pop)
    {
        if(Time.time < timeBeforePopUpgrade)
        {
            pop = erreurSysteme[Random.Range(0, erreurSysteme.Length)];
            return;
        }
        if(Time.time > timeBeforePopUpgrade)
        {
            int rand = Random.Range(0, 3);
            if(rand == 0)
            {
                pop = erreurSysteme[Random.Range(0, erreurSysteme.Length)];
            }
            if (rand == 1)
            {
                pop = pub[Random.Range(0, pub.Length)];
            }
            if (rand == 2)
            {
                pop = fatalErreurSysteme[Random.Range(0, fatalErreurSysteme.Length)];
            }
        }
    }

    public void QuitSysteme()
    {
        /*if (Instance.GetComponent<Component>().PopDisplay().myType == popType.ErreurSysteme)
        {
            Destroy(popInstance);
        }

        else if (Instance.GetComponent<Component>().PopDisplay().myType == popType.FatalErreurSysteme)
        {
            Destroy(popInstance);
            Instantiate(popInstance,range,Quaternion.identity);
            
        }

        else
        {
            return;
        }*/
    }

    private void RandomRange()
    {
        range.x = Random.Range(0, Screen.width);
        range.y = Random.Range(0, Screen.height);
    }
}
