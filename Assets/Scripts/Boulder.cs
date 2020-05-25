using UnityEngine;

public class Boulder : MonoBehaviour
{

    private GameManager gameManager;

    [SerializeField]
    private bool isActive; 

    private void Start()
    {
        isActive = false;

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void SetActiveStatus(bool newIsActive)
    {
        isActive = newIsActive;
    }

    public void KillPlayer()
    {
        gameManager.SetIsAlive(false);
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}
