using System.Collections;
using UnityEngine;
using Objects.Hauler;

public class HaulerInputHandler : MonoBehaviour
{
    public float inputDelaySeconds = 0.025f;
    public float secondsBetweenMovement = 0.3f;
    public float secondsBetweenActions = 0.5f;
    public bool canMove = false;

    private HaulerPlayerScript _haulerPlayerScript;
    private float _timer;
    private float _lastMovementTime;
    private float _lastActionTime;
    private bool _releasedKey = true;

    public void Init(HaulerPlayerScript haulerPlayerScript)
    {
        _haulerPlayerScript = haulerPlayerScript;
    }

    void Start()
    {
        StartCoroutine(HandleInputs());
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }

    private bool CanPerformAction => !_haulerPlayerScript.IsLoading && _timer - _lastActionTime >= secondsBetweenActions;
    private bool CanMove => (canMove || !canMove && _releasedKey) && _timer - _lastMovementTime >= secondsBetweenMovement;

    private IEnumerator HandleInputs()
    {
        while (true)
        {
            if (GameState.Current.IsGameInProgres)
            {
                HandleMovement();
                HandleActions();
            }

            yield return new WaitForSeconds(inputDelaySeconds);
        }
    }

    private void HandleActions()
    {
        if (Input.GetButton("Jump") && CanPerformAction)
        {
            _lastActionTime = _timer;
            _haulerPlayerScript.OnInput(HaulerCommands.PerformAction);
        }
    }

    private void HandleMovement()
    {
        var verticalAxis = Input.GetAxis("Vertical");
        if (!_releasedKey && verticalAxis == 0)
            _releasedKey = true;
        else if (verticalAxis != 0 && CanMove)
            Move(verticalAxis);
    }

    private void Move(float verticalAxis)
    {
        _lastMovementTime = _timer;
        _releasedKey = false;
        var cmd = verticalAxis > 0 ? HaulerCommands.MoveUp : HaulerCommands.MoveDown;
        _haulerPlayerScript.OnInput(cmd);
    }
}
