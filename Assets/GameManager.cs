using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject meniuStart; // Aici vom trage Panelul în Inspector

    void Start()
    {
        // Oprim timpul jocului la început ca să nu cadă obiectele prin spate
        Time.timeScale = 0f; 
        meniuStart.SetActive(true); // Ne asigurăm că meniul e vizibil
    }

    public void IncepeJocul()
    {
        meniuStart.SetActive(false); // Ascundem meniul
        Time.timeScale = 1f; // Pornim timpul (obiectele încep să cadă)
    }
}