using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}