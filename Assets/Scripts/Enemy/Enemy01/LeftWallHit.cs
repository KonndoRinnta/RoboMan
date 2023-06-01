using UnityEngine;

public class LeftWallHit : MonoBehaviour
{
    private bool _leftHit;
    public bool LeftHit => _leftHit;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        _leftHit = true;
    }
    public void LeftHitDisable()
    {
        _leftHit = false;
    }
}
