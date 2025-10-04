using UnityEngine;
using UnityEngine.UI;


public class bala : MonoBehaviour
{
    public Vector3 TargetVector;
    public float velocidad = 10f;
    public float max = 3f;

    private monimiento nave;



    void Start()
    {
        Destroy(gameObject, max); //destruir la bala creada, donde gameobject hace referencia a este objeto en este caso la bala

    }



    void Update()
    {
        transform.Translate(velocidad * TargetVector * Time.deltaTime);
        //translate modifica el componente transfpom del objeto en concreto, la funcion recibe una velocidad, 
        //en este caso tenemos que asegurar que TargetVector coincida con el vector de la nave 

        // Ignorar colisión entre la nave y la bala // no funciono :(  //
        //nave = GameObject.FindGameObjectWithTag("Player").GetComponent<monimiento>();
        //Physics2D.IgnoreCollision(nave.GetComponent<Collider2D>(), GetComponent<Collider2D>());



    }

    // void OnCollisioN(Collision collision)
    // {
    //     if (collision.gameObject.tag == "meteoro")
    //     {
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "meteoro")
        {
            IncrementarPuntos();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void IncrementarPuntos()
    {
        monimiento.puntos++;
        updatepuntos();
    }

    private void updatepuntos()
    {
        GameObject txt = GameObject.FindGameObjectWithTag("UI");
        txt.GetComponent<Text>().text = "Puntos : " + monimiento.puntos;
    }

}
