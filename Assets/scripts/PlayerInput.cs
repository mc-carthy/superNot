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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transInput = new Vector2(h, v).normalized;

        // Set the target time factor based on an interpolated value using the min/max timescale with the magnitude of the player input
        
        TimeManager.TargetTimeFactor = (transInput.magnitude > 0.5f) ? 0.05f : 1f;
    }

    private void FixedUpdate ()
    {
        pMove.Move(transInput);
    }

}
