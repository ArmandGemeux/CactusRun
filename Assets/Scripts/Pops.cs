using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Pop", menuName = "Pop")]
public class Pops : ScriptableObject
{
    public new string name;
    public string description;
    public string typeErreur;

    public Sprite image;

}
