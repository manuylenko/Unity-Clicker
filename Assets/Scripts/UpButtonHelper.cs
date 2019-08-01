using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpButtonHelper : MonoBehaviour
{
    public bool IsRuby;

    public bool IsHero;
    public GameObject HeroPrefab;


    public GameObject UpPrefab;

    public Text DamageText;
    public Text PriceText;
    public Image IcoImage;

    public int Damage = 10;
    public int Price = 100;

    GameHelper _gameHelper;
    // Use this for initialization
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();
    }

    // Update is called once per frame//
    void Update()
    {

    }

    public void UpClick()
    {

        if (!IsRuby && _gameHelper.PlayerGold >= Price
            ||
            IsRuby && _gameHelper.PlayerRuby >= Price
            )
        {
            if (!IsRuby)
                _gameHelper.PlayerGold -= Price;
            else
                _gameHelper.PlayerRuby -= Price;

            if (IsHero == false)
                _gameHelper.PlayerDamage += Damage;
            else
            {
                GameObject hero = Instantiate(HeroPrefab) as GameObject;
                Vector3 heroPos = new Vector3(
                    Random.Range(3.0f, 7.0f),
                    -3.5f,
                    0);
                hero.transform.position = heroPos;

            }
            GameObject upEffect = Instantiate(UpPrefab) as GameObject;

            Transform canvas = GameObject.Find("Canvas").transform;
            upEffect.transform.SetParent(canvas);
            upEffect.GetComponent<Image>().sprite = IcoImage.sprite;
            Destroy(upEffect, 1);

            if (IsHero == false)
                Destroy(gameObject);
        }
    }
}
