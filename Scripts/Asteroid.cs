using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector2 _speedMinMax = new Vector2(15, 23);



    void Start()
    {
        _speed = Mathf.Lerp(_speedMinMax.x, _speedMinMax.y, Difficult.GetDifficultyPercent());
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0f, 0f, 4f * Time.deltaTime));
        transform.position = Vector3.Lerp(transform.position, new Vector2(0f, 0f), _speed * 0.0001f);
        //transform.Translate( (0f,0f,0.4f)_speed * Time.deltaTime, Camera.main.transform);

    }
}
