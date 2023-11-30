using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Linq;
using TMPro;
using Unity.VisualScripting;

public class ShopListContent : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI notEnoughGoldText;
    [SerializeField] List<ShopItemSO> shopItemSOs = new List<ShopItemSO>();
    [SerializeField] GameObject shopItemTemplate;

    List<PowerUps> playerPowerUps = new List<PowerUps>();
    List<ShopItemSO> filteredItens = new List<ShopItemSO>();
    GameSession gameSession;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        GenerateShopItemList();
        notEnoughGoldText.text = "";
    }

    List<ShopItemSO> FilterAlreadyObtainedPowerUps()
    {
        var playerPowerUps = gameSession.LoadPlayerPowerUps();
        this.playerPowerUps = playerPowerUps.ToList();
        var filteredItens = shopItemSOs.Where(item => !playerPowerUps.Contains(item.PowerUp));

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
        notEnoughGoldText.text = "";

        if (gameSession.Coins >= item.Price)
        {
            playerPowerUps.Add(item.PowerUp);
            gameSession.PowerUps = playerPowerUps.ToArray();
            gameSession.SavePlayerPowerUps(playerPowerUps.ToArray());
            gameSession.Coins -= item.Price;
            gameSession.SaveCoins();

            ClearShopList();
            GenerateShopItemList();
        }
        else 
        {
            notEnoughGoldText.text = "You don't have enough gold!";
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
