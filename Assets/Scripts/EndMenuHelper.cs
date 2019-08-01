using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndMenuHelper : MonoBehaviour
{

    public Text MyGoldText;
    public Text RecordGoldText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowEndGame(int gold)
    {
        MyGoldText.text = gold.ToString();

        if (SettingClass.GoldRecord < gold)
        {
            SettingClass.GoldRecord = gold;
        }

        RecordGoldText.text = SettingClass.GoldRecord.ToString();
    }

    public void ButtonRestsrtClick()
    {
        SceneManager.LoadScene("Main");
    }
}
