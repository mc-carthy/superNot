using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float moveSpeed = 5f;

	public void Move(Vector2 transInput)
    {
        Vector3 transV3 = new Vector3(transInput.x, 0, transInput.y);
        transform.Translate (transV3 * moveSpeed * Time.fixedDeltaTime);
    }

}
