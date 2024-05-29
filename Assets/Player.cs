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
    public float staminaRechargeTime = 5f;
    private float staminaRechargeTimer = 0f;

    public float pursuitStaminaDrainRate = 2f;
    public GameObject player;
    public float visionRadius = 5f;

    private bool isPursuing = false;
    private Vector2 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isPursuing)
        {
            PursuePlayer();
        }
        else
        {
            Patrol();
        }

        if (Vector2.Distance(transform.position, player.transform.position) <= visionRadius)
        {
            isPursuing = true;
        }
        else if (isPursuing)
        {
            isPursuing = false;
            objetivo = null;
        }
    }

    void Patrol()
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
                MoveTowardsObjective();
                timer -= Time.deltaTime;
            }
        }
        else
        {
            RechargeStamina();
        }
    }

    void PursuePlayer()
    {
        stamina -= pursuitStaminaDrainRate * Time.deltaTime;
        stamina = Mathf.Max(stamina, 0f);

        if (stamina <= 0f)
        {
            StopMovement();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, pursuitStaminaDrainRate * Time.deltaTime);
        }
    }

    void MoveTowardsObjective()
    {
        if (objetivo != null)
        {
            float speedMultiplier = (stamina <= 20f) ? lowStaminaSpeedMultiplier : 1f;
            transform.position = Vector2.SmoothDamp(transform.position, objetivo.transform.position, ref speedReference, 0.5f / speedMultiplier);
        }
    }

    void RechargeStamina()
    {
        if (stamina < 100f)
        {
            staminaRechargeTimer += Time.deltaTime;
            if (staminaRechargeTimer >= staminaRechargeTime)
            {
                stamina = 100f;
                staminaRechargeTimer = 0f;
                RestartMovement();
            }
        }

        if (timer <= -10f)
        {
            RestartMovement();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Node") && isMoving)
        {
            NodeController nodeController = collision.gameObject.GetComponent<NodeController>();
            if (nodeController != null)
            {
                NodeController nextNode = nodeController.SelectRandomAdjacent();
                if (nextNode != null)
                {
                    objetivo = nextNode.gameObject;
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }

    private void StopMovement()
    {
        isMoving = false;
        timer = 10f;
    }

    private void RestartMovement()
    {
        isMoving = true;
        timer = 20f;
    }
}
