using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] public Player player;
    [SerializeField] private PlayerCamera camera_1;
    [SerializeField] private PlayerCamera camera_2;
    public Animator animator;
    public Animator ambientAnimator;
    public bool timeChange = false;
    public float timer = 5f;
    public float wheeltimer = 0.5f;
    public Dialogo cantTravel;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        player.controllPlayer = true;
        ChangeSensibility();
        //player.controller.enabled = true;
        //player.otherPlayer.controller.enabled = false;
    }

    public void ChangeSensibility()
    {
        camera_1.sensibilidad = slider.value * 4;
        camera_2.sensibilidad = slider.value * 4;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        wheeltimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && timer >= 1f)
        {

            if (!gameManager.Instance.canTravel)
            {
                cantTravel.StartConversation();
            }

            else
            {
                timer = 0f;
                animator.SetTrigger("Time");
                ambientAnimator.SetTrigger("Time");
                player.DisablePlayer();
                player = player.otherPlayer;
                player.EnablePlayer();
                gameManager.Instance.ChangeTimeLine();
                gameManager.Instance.inventory.ChangeAllItemsTime();
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (gameManager.Instance.currentItem == null) return;
            if (gameManager.Instance.GetTimeLine() == gameManager.TimeLine.Past) gameManager.Instance.currentItem.InteractPast();

            else gameManager.Instance.currentItem.InteractPresent();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (gameManager.Instance.currentItem == null) return;

            if (gameManager.Instance.GetTimeLine() == gameManager.TimeLine.Past) gameManager.Instance.currentItem.InteractPast();

            else gameManager.Instance.currentItem.InteractPresent();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f && wheeltimer >= 0.3f)
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
