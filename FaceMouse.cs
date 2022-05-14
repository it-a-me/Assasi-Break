using System.Collections;
using UnityEngine;
 
public class FaceMouse : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale > 0)
        {

            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2((mousePosition.x - transform.position.x), (mousePosition.y - transform.position.y));
            if (transform.lossyScale.x < 0)
            {
                transform.right = direction;
            }
            else
            {
                transform.right = -direction;
            }
        }
    }
}

      
