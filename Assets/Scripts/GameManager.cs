using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Intro & Guide UI")]
    public GameObject titleText;
    public GameObject conceptText;
    public GameObject guideText;

    [Header("UI")]
    public GameObject startButton;
    public GameObject restartButton;
    public TextMeshProUGUI machineCounterText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resultText;

    [Header("Machines")]
    public Machine[] machines;

    [Header("Player")]
    public Transform playerTransform;

    [Header("Game Settings")]
    public float gameDuration = 60f;

    private float remainingTime;
    private bool gameStarted = false;
    private bool gameEnded = false;

    // Player spawn storage (ONLY ONCE)
    private Vector3 initialPlayerPosition;
    private Quaternion initialPlayerRotation;
    private bool spawnStored = false;

    void Start()
    {
        // Store player spawn ONLY ONCE
        if (!spawnStored && playerTransform != null)
        {
            initialPlayerPosition = playerTransform.position;
            initialPlayerRotation = playerTransform.rotation;
            spawnStored = true;
        }

        ResetToMenu();
    }

    void Update()
    {
        if (!gameStarted || gameEnded)
            return;

        // Timer
        remainingTime -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(remainingTime);

        // Counter
        int fixedCount = CountFixedMachines();
        machineCounterText.text = fixedCount + " / " + machines.Length + " Machines Fixed";

        // WIN
        if (fixedCount == machines.Length)
        {
            EndGame(true);
        }

        // LOSE
        if (remainingTime <= 0)
        {
            EndGame(false);
        }
    }

    // =========================
    // START GAME
    // =========================
    public void StartGame()
    {
        gameStarted = true;
        gameEnded = false;

        remainingTime = gameDuration;
        resultText.text = "";

        // Randomize machines (orange / red)
        foreach (Machine m in machines)
            m.SetRandomState();

        // Hide menu UI
        startButton.SetActive(false);
        restartButton.SetActive(false);
        titleText.SetActive(false);
        conceptText.SetActive(false);
        guideText.SetActive(false);

        // Lock mouse for FPS gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // =========================
    // END GAME
    // =========================
    void EndGame(bool win)
    {
        if (gameEnded) return;

        gameEnded = true;
        gameStarted = false;

        resultText.text = win ? "WIN" : "LOSE";
        restartButton.SetActive(true);

        // Unlock mouse for UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // =========================
    // RESTART GAME
    // =========================
    public void RestartGame()
    {
        if (playerTransform != null)
        {
            // Disable CharacterController if present
            CharacterController cc = playerTransform.GetComponent<CharacterController>();
            if (cc != null)
                cc.enabled = false;

            // Teleport player
            playerTransform.position = initialPlayerPosition;
            playerTransform.rotation = initialPlayerRotation;

            // Re-enable CharacterController
            if (cc != null)
                cc.enabled = true;
        }

        ResetToMenu();
    }

    // =========================
    // RESET TO MENU STATE
    // =========================
    void ResetToMenu()
    {
        gameStarted = false;
        gameEnded = false;

        remainingTime = gameDuration;
        machineCounterText.text = "0 / " + machines.Length + " Machines Fixed";
        timerText.text = "Time: " + Mathf.CeilToInt(gameDuration);
        resultText.text = "";

        // Show menu UI
        startButton.SetActive(true);
        restartButton.SetActive(false);
        titleText.SetActive(true);
        conceptText.SetActive(true);
        guideText.SetActive(true);

        // Unlock mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // =========================
    // UTILITIES
    // =========================
    int CountFixedMachines()
    {
        int count = 0;
        foreach (Machine m in machines)
            if (m.IsFixed())
                count++;
        return count;
    }
}
