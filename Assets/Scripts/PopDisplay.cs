using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopDisplay : MonoBehaviour
{
    private Pops pop;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI annotation;
    
    public Image imagePop;

    // Start is called before the first frame update
    void Start()
    {
        GameManager_Error.Instance.SendPop(pop);

        nameText.text = pop.name;
        descriptionText.text = pop.description;
        annotation.text = pop.typeErreur;

        imagePop.sprite = pop.image;
    }
}
