using UnityEngine;
using UnityEngine.SceneManagement; // Obligatoriu pentru schimbat scene

public class MeniuManager : MonoBehaviour
{
    public void PornesteJocul()
    {
        
        SceneManager.LoadScene("SampleScene"); 
    }
    public void MergiLaMeniu()
    {
    SceneManager.LoadScene("MainMeniu"); // Pune numele exact al scenei tale de start
    }
}