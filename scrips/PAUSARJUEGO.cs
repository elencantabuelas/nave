using UnityEngine;

public class PAUSARJUEGO : MonoBehaviour
{
    public GameObject menu;
    public bool pausado = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        
            if (pausado)
                    {
                        Renaudar();
                    }
                    else
                    {
                        Pausar();
                    }

       }
    }

    public void Renaudar()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        pausado = false;
    }

    public void Pausar()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        pausado = true;
    }

}
