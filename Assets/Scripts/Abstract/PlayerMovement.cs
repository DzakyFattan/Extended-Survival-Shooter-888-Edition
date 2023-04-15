using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.
    public abstract void Animating(float h, float v);

    public abstract void Move(float h, float v);
}
