using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Linq;

public class ShopListContent : MonoBehaviour
{
    [SerializeField] List<ShopItemSO> shopItemSOs = new List<ShopItemSO>();
    [SerializeField] GameObject shopItemTemplate;

    List<PowerUps> playerPowerUps = new List<PowerUps>();
    List<ShopItemSO> filteredItens = new List<ShopItemSO>();
    GameSession gameSession;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        GenerateShopItemList();
    }

    List<ShopItemSO> FilterAlreadyObtainedPowerUps()
    {
        var playerPowerUps = gameSession.LoadPlayerPowerUps();
        this.playerPowerUps = playerPowerUps.ToList();
        var filteredItens = shopItemSOs.Where(item => !playerPowerUps.Contains(item.PowerUp));

        foreach (var item in filteredItens) 
        {
            Debug.Log($"Filtered item {item.ItemName}");
        }

        return filteredItens.ToList();
    }

    void GenerateShopItemList() 
    {
        filteredItens = FilterAlreadyObtainedPowerUps();
        GameObject shopListItemGameObject;

        for (int index = 0; index < filteredItens.Count; index++)
        {
            var shopItemSO = filteredItens[index];
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
        var item = filteredItens[itemIndex];

        if (gameSession.Coins >= item.Price)
        {
            playerPowerUps.Add(item.PowerUp);
            gameSession.SavePlayerPowerUps(playerPowerUps.ToArray());

            ClearShopList();
            GenerateShopItemList();
        }
        else 
        {
            Debug.Log($"Not enoguth gold to buy {item.ItemName}");
        }
    }

    void ClearShopList() 
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
