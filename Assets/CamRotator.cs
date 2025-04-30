using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CamRotator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Button _upArrow, _downArrow, _leftArrow, _rightArrow;
    [SerializeField] private float _speedRotation = 1;

    private Coroutine _currentRoutine;

    private void Awake()
    {
        _upArrow.onClick.AddListener(() => StartRotation(Vector3.right * 90));
        _downArrow.onClick.AddListener(() => StartRotation(Vector3.left * 90));
        _leftArrow.onClick.AddListener(() => StartRotation(Vector3.up * 90));
        _rightArrow.onClick.AddListener(() => StartRotation(Vector3.down * 90));
    }

    private void StartRotation(Vector3 eulerDelta)
    {
        if (_currentRoutine != null) StopCoroutine(_currentRoutine);

        Quaternion targetRotation = _player.rotation * Quaternion.Euler(eulerDelta);
        _currentRoutine = StartCoroutine(RotateTo(targetRotation));
    }

    private IEnumerator RotateTo(Quaternion targetRotation)
    {
        Quaternion startRotation = _player.rotation;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * _speedRotation;
            _player.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        _player.rotation = targetRotation;
        _currentRoutine = null;
    }
}