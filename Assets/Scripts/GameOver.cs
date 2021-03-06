/*
Actividad 3 - último prototipo de juego
Héctor Robles Villarreal A01634105
Diego Su Gómez  A01620476
Equipo 8
Viernes 29 de abril de 2022
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text textoPuntos;
    [SerializeField]
    private Text maxPuntos;
    // Start is called before the first frame update
    void Start()
    {
      textoPuntos.text = "Puntaje final: " + Pelota.puntuacion.ToString();
      maxPuntos.text = "Máxima puntuación: " + Pelota.maxPunt.ToString();
      Pelota.puntuacion = 0;
      Pelota.contPelotas = 1;
      Pelota.pantallaGame = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Again(){
      SceneManager.LoadScene(0);
    }
}
