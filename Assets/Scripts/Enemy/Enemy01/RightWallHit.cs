using UnityEngine;

public class RightWallHit : MonoBehaviour
{
    private bool _rightHit;
    public bool RightHit => _rightHit;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        _rightHit = true;
    }
    public void RightHitDisable()
    {
        _rightHit = false;
    }
}
