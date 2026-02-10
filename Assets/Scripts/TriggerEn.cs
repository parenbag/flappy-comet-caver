using UnityEngine;
using System.Collections;

public class TriggerEn : MonoBehaviour
{


    Vector3 _posSave;
    public float speed = 5f;
    public float rotationSpeed = 30f;


    private bool isPlayerDetected = false;
    private Transform playerTransform;

    private bool Active = false;

    public SpriteRenderer Visual;

    void Awake()
    {
        _posSave = transform.position;
    }

    void Start()
    {
        StartCoroutine(RepeatActionCoroutine());
    }

    void Update()
    {
        if (Active)
        {
            MoveLeft();
        }
        if (isPlayerDetected && Visual.enabled)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }

    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator RepeatActionCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Active = true;

        while (true)
        {
            Do();
            yield return new WaitForSeconds(7f);
        }

    }

    private void Do()
    {
        transform.position = _posSave;
        transform.rotation = Quaternion.Euler(0, 0, -15);
        Visual.enabled = true;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerDetected = true;
            playerTransform = other.transform;
        }
    }

}
