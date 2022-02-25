using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : IItem
{
    public string Name => throw new NotImplementedException();

    public Sprite UIICon => throw new NotImplementedException();

    [SerializeField] private string name;
    [SerializeField] private Sprite _uiIcon;
}

 