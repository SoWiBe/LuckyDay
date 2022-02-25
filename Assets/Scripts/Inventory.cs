using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> Items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;

    private void OnEnable()
    {
        Render(Items);
    }
    public void Render(List<AssetItem> Items)
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);

        Items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Render(item);
        });
    }
}
