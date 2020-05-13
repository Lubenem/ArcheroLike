using UnityEngine;

public class Mover : MonoBehaviour
{
    private Vector3 keyboardVel;
    private Vector3 joystickVel;
    [HideInInspector] public Vector3 velocity;
    public Joystick joystick;
    public float speed = 3;

    private void Update()
    {
        keyboardVel = new Vector3(Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
        joystickVel = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        velocity = keyboardVel.normalized + joystickVel;
        GetComponent<Rigidbody>().AddForce(velocity * speed, ForceMode.Impulse);
    }
}