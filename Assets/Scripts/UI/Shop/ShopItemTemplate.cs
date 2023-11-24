using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Reflection;

public class ShopItemTemplate : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemValueText;
    [SerializeField] Image itemImage;
    [SerializeField] Button itemButton;

    public void ConfigureItem(string name, string value, Sprite image, int index, Action<int> OnClick) 
    { 
        itemNameText.text = name;
        itemValueText.text = value;
        itemImage.sprite = image;
        itemButton.AddEventListener(index, OnClick);
    }
}
