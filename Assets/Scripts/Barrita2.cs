using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Barrita2 : MonoBehaviour
{
    public float velocidadX = 50;
    public float velocidadY = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    transform.Translate((-vertical * Time.deltaTime)*velocidadY,(horizontal * Time.deltaTime)*velocidadX,0);

    }
}