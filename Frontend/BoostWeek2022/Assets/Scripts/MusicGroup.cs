using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Music group")]
public class MusicGroup : ScriptableObject
{
    [SerializeField]
    private string musicGroupName;

    public string MusicGroupName => musicGroupName;
}
