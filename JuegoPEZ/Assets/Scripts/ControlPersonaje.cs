using System.Collections;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed;
    public bool isMoving;
    public Vector2 input;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

           
            if (input != Vector2.zero)
            {
                animator.SetFloat("MoveY", input.y);
                animator.SetFloat("MoveX", input.x);

                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;

                StartCoroutine(Move(targetPosition));
            }
        }

        animator.SetBool("IsMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPosition)
    {
        isMoving= true;
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed*Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;

        isMoving= false;
    }
}
