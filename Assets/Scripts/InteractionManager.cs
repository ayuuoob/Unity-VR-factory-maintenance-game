using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Machine selectedMachine;

    void Update()
    {
        // Sélection de la machine par clic
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                selectedMachine = hit.collider.GetComponentInParent<Machine>();
            }
        }

        // Action clavier
        if (selectedMachine != null)
        {
            // A = Restart (orange)
            if (Input.GetKeyDown(KeyCode.A))
            {
                selectedMachine.OnClick(); 
            }

            // E = Repair (rouge)
            if (Input.GetKeyDown(KeyCode.E))
            {
                selectedMachine.OnClick();
            }
        }
    }
}
