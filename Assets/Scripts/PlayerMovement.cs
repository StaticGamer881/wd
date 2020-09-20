using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool start;
    [SerializeField] private Camera _camera;

    void Start()
    {
        start = true;
        _camera.fieldOfView = 0f;
    }

    void Update()
    {
        if (start)
        {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, 60, Time.deltaTime * 0.5f);
            StartCoroutine(startRoutine(5));
        }
    }

    private IEnumerator startRoutine(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _camera.fieldOfView = 60f;
        start = false;
    }
}
