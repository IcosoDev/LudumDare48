using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    public Light2D light;
    public Animator anim;
    public GameObject transition;
    public bool dead = false;
    public ParticleSystem bubbles;
    public AudioSource death;
    public AudioSource finish;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim.enabled = false;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
        if(Input.GetAxisRaw("Horizontal") > 0 && dead == false)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && dead == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(rb.velocity != new Vector2(0, 0))
        {
            bubbles.enableEmission = true;
        }
        else
        {
            bubbles.enableEmission = false;
        }

        light.intensity = (-Mathf.Log(-transform.position.y) + 2.71828f) / 15 + 0.8f;
        Mathf.Clamp(light.intensity, 0.2f, 1);
        if(float.IsNaN(light.intensity) || float.IsInfinity(light.intensity) || light.intensity > 1)
        {
            light.intensity = 1;
        }

        if(Input.GetKeyDown("escape"))
        {
            Deatha();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Death") && dead == false)
        {
            dead = true;
            Death();
        }

        if (collision.gameObject.CompareTag("Finish") && dead == false)
        {
            Complete();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death") && dead == false)
        {
            dead = true;
            Death();
        }
    }

    private void Death()
    {
        death.Play();
        anim.enabled = true;
        anim.SetTrigger("Dead");
        Instantiate(transition, transform.position, transform.rotation);
        Invoke("Dead", 0.62f);
    }

    private void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Deatha()
    {
        anim.enabled = true;
        anim.SetTrigger("Dead");
        Instantiate(transition, transform.position, transform.rotation);
        Invoke("Deada", 0.62f);
    }

    private void Deada()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void Complete()
    {
        finish.Play();
        anim.enabled = true;
        anim.SetTrigger("Dead");
        Instantiate(transition, transform.position, transform.rotation);
        Invoke("Completed", 0.62f);
    }

    private void Completed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}