using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    public abstract void Animating(float h, float v);

    public abstract void Move(float h, float v);
}
