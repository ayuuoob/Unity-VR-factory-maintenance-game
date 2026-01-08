using UnityEngine;

public enum MachineState
{
    Working,   // Green
    Warning,   // Orange
    Error      // Red
}

public class Machine : MonoBehaviour
{
    public MachineState currentState;
    public Light statusLight;

    private int fixClicks = 0;

    void Start()
    {
        SetRandomState();
    }

    public void SetRandomState()
    {
        currentState = (MachineState)Random.Range(1, 3);
        fixClicks = 0;
        UpdateLight();
    }

    public void OnClick()
    {
        if (currentState == MachineState.Warning)
        {
            // 1 click to fix
            currentState = MachineState.Working;
            UpdateLight();
        }
        else if (currentState == MachineState.Error)
        {
            // 2 clicks to fix
            fixClicks++;

            if (fixClicks >= 2)
            {
                currentState = MachineState.Working;
                UpdateLight();
            }
        }
    }

    void UpdateLight()
    {
        switch (currentState)
        {
            case MachineState.Working:
                statusLight.color = Color.green;
                break;

            case MachineState.Warning:
                statusLight.color = new Color(1f, 0.5f, 0f);
                break;

            case MachineState.Error:
                statusLight.color = Color.red;
                break;
        }
    }

    public bool IsFixed()
    {
        return currentState == MachineState.Working;
    }
}
