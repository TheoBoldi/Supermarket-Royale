using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIListener : MonoBehaviour
{
    private GameManager _gameManager;

    public Image player1item0;
    public Image player1item1;
    public Image player1item2;
    public Image player1item3;

    public Image player2item0;
    public Image player2item1;
    public Image player2item2;
    public Image player2item3;

    public Image player3item0;
    public Image player3item1;
    public Image player3item2;
    public Image player3item3;

    public Image player4item0;
    public Image player4item1;
    public Image player4item2;
    public Image player4item3;

    public Text player1scoretxt;
    public Text player2scoretxt;
    public Text player3scoretxt;
    public Text player4scoretxt;

    public Sprite banana;
    public Sprite carrot;
    public Sprite cheese;
    public Sprite cherrys;
    public Sprite chicken;
    public Sprite coconut;
    public Sprite cookie;
    public Sprite eggs;
    public Sprite fish;
    public Sprite hotdog;
    public Sprite kiwi;
    public Sprite milk;
    public Sprite mushrooms;
    public Sprite pear;
    public Sprite leek;
    public Sprite steak;
    public Sprite sushi;
    public Sprite tomato;
    public Sprite turnip;
    public Sprite yoghurt;

    private Dictionary<GameItem.ItemType, Sprite> spritedb = new Dictionary<GameItem.ItemType, Sprite>();

    private bool isInitialized = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (isInitialized) return;

        _gameManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
        player1item0 = GameObject.Find("P10").GetComponent<Image>();
        player1item1 = GameObject.Find("P11").GetComponent<Image>();
        player1item2 = GameObject.Find("P12").GetComponent<Image>();
        //player1item3 = GameObject.Find("P13").GetComponent<Image>();

        player2item0 = GameObject.Find("P20").GetComponent<Image>();
        player2item1 = GameObject.Find("P21").GetComponent<Image>();
        player2item2 = GameObject.Find("P22").GetComponent<Image>();
        //player2item3 = GameObject.Find("P23").GetComponent<Image>();

        player3item0 = GameObject.Find("P30").GetComponent<Image>();
        player3item1 = GameObject.Find("P31").GetComponent<Image>();
        player3item2 = GameObject.Find("P32").GetComponent<Image>();
        //player3item3 = GameObject.Find("P33").GetComponent<Image>();

        player4item0 = GameObject.Find("P40").GetComponent<Image>();
        player4item1 = GameObject.Find("P41").GetComponent<Image>();
        player4item2 = GameObject.Find("P42").GetComponent<Image>();
        //player4item3 = GameObject.Find("P43").GetComponent<Image>();

        player1scoretxt = GameObject.Find("P1Scr").GetComponent<Text>();
        player2scoretxt = GameObject.Find("P2Scr").GetComponent<Text>();
        player3scoretxt = GameObject.Find("P3Scr").GetComponent<Text>();
        player4scoretxt = GameObject.Find("P4Scr").GetComponent<Text>();

        banana = Resources.Load<Sprite>("Bananas");
        carrot = Resources.Load<Sprite>("Carrot");
        cheese = Resources.Load<Sprite>("Cheese");
        cherrys = Resources.Load<Sprite>("Cherrys");
        chicken = Resources.Load<Sprite>("Chicken");
        coconut = Resources.Load<Sprite>("Coconut");
        cookie = Resources.Load<Sprite>("Cookie");
        eggs = Resources.Load<Sprite>("Eggs");
        fish = Resources.Load<Sprite>("Fish");
        hotdog = Resources.Load<Sprite>("Hotdog");
        kiwi = Resources.Load<Sprite>("Kiwi");
        milk = Resources.Load<Sprite>("Milk");
        mushrooms = Resources.Load<Sprite>("Mushrooms");
        pear = Resources.Load<Sprite>("Pear");
        leek = Resources.Load<Sprite>("Poirot");
        steak = Resources.Load<Sprite>("Steak");
        sushi = Resources.Load<Sprite>("Sushi");
        tomato = Resources.Load<Sprite>("Tomato");
        turnip = Resources.Load<Sprite>("Turnip");
        yoghurt = Resources.Load<Sprite>("Yaourt");

        spritedb.Add(GameItem.ItemType.Banana, banana);
        spritedb.Add(GameItem.ItemType.Beef_Steak, steak);
        spritedb.Add(GameItem.ItemType.Carrot, carrot);
        spritedb.Add(GameItem.ItemType.Cheese, cheese);
        spritedb.Add(GameItem.ItemType.Cherry, cherrys);
        spritedb.Add(GameItem.ItemType.Chicken_Leg, chicken);
        spritedb.Add(GameItem.ItemType.Coconut, coconut);
        spritedb.Add(GameItem.ItemType.Cookie, cookie);
        spritedb.Add(GameItem.ItemType.Egg, eggs);
        spritedb.Add(GameItem.ItemType.Empty, null);
        spritedb.Add(GameItem.ItemType.Fish, fish);
        spritedb.Add(GameItem.ItemType.Hotdog, hotdog);
        spritedb.Add(GameItem.ItemType.Kiwi, kiwi);
        spritedb.Add(GameItem.ItemType.Leek, leek);
        spritedb.Add(GameItem.ItemType.Milk, milk);
        spritedb.Add(GameItem.ItemType.Mushroom, mushrooms);
        spritedb.Add(GameItem.ItemType.Pear, pear);
        spritedb.Add(GameItem.ItemType.Sushi, sushi);
        spritedb.Add(GameItem.ItemType.Tomato, tomato);
        spritedb.Add(GameItem.ItemType.Turnip, turnip);
        spritedb.Add(GameItem.ItemType.Yoghurt, yoghurt);

        isInitialized = true;
    }
    
    public void UpdateUI()
    {
        player1item0.sprite = spritedb[_gameManager.player1Itemlist[0]];
        player1item1.sprite = spritedb[_gameManager.player1Itemlist[1]];
        player1item2.sprite = spritedb[_gameManager.player1Itemlist[2]];
        //player1item3.sprite = spritedb[_gameManager.player1Itemlist[3]];

        player2item0.sprite = spritedb[_gameManager.player2Itemlist[0]];
        player2item1.sprite = spritedb[_gameManager.player2Itemlist[1]];
        player2item2.sprite = spritedb[_gameManager.player2Itemlist[2]];
        //player2item3.sprite = spritedb[_gameManager.player2Itemlist[3]];

        player3item0.sprite = spritedb[_gameManager.player3Itemlist[0]];
        player3item1.sprite = spritedb[_gameManager.player3Itemlist[1]];
        player3item2.sprite = spritedb[_gameManager.player3Itemlist[2]];
        //player3item3.sprite = spritedb[_gameManager.player3Itemlist[3]];

        player4item0.sprite = spritedb[_gameManager.player4Itemlist[0]];
        player4item1.sprite = spritedb[_gameManager.player4Itemlist[1]];
        player4item2.sprite = spritedb[_gameManager.player4Itemlist[2]];
        //player4item3.sprite = spritedb[_gameManager.player4Itemlist[3]];

        player1scoretxt.text = _gameManager.player1Score.ToString();
        player2scoretxt.text = _gameManager.player2Score.ToString();
        player3scoretxt.text = _gameManager.player3Score.ToString();
        player4scoretxt.text = _gameManager.player4Score.ToString();
    }
}
