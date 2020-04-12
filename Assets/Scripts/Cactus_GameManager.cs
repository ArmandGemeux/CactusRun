using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cactus_GameManager : MonoBehaviour
{
    public static Cactus_GameManager Instance;
    public GameObject obstacle;
    public Transform spawnPoint;

    public Animator myAnimator;

    public float CD;
    private float CDActual;
    public float randomRange;

    [HideInInspector]
    public float score = 0;

    public TextMeshProUGUI scoreText;

    [HideInInspector]
    public bool isAlive = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
        CDActual = SetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            CDActual -= Time.deltaTime;
            score += Time.deltaTime;
        }

        ShowScore();

        if (CDActual <= 0)
        {
            SpawnObstacle();
            CDActual = SetDistance();
        }
    }

    private float SetDistance()
    {
        return (CD + (CD * ((Random.Range(-randomRange, randomRange))/100)));
    }

    private void SpawnObstacle()
    {
        Instantiate(obstacle, spawnPoint, false);
    }

    private void ShowScore()
    {
        scoreText.text = (score * 5).ToString("0");
    }

    public void Die()
    {
        GameManager_Error.Instance.canPopupSpawn = false;
        isAlive = false;
        GameManager_Error.Instance.ToggleBlueScreen();
    }
}