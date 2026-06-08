using UnityEngine;

public class ObiectCadere : MonoBehaviour
{
    public float viteza = 5f;

    void Update()
    {
        
        transform.Translate(Vector3.down * viteza * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("PlatformaJos"))
        {
            Destroy(gameObject);
        }
    }
}
