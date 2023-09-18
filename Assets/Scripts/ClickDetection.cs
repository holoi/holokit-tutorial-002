using UnityEngine;
using UnityEngine.Events;

public class ClickDetection : MonoBehaviour
{
    public UnityEvent singleClickEvent;

    void Update()
    {

        // Detect Screen Taps
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Trigger when user tap on screen
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        // Hit current object and excute:
                        HandleSingleClick();
                    }
                }
            }
        }
    }

    void HandleSingleClick()
    {
        singleClickEvent?.Invoke();
    }
}