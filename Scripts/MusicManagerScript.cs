using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManagerScript : MonoBehaviour
{
    public GameObject transition;
    public float t;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Invoke("Transition", t);
    }

    public void Transition()
    {
        Instantiate(transition, transform.position, transform.rotation);
        Invoke("TransitionA", 0.6f);
    }

    public void TransitionA()
    {
        SceneManager.LoadScene("MenuScene");
    }
}