using UnityEngine;
using UnityEngine.SceneManagement; 
public class MeniuManager : MonoBehaviour
{
    public void PornesteJocul()
    {
        
        SceneManager.LoadScene("SampleScene"); 
    }
    public void MergiLaMeniu()
    {
    SceneManager.LoadScene("MainMeniu"); 
    }
}
