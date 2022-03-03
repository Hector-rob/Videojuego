using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//informar que es INDISPENSABLE este componente
[RequireComponent(typeof(Rigidbody))]
public class Pelota : MonoBehaviour
{
    //obtenerlo internamente
    [SerializeField]
    private Rigidbody rb;
    public Vector3 vector = new Vector3(0,600,0);
    public Vector3 cubepos;
    public float velocidadX = 500;
    public float velocidadY = 500;
    private int puntuacion;
    public Text puntos;
    public Text info;
    private string name;
    private GameObject cube;
    private Vector3 posVerdeArriba;
    private Vector3 posVerdeAbajo;

    // Start is called before the first frame update
    void Start()
    {
        //obtener referencia a objeto en el mismo game object
        //hacer en awake o start
        rb = GetComponent<Rigidbody>();
        rb.AddForce(vector);
        posVerdeArriba = GameObject.Find("Verde1").transform.position;
        posVerdeAbajo = GameObject.Find("Verde2").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
      if (transform.position.y > 8 || transform.position.y < -15){
        info.text = "Perdiste. Fin del Juego";
      }

    }

    void OnCollisionEnter(Collision c){
      if(c.transform.name == "BarritaArriba"){
          vector = new Vector3(Random.Range(-500,500),-700,0);
          rb.AddForce(vector);
      }
      else if (c.transform.name == "BarritaAbajo"){
          vector = new Vector3(Random.Range(-500,500),700,0);
          rb.AddForce(vector);
        }

      else if(c.transform.name == "LateralD"){
        if (vector.y > 0){
          vector = new Vector3(Random.Range(-300,-500),500,0);
          rb.AddForce(vector);
        }
        else{
          vector = new Vector3(Random.Range(-300,-500),-500,0);
          rb.AddForce(vector);
        }

      }
      else if(c.transform.name == "LateralI"){
        if (vector.y > 0){
          vector = new Vector3(Random.Range(300,500),500,0);
          rb.AddForce(vector);
        }
        else{
          vector = new Vector3(Random.Range(300,500),-500,0);
          rb.AddForce(vector);
        }
    }
  }

    void OnCollisionStay(Collision c){
  }

      //print(c.transform.name); el objeto con el que choca

    void OnCollisionExit(Collision c){


    }

    void OnTriggerEnter(Collider c){
       if (c.transform.tag == "Rojo" && c.gameObject.layer != 3){
         name = c.transform.name;
         cube = GameObject.Find(name);
         cubepos = cube.transform.position;
         cubepos.x += Random.Range(-10,10);
         if (cubepos.x < -23){
           cubepos.x += Random.Range(3,10);
         }
         else if(cubepos.x > 20){
           cubepos.x -= Random.Range(5,10);
         }
         cubepos.y += Random.Range(-5,5);
         if(cubepos.y > 2.27){
           cubepos.y -= Random.Range(2,7);
         }
         else if(cubepos.y < -11){
           cubepos.y += Random.Range(2,7);
         }
         Instantiate(cube,cubepos,cube.transform.rotation);
         AddOne();
        Destroy(c.gameObject);
       }
       if (c.gameObject.layer == 3 && c.transform.tag != "Rojo"){
         name = c.transform.name;
         cube = GameObject.Find(name);
         if (name.Contains("Verde1")){
           cubepos = posVerdeArriba;
         }
         else if (name.Contains("Verde2")){
           cubepos = posVerdeAbajo;
         }
         Instantiate(cube,cubepos,cube.transform.rotation);
         AddThree();
         Destroy(c.gameObject);
       }
       //destroy - destruir componente o game object




   }

   void OnTriggerStay(Collider c){



   }

   void OnTriggerExit(Collider c){


   }

   void AddOne(){
     puntuacion+=1;
     print("+1");
     print(puntuacion);
     puntos.text = "Puntuación: " + puntuacion.ToString();
     info.text = "Destruiste un cubo rojo: + 1 punto!";
     Invoke("delText",2);
   }

   void AddThree(){
     puntuacion+=3;
     print("+3");
     print(puntuacion);
     puntos.text = "Puntuación: " + puntuacion.ToString();
     info.text = "Destruiste un cubo verde: + 3 puntos!";
     Invoke("delText",2);
   }

   void delText(){
   info.text = "";
   }


}
