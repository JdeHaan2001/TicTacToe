using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : PlayerBase
{
    private Image[] _imageList;

    private void Start()
    {
        _imageList = GameManager.Instance.GetImageList();
        SetPlayerNumber(1);

        foreach (Image image in _imageList)
            image.GetComponent<Button>().onClick.AddListener(delegate { GameManager.Instance.MakeMove(image, GetPlayerNumber()); });
    }

    private void Update()
    {
        
    }
}
