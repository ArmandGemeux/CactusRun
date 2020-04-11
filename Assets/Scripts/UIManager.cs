using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Animator antivirusAnimator;
    public TMP_Text tittleAntivirusText;

    public float timeShowingNotif;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
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

    private void StartShowingAntivirus(string newTittleText, string newDescriptionText)
    {
        antivirusAnimator.gameObject.SetActive(true);
        Invoke("StopShowingAntivirus", timeShowingNotif);
    }

    private void StopShowingAntivirus()
    {
        antivirusAnimator.SetTrigger("StopShowing");
    }
}
