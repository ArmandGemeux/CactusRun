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
        AudioManager.Instance.PlaySound("Error");

        GameManager_Error.Instance.AddValueToLife(true);

        pop = GameManager_Error.Instance.SendPopup();
        nameText.text = pop.name;
        descriptionText.text = pop.description;
        annotation.text = pop.annotation;

        imagePop.sprite = pop.image;
        //imagePop.preserveAspect = true;

        transform.position = GameManager_Error.Instance.RandomRange();
    }

    public void QuitSysteme()
    {
        if(pop.myType == popType.ErreurSysteme)
        {
            Destroy(gameObject);
        }
        if(pop.myType == popType.FatalErreurSysteme)
        {
            GameManager_Error.Instance.fatalInvoke = true;
            GameManager_Error.Instance.InstancePopup();
            GameManager_Error.Instance.InstancePopup();
            Destroy(gameObject);
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

    private void OnDestroy()
    {
        AudioManager.Instance.PlaySound("CloseWindow");
        GameManager_Error.Instance.AddValueToLife(false);
    }
}
