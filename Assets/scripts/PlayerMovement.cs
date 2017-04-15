using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Transform head;

    private float moveSpeed = 5f;
    private float lookSpeed = 5f;

    private float maxYLook = 90f;
    private float minYLook = -90f;

	public void Move(Vector2 transInput)
    {
        Vector3 transV3 = new Vector3(transInput.x, 0, transInput.y);
        transform.Translate (transV3 * moveSpeed * Time.fixedDeltaTime);
    }

    public void Look(Vector2 mouseInput)
    {
        mouseInput *= lookSpeed;
        transform.localRotation = Quaternion.Euler(0, mouseInput.x, 0) * transform.localRotation;
        head.transform.localRotation = Quaternion.Euler(-mouseInput.y, 0, 0) * head.transform.localRotation;
    }

}
