using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //move
    [SerializeField]
    private Vector3 moveDir;
    private Vector2 inputDir;
    public float moveSpeed = 10.0f;

    // Cashing
    private Transform playerTr;
    private Animator playerAnim;

    // AnimationCash
    private int hashWalk;
    // Start is called before the first frame update
    void Start()
    {
        Cashing();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    public void Cashing()
    {
        playerAnim = GetComponent<Animator>();
        playerTr = GetComponent<Transform>();
    }

    public void AnimationCashing()
    {
        hashWalk = Animator.StringToHash("isWalking");
    }
    void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        moveDir = new Vector3(inputDir.x, 0, inputDir.y);
    }
    public void Move()
    {
        if (moveDir != Vector3.zero)
        {
            playerAnim.SetBool(hashWalk, true);
            playerTr.rotation = Quaternion.LookRotation(moveDir);
            playerTr.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            playerAnim.SetBool(hashWalk, false);
        }
    }
}
