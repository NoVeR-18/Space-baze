using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    //здоровье героя
    [SerializeField]
    private Image[] HP = new Image[3];
    [SerializeField]
    private Sprite _Hpinactive;
    [SerializeField]
    private GameObject _loseMenu;
    [SerializeField]
    private GameObject _gameMenu;
    private int Hp = 2;
    private Sprite _Hpactive;
    private void Start()
    {
        _Hpactive = HP[0].sprite;
        Hp = 2;
    }
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            HP[Hp].sprite = _Hpinactive;
            Hp--;
        }
        if (Hp < 0)
        {
            Action();
        }
    }
    private void Action()
    {
        for(int i = 0; i < 3; i++)
        {
            HP[i].sprite = _Hpactive;
        }
        _gameMenu.SetActive(false);
        _loseMenu.SetActive(true);
        Hp = 2;
    }
}
