using UnityEngine;
using System.Collections;

public class EnemyWay : MonoBehaviour
{
    Vector3 _posSave;
    public float speed = 5f;
    public float rotationSpeed = 30f;


    private bool Active = false;

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
        
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator RepeatActionCoroutine()
    {
        yield return new WaitForSeconds(5f);
        Active = true;

        while (true)
        {
            Do();
            yield return new WaitForSeconds(3f);
        }

    }

    private void Do()
    {
        transform.position = _posSave;
        transform.rotation = Quaternion.Euler(0, 0, -15);
        

    }

    
}
