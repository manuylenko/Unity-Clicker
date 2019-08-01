using UnityEngine;
using System.Collections;

public class HitHelper : MonoBehaviour
{
    GameHelper _gameHelper;
    PlayerHelper _playerHelper;
    // Use this for initialization
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown()");
        if (_gameHelper.EndGame)
            return;

        GetComponent<HealthHelper>().GetHit(_gameHelper.PlayerDamage);

        _playerHelper.RunAttack();
    }
}
