using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject transition;
    public string scene;
    public AudioSource select;
    public void SceneChange(string s)
    {
        float p = Random.RandomRange(0.85f, 1.15f);
        select.pitch = p;
        select.Play();
        scene = s;
        Instantiate(transition, transform.position, transform.rotation);
        Invoke("ChangeScene", 0.62f);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void URL(string url)
    {
        float p = Random.RandomRange(0.85f, 1.15f);
        select.pitch = p;
        select.Play();
        Application.OpenURL(url);
    }
}