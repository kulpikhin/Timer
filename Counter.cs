using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMeshPro;

    private int _curentNumber = 0;
    private float _term = 0.5f;
    private bool _isCounterWork;
    private Coroutine _counterCorutine;
    private WaitForSeconds _waitForSecond;

    private void Start()
    {
        _waitForSecond = new WaitForSeconds(_term);
        _textMeshPro.text = Convert.ToString(_curentNumber);
    }

    private void Update()
    {
        Switch();
    }

    private void Switch()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_isCounterWork)
            {
                StopCounter();
            }
            else
            {
                StartCouner();
            }
        }
    }

    private void StartCouner()
    {
        if(_counterCorutine != null)        
            StopCoroutine( _counterCorutine );
        
        _isCounterWork = true;
        _counterCorutine = StartCoroutine(Countdown());
    }

    private void StopCounter()
    {
        if (_counterCorutine != null)
            StopCoroutine(_counterCorutine);

        _isCounterWork = false;
    }

    private void ChangeCount()
    {
        _curentNumber++;
        _textMeshPro.text = Convert.ToString(_curentNumber);
    }

    private IEnumerator Countdown()
    {
        while (_isCounterWork)
        {
            {
                ChangeCount();
            }

            yield return _waitForSecond;
        }
    }    
}
