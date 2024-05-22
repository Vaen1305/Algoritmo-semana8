using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject objetivo;
    public Vector2 speedReference;
    private float timer = 20f;
    private bool isMoving = true;

    public float stamina = 100f;
    public float staminaDrainRate = 1f;
    public float lowStaminaSpeedMultiplier = 0.5f;

    void Update()
    {
        if (isMoving)
        {
            stamina -= staminaDrainRate * Time.deltaTime;
            stamina = Mathf.Max(stamina, 0f);

            if (stamina <= 0f)
            {
                StopMovement();
            }
            else
            {
                float speedMultiplier = 1f;
                transform.position = Vector2.SmoothDamp(transform.position, objetivo.transform.position, ref speedReference, 0.5f / speedMultiplier);
                timer -= Time.deltaTime;
            }
        }
        else
        {
            if (timer <= -10f)
            {
                RestartMovement();
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Node") && isMoving)
        {
            objetivo = collision.gameObject.GetComponent<NodeController>().SelecRandomAdjacent().gameObject;
        }
    }

    private void StopMovement()
    {
        isMoving = false;
        timer = 1.5f;

        stamina = 5f;
    }

    private void RestartMovement()
    {
        isMoving = true;
        timer = 3f;
    }
}
