using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    public float minDistanceForSwipe = 100f;

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    private bool detectSwipeOnlyAfterRelease = true;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        if (!gameManager.IsPlayerTurn()) return;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerUpPosition = touch.position;
                CheckSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe()
    {
        float deltaX = fingerUpPosition.x - fingerDownPosition.x;
        float deltaY = fingerUpPosition.y - fingerDownPosition.y;

        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (Mathf.Abs(deltaX) > minDistanceForSwipe)
            {
                if (deltaX > 0)
                {
                    // Swipe right
                    transform.Translate(Vector3.right);
                }
                else if (deltaX < 0)
                {
                    // Swipe left
                    transform.Translate(Vector3.left);
                }
            }
        }
        else
        {
            if (Mathf.Abs(deltaY) > minDistanceForSwipe)
            {
                if (deltaY > 0)
                {
                    transform.Translate(Vector3.up);
                }
                else if (deltaY < 0)
                {
                    transform.Translate(Vector3.down);
                }
            }
        }
    }
}
