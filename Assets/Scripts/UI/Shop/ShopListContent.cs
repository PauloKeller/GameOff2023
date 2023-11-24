using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ShopListContent : MonoBehaviour
{
    [SerializeField] List<ShopItemSO> shopItemSOs = new List<ShopItemSO>();
    [SerializeField] GameObject shopItemTemplate; 

    void Start()
    {
        GenerateShopItemList();
    }

    void GenerateShopItemList() 
    {
        GameObject shopListItemGameObject;
        for (int index = 0; index < shopItemSOs.Count; index++)
        {
            var shopItemSO = shopItemSOs[index];
            shopListItemGameObject = Instantiate(shopItemTemplate, transform);
            var itemValue = $"{shopItemSO.Price}G";
            shopListItemGameObject.GetComponent<ShopItemTemplate>()
                .ConfigureItem(
                shopItemSO.ItemName,
                itemValue,
                shopItemSO.ItemImage,
                index,
                ItemClicked);
        }
    }

    void ItemClicked(int itemIndex)
    {
        Debug.Log($"Clicked on item {itemIndex}");
    }
}
