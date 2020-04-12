using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Error : MonoBehaviour
{
    public GameObject blueScreen;

    private float timeFromStart = 0;

    public bool fatalInvoke;
    [Range(10,30)]
    public int timeBeforePopUpgrade = 15;
    [Range(0,0.5f)]
    public float timeBeforePopupSpawn;
    [Range(0,3)]
    public float reduceSpawnIntervaleDivide = 1;
    public bool canPopupSpawn;

    private float saveTime;

    public GameObject popupPubInstance;
    public GameObject popInstance;
    public Transform popupParent;

    public Pops[] erreurSysteme;
    public Pops[] pub;
    public Pops[] fatalErreurSysteme;

    private bool erreurSystemeTuto = false;
    public string erreurSystemeTutoTitre;
    public string erreurSystemeTutoDescription;

    private bool pubTuto = false;
    public string pubTutoTitre;
    public string pubTutoDescription;

    private bool fatalErreurSystemeTuto = false;
    public string fatalErreurSystemeTutoTitre;
    public string fatalErreurSystemeTutoDescription;

    private float life = 0;

    public float CPUMessageValue;

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
        saveTime = reduceSpawnIntervaleDivide;
    }

    // Update is called once per frame
    void Update()
    {
        timeFromStart += Time.deltaTime;

        if (canPopupSpawn == false)
        { return; }

        if(Input.GetKeyDown(KeyCode.A))
        {
            InstancePopup();
        }

        if(timeFromStart > saveTime && canPopupSpawn)
        {
            saveTime /= timeBeforePopupSpawn;
            saveTime += timeFromStart;
            timeBeforePopupSpawn += reduceSpawnIntervaleDivide;
            InstancePopup();
        }
    }

    public Pops SendPopup()
    {
        if (timeFromStart > timeBeforePopUpgrade*2)
        {
            if(fatalInvoke == false)
            {
                int rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
                }
                if (rand == 2)
                {
                    if (fatalErreurSystemeTuto == false)
                    {
                        fatalErreurSystemeTuto = true;
                        UIManager.Instance.StartShowingAntivirus(fatalErreurSystemeTutoTitre, fatalErreurSystemeTutoDescription);
                    }

                    return fatalErreurSysteme[Random.Range(0, fatalErreurSysteme.Length)];
                }
            }
            else
            {
                fatalInvoke = false;
                return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
            }
            
        }
        else
        {
            if (erreurSystemeTuto == false)
            {
                erreurSystemeTuto = true;
                UIManager.Instance.StartShowingAntivirus(erreurSystemeTutoTitre, erreurSystemeTutoDescription);
            }

            return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
        }
        return erreurSysteme[Random.Range(0, erreurSysteme.Length)];
    }

    public Pops SendPopupPub()
    {
        return pub[Random.Range(0, pub.Length)];
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
        if(timeFromStart > timeBeforePopUpgrade)
        {
            int rand = Random.Range(0, 3);
            if(rand > 0)
            {
                Instantiate(popInstance, popupParent);
            }
            if (rand == 0)
            {
                if (pubTuto == false)
                {
                    pubTuto = true;
                    UIManager.Instance.StartShowingAntivirus(pubTutoTitre, pubTutoDescription);
                }

                Instantiate(popupPubInstance, popupParent);
            }
        }
        else
        {
            Instantiate(popInstance, popupParent);
        }
    }

    public void EnableBlueScreen()
    {
        blueScreen.SetActive(true);
    }

    public void DisableBlueScreen()
    {
        blueScreen.SetActive(false);
    }

    public void QuitApplication()
    {
        EnableBlueScreen();
        Application.Quit();
    }

    public void Restart()
    {
        DisableBlueScreen();
        SceneManager.LoadScene("AntoineDino");
    }

    public void AddValueToLife(bool isPositive)
    {
        if (isPositive == true)
        {
            life += CPUMessageValue;
        }
        else
        {
            life -= CPUMessageValue;
        }

        UIManager.Instance.SetLifeValue(life);
    }
}