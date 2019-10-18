using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript: MonoBehaviour
{
    //GameLogic by Dorian Gélas 2019-2020*
    private GameManager _gameManager;
    private GameObject gameItem_GO;
    public GameManager.GameItem gameItem;
    

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        gameItem_GO = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
