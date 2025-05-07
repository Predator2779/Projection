using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CamRotator : MonoBehaviour
{
    [SerializeField] private Transform _player, _view;
    [SerializeField] private Button _upArrow, _downArrow, _leftArrow, _rightArrow;
    [SerializeField] private float _speedRotation = 1;

    private Coroutine _currentRoutine;
    private const int _angle = 90;
    
    private void Awake()
    {
        _upArrow.onClick.AddListener(() => StartRotation(_view, Vector3.right * _angle));
        _downArrow.onClick.AddListener(() => StartRotation(_view, Vector3.left * _angle));
        _leftArrow.onClick.AddListener(() => StartRotation(_player, Vector3.up * _angle));
        _rightArrow.onClick.AddListener(() => StartRotation(_player, Vector3.down * _angle));
    }

    private void StartRotation(Transform obj, Vector3 eulerDelta)
    {
        if (_currentRoutine != null) StopCoroutine(_currentRoutine);

        Quaternion targetRotation = obj.rotation * Quaternion.Euler(eulerDelta);
        _currentRoutine = StartCoroutine(RotateTo(obj, targetRotation));
    }

    private IEnumerator RotateTo(Transform obj, Quaternion targetRotation)
    {
        Quaternion startRotation = obj.rotation;
        float t = 0;
        EnabledButtons(false);
        
        while (t < 1)
        {
            t += Time.deltaTime * _speedRotation;
            obj.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        obj.rotation = targetRotation;
        _currentRoutine = null;
        EnabledButtons(true);
    }

    private void EnabledButtons(bool value)
    {
        _upArrow.interactable = value;
        _downArrow.interactable = value;
        _leftArrow.interactable = value;
        _rightArrow.interactable = value;
    }
}