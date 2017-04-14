using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerMovement pMove;
	private Vector2 transInput;

    private void Awake ()
    {
        pMove = GetComponent<PlayerMovement>();
    }

    private void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transInput = new Vector2 (h, v).normalized;
    }

    private void FixedUpdate ()
    {
        pMove.Move(transInput);
    }

}
