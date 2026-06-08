using UnityEngine;
using TMPro;

public class AfisareStatistici : MonoBehaviour
{
  
    public TMP_Text textStatisticiUI;

 
    public void GenereazaSiArataStatistici()
    {
        if (textStatisticiUI != null)
        {

            
            int secundeTrecute = Mathf.RoundToInt(KitchenTable.timpTotalScurs);

            
            string raportFinal = "--- STATISTICI JOC ---\n\n" +
                                 "Ingrediente Corecte: <color=green>" + KitchenTable.ingredienteCorecteTotal + "</color>\n" +
                                 "Ingrediente Greșite: <color=red>" + KitchenTable.ingredienteGresiteTotal + "</color>\n" +
                                 "Timp total de Ales: " + secundeTrecute + "s";

            
            textStatisticiUI.text = raportFinal;
        }
    }
}
