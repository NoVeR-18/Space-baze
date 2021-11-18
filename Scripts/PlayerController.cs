using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _laser;

    [SerializeField]
    public GameObject _touchMarker;
    [SerializeField]
    public GameObject _joystic;

    private Vector3 _targetVector;

    private void Start()
    {
        _touchMarker.transform.position = _joystic.transform.position;
    }
    void Update()
    {
        Controll();
    }


    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Asteroid")
        {
            Destroy(triggerCollider.gameObject);
        }
    }
    private void Controll()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 _touchPos = Input.mousePosition;
            _targetVector = _touchPos - _joystic.transform.position;
            if (_targetVector.magnitude < 100)
            {
                _touchMarker.transform.position = _touchPos;
                //_laser.transform.Rotate(0, 0,Mathf.Tan(_targetVector.x/ _targetVector.y));
                float angle = Mathf.Atan2(_targetVector.x, _targetVector.y) * Mathf.Rad2Deg;

                _laser.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle+180));
                //_laser.transform.rotation = _targetVector;
            }
        }
    }
}