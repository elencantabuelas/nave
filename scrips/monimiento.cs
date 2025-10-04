using UnityEngine;
using UnityEngine.SceneManagement;

public class monimiento : MonoBehaviour
{

    public float fempuje = 1f;
    public float frotacion = 12f;

    public static int puntos = 0;

    //---------------- BALAS

    public GameObject gun, bala;




    private Rigidbody2D body;
    void Start() // se ejecutara una sola vez en el primer frame del gameobject, en este caso Start dara acceso a la nave
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Bullet"), true);
        body = GetComponent<Rigidbody2D>(); //inicializacion, funcion que permite acceder a cualquier componente asociado poniendo el tipo del mismo
    }

    void Update() //se ejecuta al final de un frame siempre
    {
        float rotacion = Input.GetAxis("Horizontal") * Time.deltaTime;
        float empuje = Input.GetAxis("Vertical") * Time.deltaTime;//usamos librerias de unity para interartuar desde el periferico con el movimiento de la nave

        Vector3 direccion = transform.right;
        body.AddForce(direccion * empuje * fempuje);

        transform.Rotate(Vector3.forward, -rotacion * frotacion);

        if (Input.GetKeyDown(KeyCode.Space)) // en caso de que se este pulasando el espacio
        {
            GameObject balas = Instantiate(bala, gun.transform.position, Quaternion.identity);// se instancian objetos de tipo bala en la escena en ciertas coordenadas

            bala direccionBala = bala.GetComponent<bala>();

            direccionBala.TargetVector = transform.right; //la direccion en la que sale disparada la bala sera la misma que tenga el componente transform.right de la nave

        }


        Vector3 pos = transform.position;

        float altura = Camera.main.orthographicSize;
        float ancho = altura * Camera.main.aspect;

        // Derecha → Izquierda
        if (pos.x > ancho)
            pos.x = -ancho;
        // Izquierda → Derecha
        else if (pos.x < -ancho)
            pos.x = ancho;

        // Arriba → Abajo
        if (pos.y > altura)
            pos.y = -altura;
        // Abajo → Arriba
        else if (pos.y < -altura)
            pos.y = altura;

        transform.position = pos;

        

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "meteoro")
        {
            puntos = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //tambien puedes poner el nombre de la scena 
        }
    }

}
