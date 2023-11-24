using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop Item", fileName = "ShopItem")]
public class ShopItemSO : ScriptableObject
{
    [SerializeField] string itemName = "Item name";
    [SerializeField] float price = 0f;
    [SerializeField] Sprite itemImage;

    public string ItemName { get { return itemName; } }
    public float Price { get { return price; } }

    public Sprite ItemImage { get {  return itemImage; } }
}
