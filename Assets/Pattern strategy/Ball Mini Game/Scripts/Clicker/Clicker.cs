using UnityEngine;

public class Clicker : MonoBehaviour
{
    private IClickable _сlickableObject;
    private void Update()
    {
        _сlickableObject = GetPointingMouse();

        if (_сlickableObject != null)
            if (Input.GetKey(KeyCode.Mouse0))
                _сlickableObject.Clicked();
    }
    private IClickable GetPointingMouse()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, 1000))
            return hit.collider.GetComponent<IClickable>();

        return null;
    }
}

