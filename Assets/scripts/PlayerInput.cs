using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerMovement pMove;
    private PlayerWeapon pWeapon;
	private Vector2 transInput;
    private Vector3 mouseInput;

    private void Awake()
    {
        pMove = GetComponent<PlayerMovement>();
        pWeapon = GetComponent<PlayerWeapon>();
        Cursor.visible = false;
    }

    private void Update()
    {
        GetTransInput();
        GetMouseInput();
        GetWeaponInput();
        SetTimeScale();
        pMove.Look(mouseInput);
    }

    private void FixedUpdate()
    {
        pMove.Move(transInput);
    }

    private void GetTransInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transInput = new Vector2(h, v).normalized;
    }

    private void GetMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mouseInput = new Vector2(mouseX, mouseY);
    }

    private void GetWeaponInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            pWeapon.Fire();
        }
    }

    private void SetTimeScale()
    {
        // Set the target time factor based on an interpolated value using the min/max timescale with the magnitude of the player input
        float timeScaleRange = TimeManager.TimeFactorDelta;
        TimeManager.TargetTimeFactor = (transInput.magnitude > 0.5f) ? TimeManager.MaxTimeScale : TimeManager.MinTimeScale;
        TimeManager.TargetTimeFactor += mouseInput.magnitude;
    }

}
