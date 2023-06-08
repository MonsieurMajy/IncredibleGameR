using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private IState currentState;
    public SleepState sleepState = new SleepState();
    public InputState inputState = new InputState();
    public AwakeState awakeState = new AwakeState();

    private void Start()
    {
        ChangeState(inputState);
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
    public bool isInput() {
        return currentState == inputState;
    }
    public bool isAwake() {
        return currentState == awakeState;
    }

    public void changeStateToSleep() {
        ChangeState(sleepState);
    }
    public void changeStateToInput() {
        ChangeState(inputState);
    }
    public void changeStateToAwake() {
        ChangeState(awakeState);
    }
}
public interface IState
{
    public void OnEnter(StateController controller);
    public void UpdateState(StateController controller);
    public void OnExit(StateController controller);
}