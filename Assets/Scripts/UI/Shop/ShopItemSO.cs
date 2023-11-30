using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop Item", fileName = "ShopItem")]
public class ShopItemSO : ScriptableObject
{
    [SerializeField] string itemName = "Item name";
    [SerializeField] int price = 0;
    [SerializeField] Sprite itemImage;
    [SerializeField] PowerUps powerUp;

    public string ItemName { get { return itemName; } }
    public int Price { get { return price; } }

    public Sprite ItemImage { get {  return itemImage; } }

    public PowerUps PowerUp { get { return powerUp; } }
}
