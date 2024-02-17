using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string startScene;

    public List<Animator> prizesAnimators = new List<Animator>();
    public ClawController leftClawController;
    public ClawController rightClawController;

    private bool clawOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMenuTheme(2);
        InvokeRepeating("ShakeRandomPrize", 0f, 2f);
        InvokeRepeating("ChangeClawPosition", 0f, 6f);
    }

    void FixedUpdate()
    {
        if (clawOpened)
        {
            OpenClaws();
        }
        else
        {
            CloseClaws();
        }
    }

    public void ShakeRandomPrize()
    {
        int randomIndex = Random.Range(0, prizesAnimators.Count);
        prizesAnimators[randomIndex].SetTrigger("Shake");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
        Debug.Log("Loading Game");

        PlayerPrefs.DeleteAll();
    }

    public void ChangeClawPosition()
    {
        if (clawOpened)
        {
            clawOpened = false;
        }
        else
        {
            clawOpened = true;
        }
    }

    private void OpenClaws()
    {
        Debug.Log("Open Claws...");
        leftClawController.OpenClaw();
        rightClawController.OpenClaw();
    }

    private void CloseClaws()
    {
        Debug.Log("Closing Claws...");
        leftClawController.CloseClaw();
        rightClawController.CloseClaw();
    }

}
