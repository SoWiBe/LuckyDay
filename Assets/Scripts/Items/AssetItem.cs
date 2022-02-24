using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
class AssetItem : IItem
{
    public string Name => throw new NotImplementedException();

    public Texture2D UIICon => throw new NotImplementedException();

    [SerializeField] private string name;
    [SerializeField] private Texture2D _uiIcon;
}

