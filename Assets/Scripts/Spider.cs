using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField]
    private float timer, yOffset;

    private GameManager gameManager;

    private void Start()
    {
        timer = 15f;

        yOffset = .2f;

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gameManager.SetHasSpider(true);
    }

    private void Update()
    {
        Transform playerPosition = gameManager.GetPlayerPosition();
        
        Vector3 tempScale = this.gameObject.transform.localScale;
        
        Vector3 playerScale = gameManager.GetPlayerScale();
        
        Rigidbody2D playerRigidBody = gameManager.GetPlayerRigidBody();

        this.gameObject.transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y + yOffset, 0f);


        if ((playerScale.x < 0f && tempScale.x >= 0f) || (playerScale.x >= 0f && tempScale.x < 0f))
        {
            tempScale.x *= -1;

            this.gameObject.transform.localScale = tempScale;
        }

        if (Mathf.Abs(playerRigidBody.velocity.x) <= 0.1f && Mathf.Abs(playerRigidBody.velocity.y) <= 0.1f)
        {
            this.gameObject.GetComponent<Animator>().speed = 0f;
        }

        else
        {
            this.gameObject.GetComponent<Animator>().speed = 1f;
        }

        Destroy(this.gameObject, timer);

    }

    private void OnDestroy()
    {
        gameManager.SetHasSpider(false);
    }
}
