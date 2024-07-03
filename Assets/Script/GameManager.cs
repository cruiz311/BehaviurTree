using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // La instancia Singleton
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // Si ya existe una instancia y no es esta, destruye este GameObject
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Establecer esta instancia como la única instancia
            Instance = this;
            // Hacer que esta instancia persista entre las escenas
            DontDestroyOnLoad(gameObject);
        }
    }


    public int numerosPolicia;
    public int numerosZombie;
    public int numerosCivil;

    public void ActualizarDatos()
    {


        SceneManager.LoadScene("base");
    }
}
