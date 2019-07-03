
using UnityEngine;

public class PlayerController_TAMA : MonoBehaviour
{
    Vector2 mousePos1;
    Vector2 mousePos2;
    Vector2 movePos;
    Unit unit;
   
    void Start()
    {
        unit = GetComponent<Unit>();
        this.mousePos1 = Input.mousePosition;
    }
    
    void Update()
    {
        MoveSwipe();
    }
    
    void MoveSwipe()
    {
        this.mousePos2 = Input.mousePosition;

        float x_swipeLength = mousePos2.x - this.mousePos1.x;
        float y_swipeLength = mousePos2.y - this.mousePos1.y;

        this.movePos = mousePos2 - mousePos1;
        unit.Move(movePos);
        mousePos1 = mousePos2;
    }
}