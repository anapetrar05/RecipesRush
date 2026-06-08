using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject meniuStart;
    void Start()
    {
       
        Time.timeScale = 0f; 
        meniuStart.SetActive(true); 
    }

    public void IncepeJocul()
    {
        meniuStart.SetActive(false);
        Time.timeScale = 1f; 
    }
}
