using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObiectPrefab;
    public Sprite[] ToatePngUrile;
    public float timpIntreSpawn = 2f;
    
    [Header("Zona de Cadere intre Mese")]
    public float limitaStanga = -2f;
    public float limitaDreapta = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timpIntreSpawn)
        {
            SpawnObiect();
            timer = 0f;
        }
    }

    void SpawnObiect()
    {
        float pozitieXAleatorie = Random.Range(limitaStanga, limitaDreapta);
        Vector3 pozitieSpawn = new Vector3(pozitieXAleatorie, transform.position.y, transform.position.z);

        GameObject nouObiect = Instantiate(ObiectPrefab, pozitieSpawn, Quaternion.identity);
        
        SpriteRenderer render = nouObiect.GetComponent<SpriteRenderer>();
        if (render != null && ToatePngUrile.Length > 0)
        {
            int indexAleatoriu = Random.Range(0, ToatePngUrile.Length);
            render.sprite = ToatePngUrile[indexAleatoriu];
            nouObiect.name = ToatePngUrile[indexAleatoriu].name;
        }
    }
}