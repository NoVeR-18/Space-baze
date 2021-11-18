using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    //атака героя
    public static float X = 0;

    [SerializeField]
    private Button _fireButton;
    private bool onClick = false;
    [SerializeField]
    private float power = 5;
    [SerializeField]
    private GameObject _laserLine;
    private bool createBall = true;

    private PlayerController _playerController;
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }
    void Update()
    {

        if (onClick == true && createBall == true)
        {
            CreateBall();
        }
    }

    private void CreateBall()
    {
        RaycastHit2D[] _raycastHit2Ds;
        _raycastHit2Ds = Physics2D.RaycastAll(transform.position, -(_playerController._joystic.transform.position - _playerController._touchMarker.transform.position) , 100.0F);
        StartCoroutine(LaserShow());
        for (int i = 0; i < _raycastHit2Ds.Length; i++)
        {
            if (_raycastHit2Ds[i].transform.tag == "Asteroid")
            {
                ScoreController.CurScore++;
                Destroy(_raycastHit2Ds[i].transform.gameObject);
            }
        }
        StartCoroutine(Reload());
    }

    public void OnButtonDown()
    {
        onClick = true;
    }

    public void OnButtonUp()
    {
        onClick = false;
    }
    private IEnumerator Reload()
    {
        createBall = false;
        _fireButton.interactable = false;
        yield return new WaitForSeconds(0.5f);
        _fireButton.interactable = true;
        createBall = true;
    }
    private IEnumerator LaserShow()
    {
        _laserLine.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _laserLine.SetActive(false);

    }
}
