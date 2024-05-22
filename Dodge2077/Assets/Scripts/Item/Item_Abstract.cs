using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.WSA;

public abstract class Item_Abstract : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    public float Duration { get; protected set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launcher();
        StartCoroutine(DeleteThisItem());
    }

    private void Launcher()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(x * speed, y * speed);
    }

    private void FixedUpdate()
    {
        if(transform.position.x < -3.0f || transform.position.x > 3.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * -1.0f, rb.velocity.y);
        }
        if(transform.position.y < -5.0f || transform.position.y > 5.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1.0f);
        }
    }

    private IEnumerator DeleteThisItem()
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Destroy");
        Destroy(gameObject);
    }

    public abstract void TakeItem(PlayerSkill _player);
    public abstract void TakeItem(PlayerSkill2 _player);
}
