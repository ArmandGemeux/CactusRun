﻿using System.Collections;
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
        pop = GameManager_Error.Instance.SendPop();
        Debug.Log(pop.name);
        nameText.text = pop.name;
        descriptionText.text = pop.description;
        annotation.text = pop.typeErreur;

        imagePop.sprite = pop.image;

        transform.position = GameManager_Error.Instance.RandomRange();
    }

    public void QuitSysteme()
    {

    }
}
