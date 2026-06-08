using UnityEngine;
using TMPro;

public class AfisareStatistici : MonoBehaviour
{
    // Legătura către textul de pe ecran
    public TMP_Text textStatisticiUI;

    // Această funcție va fi apelată când dăm click pe buton
    public void GenereazaSiArataStatistici()
    {
        if (textStatisticiUI != null)
        {
            // Transformăm secundele totale într-un format frumos
            int secundeTrecute = Mathf.RoundToInt(KitchenTable.timpTotalScurs);

            // REPARAT: Am eliminat spațiul din numele variabilei și am potrivit string-urile corect
            string raportFinal = "--- STATISTICI JOC ---\n\n" +
                                 "Ingrediente Corecte: <color=green>" + KitchenTable.ingredienteCorecteTotal + "</color>\n" +
                                 "Ingrediente Greșite: <color=red>" + KitchenTable.ingredienteGresiteTotal + "</color>\n" +
                                 "Timp total de Ales: " + secundeTrecute + "s";

            // Îl punem pe ecran
            textStatisticiUI.text = raportFinal;
        }
    }
}