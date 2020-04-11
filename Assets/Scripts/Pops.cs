using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum popType { ErreurSysteme, Pubs, FatalErreurSysteme }
[CreateAssetMenu(fileName = "new Pop", menuName = "Pop")]
public class Pops : ScriptableObject
{
    public popType myType;
    public new string name;
    public string description;
    public string typeErreur;

    public Sprite image;

}
