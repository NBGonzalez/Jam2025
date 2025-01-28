using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] public Player player;
    public Animator animator;
    public Animator ambientAnimator;
    public bool timeChange = false;
    public float timer = 5f;
    public float wheeltimer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player.controllPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        wheeltimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer >= 1f)
        {
            
            timer = 0f;
            animator.SetTrigger("Time");
            ambientAnimator.SetTrigger("Time");
            player.DisablePlayer();
            player = player.otherPlayer;
            player.EnablePlayer();
            gameManager.Instance.ChangeTimeLine();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (gameManager.Instance.currentItem == null) return;

            if (gameManager.Instance.GetTimeLine() == gameManager.TimeLine.Past) gameManager.Instance.currentItem.InteractPast();

            else gameManager.Instance.currentItem.InteractPresent();
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f && wheeltimer >= 0.3f)
        {
            wheeltimer = 0f;
            gameManager.Instance.inventory.ChangeCurrentItem(gameManager.Instance.currentItem, 1);
        }

        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f && wheeltimer >= 0.3f)
        {
            wheeltimer = 0f;
            gameManager.Instance.inventory.ChangeCurrentItem(gameManager.Instance.currentItem, -1);

        }
    }
}
