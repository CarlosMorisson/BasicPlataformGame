using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour, IGunController
{
    private GunInput _gunInput;
    #region Interface
    public bool GunInput => _gunInput.RightMouseDown;
    #endregion
    private GameObject _player;
    private Transform _playerHand;
    private Transform _playerGun;
    [SerializeField]
    private SoGun _stats;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHand = GameObject.FindGameObjectWithTag("Hand").transform;
        _playerGun = GameObject.FindGameObjectWithTag("Hand").GetComponentInChildren<Transform>();
        _rotationSpeed = _stats.GunSpeedRotation;
    }

    // Update is called once per frame
    void Update()
    {
        GatherInput();
        AroundThePlayer();
    }
    #region GetInputs
    private void GatherInput()
    {
        _gunInput = new GunInput
        {
            RightMouseDown = Input.GetKeyDown(KeyCode.Mouse1),
            LeftMouseDown = Input.GetKeyDown(KeyCode.Mouse0)
        };
    }
    #endregion

    #region MoveGunAroundThePlayer
    private float _rotationSpeed;
    private bool _isFacingRight=true;
    private void AroundThePlayer()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - _player.transform.position;
        direction.Normalize();
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        _playerHand.transform.rotation = Quaternion.Lerp(_playerHand.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        if (direction.x > 0 && !_isFacingRight || direction.x < 0 && _isFacingRight)
            FlipGun();
    }
    private void FlipGun()
    {
        Vector3 currentScale = _playerGun.gameObject.transform.localScale;
        currentScale.y *= -1;
        _playerGun.gameObject.transform.localScale = currentScale;

        _isFacingRight = !_isFacingRight;
    }
    #endregion
}
public interface IGunController
{
    public bool GunInput { get; }
}
public struct GunInput
{
    public bool RightMouseDown;
    public bool LeftMouseDown;
}