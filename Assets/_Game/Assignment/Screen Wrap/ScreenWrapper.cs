using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    public void UpdatePosition(Transform trans)
    {
        Vector3 viewPortPos = Camera.main.WorldToViewportPoint(trans.position);
        Vector3 newPosition = trans.position;

       if (viewPortPos.x > 1 || viewPortPos.x < 0)
       {
           Debug.Log(trans.name + " X position was outside the screen");
           newPosition.x *= -1;
       }

       if (viewPortPos.y > 1 || viewPortPos.y < 0)
       {
           Debug.Log(trans.name + " Y position was outside the screen");
           newPosition.y *= -1;
       }
      
        trans.position = newPosition;
    }
}
