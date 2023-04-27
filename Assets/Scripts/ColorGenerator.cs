using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorGenerator : MonoBehaviour
{
    [SerializeField] private float recoloringDuration;
    [SerializeField] private float brakeTime;

    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
    private float _recoloringTime;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }


    void Update()
    {
        _recoloringTime += Time.deltaTime;
        var progress = _recoloringTime / recoloringDuration;

        var currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;

        if (_recoloringTime >= recoloringDuration)
        {
            _recoloringTime = 0-brakeTime;
            GenerateNextColor();
        }
    }
}
