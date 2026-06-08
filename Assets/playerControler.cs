using UnityEngine;
using UnityEngine.InputSystem;

public class playerControler : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 10f;
    Rigidbody2D rb;

    [Header("Overcooked Logic")]
    public string currentIngredientInBasket = ""; 
    public KitchenTable table1; 
    public KitchenTable table2; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current != null)
        {
            float left = Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed ? -1f : 0f;
            float right = Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed ? 1f : 0f;
            horizontalInput = left + right;

            
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                SendToTable(table2);
            }
           
            if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                SendToTable(table1);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "platform") return;

        if (currentIngredientInBasket == "")
        {
            string cleanName = collision.gameObject.name.Replace("(Clone)", "").Trim().ToLower();
            cleanName = cleanName.Replace("_0", "");
            currentIngredientInBasket = cleanName;
            Destroy(collision.gameObject);
        }
    }

    void SendToTable(KitchenTable targetTable)
    {
        if (targetTable != null && currentIngredientInBasket != "")
        {
            targetTable.ReceiveIngredient(currentIngredientInBasket);
            currentIngredientInBasket = ""; 
        }
    }
}