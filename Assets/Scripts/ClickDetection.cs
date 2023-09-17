using UnityEngine;
using UnityEngine.Events;

public class ClickDetection : MonoBehaviour
{
    public UnityEvent singleClickEvent;

    void Update()
    {

        // 在手机上检测触摸
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 当用户点击屏幕时触发事件
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        // 碰撞到了当前物体，执行单击事件
                        HandleSingleClick();
                    }
                }
            }
        }
    }

    void HandleSingleClick()
    {
        // 执行单击事件的代码
        Debug.Log("单击");
        singleClickEvent?.Invoke();
    }
}