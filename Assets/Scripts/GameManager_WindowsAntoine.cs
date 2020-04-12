using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_WindowsAntoine : MonoBehaviour
{
    public GameObject taskManager;
    public KeyCode[] taskManagerKeys;
    private int keyNumberActual = 0;

    public float timeToNextKey;
    private float timeToNextKeyActual;
    private bool isOpenning = false;

    public Transform popupParent;
    public Transform taskParent;

    public static GameManager_WindowsAntoine Instance;
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
        if (isOpenning == true)
        {
            timeToNextKeyActual += Time.deltaTime;

            if (timeToNextKeyActual >= timeToNextKey)
            {
                timeToNextKeyActual = 0;
                keyNumberActual = 0;
                isOpenning = false;
            }
        }

        if (Input.GetKeyDown(taskManagerKeys[keyNumberActual]))
        {
            timeToNextKeyActual = 0;
            isOpenning = true;

            if (keyNumberActual < taskManagerKeys.Length - 1)
            {
                keyNumberActual++;
            }
            else if (keyNumberActual >= taskManagerKeys.Length - 1)
            {
                OpenTaskManager();
                keyNumberActual = 0;
            }
        }
    }

    public void CloseTaskManager()
    {
        taskManager.SetActive(false);
    }

    public void OpenTaskManager()
    {
        taskManager.SetActive(true);
        
        for (int i = 0; i < popupParent.childCount; i ++)
        {
            if (popupParent.GetChild(i).gameObject.GetComponent<PopupPubDisplay>() != null)
            {
                bool finished = false;

                for (int k = 0; k < taskParent.childCount; k ++)
                {
                    if ((taskParent.GetChild(k).gameObject.activeInHierarchy == false) && (finished == false))
                    {
                        taskParent.GetChild(k).gameObject.SetActive(true);
                        taskParent.GetChild(k).gameObject.GetComponent<TaskScript>().SetMyPop(popupParent.GetChild(i).gameObject);
                        finished = true;
                    }
                }
            }
        }
    }
}
