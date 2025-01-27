using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Player player;
    public Animator animator;
    public Animator ambientAnimator;
    public bool timeChange = false;
    public float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player.controllPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer >= 1f)
        {
            timer = 0f;
            animator.SetTrigger("Time");
            ambientAnimator.SetTrigger("Time");
            player.DisablePlayer();
            player = player.otherPlayer;
            player.EnablePlayer();
        }
    }
}
