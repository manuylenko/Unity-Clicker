using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHelper : MonoBehaviour
{
    const int Freeq = 10;
    public int GameTime = 10;
    public Text GameTimeText;
    public EndMenuHelper EndMenuHelper;

    public GameObject RubyPrefab;

    public Text DamageText;
    public Slider HealthSlider;

    public Transform StartPosition;

    public GameObject GoldPrefab;

    public GameObject[] MonstersPrefabs;

    public Text PlayerGoldUI;
    public Text RubyText;

    public int PlayerGold;
    public int PlayerRuby;

    public int PlayerDamage = 10;

    public bool EndGame { get; set; }

    int _count;
    
    int _curentTime;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        SpawnMonster();

        InvokeRepeating("Timer", 0, 1);
    }

    void Timer()
    {
        _curentTime++;

        GameTimeText.text = (GameTime - _curentTime).ToString();
        if (_curentTime >= GameTime)
        ///Закончить игру
        {
            Time.timeScale = 0;
            EndGame = true;
            EndMenuHelper.gameObject.SetActive(true);
            EndMenuHelper.ShowEndGame(PlayerGold);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGoldUI.text = PlayerGold.ToString();
        DamageText.text = PlayerDamage.ToString();
        RubyText.text = PlayerRuby.ToString();
    }

    public void TakeRuby(int ruby)
    {
        PlayerRuby += ruby;

        GameObject rubyObj = Instantiate(RubyPrefab) as GameObject;
        Destroy(rubyObj, 3);
    }

    public void TakeGold(int gold)
    {
        PlayerGold += gold;

        GameObject goldObj = Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObj, 2);

        SpawnMonster();
    }

    public void SpawnMonster()
    {
        _count++;

        int randomMaxValue = _count / Freeq + 1;
        if (randomMaxValue >= MonstersPrefabs.Length)
            randomMaxValue = MonstersPrefabs.Length;

        int index = Random.Range(0, randomMaxValue);

        GameObject monsterObj = Instantiate(MonstersPrefabs[index])
            as GameObject;

        monsterObj.transform.position = StartPosition.position;

    }
}
