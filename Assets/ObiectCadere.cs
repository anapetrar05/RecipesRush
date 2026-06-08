using UnityEngine;

public class ObiectCadere : MonoBehaviour
{
    public float viteza = 5f;

    void Update()
    {
        // Ingredientele cad constant în jos
        transform.Translate(Vector3.down * viteza * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // LĂSĂM COȘUL SĂ SE OCUPE DE CAZUL 1 (când îl prinde, îl distruge el din scriptul playerControler)

        // Cazul 2: Dacă atinge banda roz de jos (PlatformaJos), dispare
        if (collision.CompareTag("PlatformaJos"))
        {
            Destroy(gameObject);
        }
    }
}