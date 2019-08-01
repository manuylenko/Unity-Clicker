using UnityEngine;
using System.Collections;

public class BulletHelper : MonoBehaviour
{
    HealthHelper _healthHelper;

    public int Damage { get; set; }

    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (_healthHelper == null)
            _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _healthHelper.transform.position,
                Time.deltaTime * 15);

            if (Vector2.Distance(transform.position, 
                _healthHelper.transform.position) < 0.1f)
            ///Попал
            {
                _healthHelper.GetHit(Damage);

                Destroy(gameObject);
            }
        }
    }
}
