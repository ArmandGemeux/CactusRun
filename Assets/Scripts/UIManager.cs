using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject antiVirusObject;
    public Animator antivirusAnimator;
    public TMP_Text tittleAntivirusText;
    public TMP_Text descriptionAntivirusText;

    public TMP_Text life;

    private float lifeValue;
    private float lifeShowing;

    public float lifeShowingSpeed;

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
        if (lifeValue > lifeShowing + 1)
        {
            lifeShowing += Time.deltaTime * lifeShowingSpeed;
        }
        else if (lifeValue < lifeShowing - 1)
        {
            lifeShowing -= Time.deltaTime * lifeShowingSpeed;
        }

        if (lifeShowing - 1 >= lifeValue && lifeValue >= lifeShowing + 1)
        {
            lifeShowing = lifeValue;
        }

        showLife(lifeShowing);
    }

    public void StartShowingAntivirus(string newTittleText, string newDescriptionText)
    {
        antiVirusObject.SetActive(true);

        tittleAntivirusText.text = newTittleText;
        descriptionAntivirusText.text = newDescriptionText;
        antivirusAnimator.SetBool("isShowing", true);

        Invoke("StopShowingAntivirus", timeShowingNotif);
    }

    private void StopShowingAntivirus()
    {
        antivirusAnimator.SetBool("isShowing", false);
    }

    public void SetLifeValue(float newLife)
    {
        lifeValue = newLife;
    }

    public void showLife(float newLife)
    {
        life.text = newLife.ToString("0") + (" %");
    }
}
