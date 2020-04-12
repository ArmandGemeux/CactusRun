using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupPubDisplay : MonoBehaviour
{
    private Pops pop;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI annotation;

    public Image imagePop;

    // Start is called before the first frame update
    void Start()
    {
        pop = GameManager_Error.Instance.SendPopupPub();
        nameText.text = pop.name;
        descriptionText.text = pop.description;
        annotation.text = pop.annotation;

        imagePop.sprite = pop.image;
        //imagePop.preserveAspect = true;

        transform.position = GameManager_Error.Instance.RandomRange();
    }

    public void QuitSysteme()
    {
        if (pop.myType == popType.Pubs)
        {
            Debug.Log("ne se ferme pas comme ça");
        }
    }

    public void ForceQuit()
    {
        Destroy(gameObject);
    }

    public popType GetMyType()
    {
        return pop.myType;
    }
}
