using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float jumpForce = 6f;
   
    public ParticleSystem trailParticles;

    Rigidbody2D rb;

    bool isAlive = true;


    private int score = 0;
    public TMP_Text scoreText;

    public TriggerEn trigCoin;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isAlive) return;

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space) || Tap())
        {
            Flap();
        }

        
    }

    bool Tap()
    {
        if (Input.touchCount > 0)
        {
            var t = Input.GetTouch(0);
            return t.phase == TouchPhase.Began;
        }
        return false;
    }

    void Flap()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        trailParticles?.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.CompareTag("Coin"))
        {
            Debug.Log("2");
            trigCoin.Visual.enabled = false;
            score++;
            scoreText.text = score.ToString();
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            ResetPlayer(new Vector3(-2.5f, 0f, 0f));
        }
    }

    public void ResetPlayer(Vector3 startPos)
    {
        transform.position = startPos;
        transform.rotation = Quaternion.identity;
        rb.linearVelocity = Vector2.zero;
        SceneManager.LoadScene(0);

        isAlive = true;
    }
}
