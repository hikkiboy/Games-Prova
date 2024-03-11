using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputManager inputManager;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null) Destroy(this.gameObject);

        Instance = this;
        inputManager = new InputManager();
    }
}
