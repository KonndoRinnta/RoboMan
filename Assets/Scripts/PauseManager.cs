using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : SingletonMonoBehaviour<PauseManager>
{
    #region Member Variables

    private bool _isPausing = false;
    public bool IsPausing => _isPausing;

    #endregion

    #region Events

    public event Action OnPause;
    public event Action OnResume;

    #endregion

    #region Public Methods

    public void PauseUpdate(bool inputFlag)
    {
        if (inputFlag)
        {
            if (!_isPausing)
            {
                _isPausing = true;
                OnPause?.Invoke();
            }
            else
            {
                _isPausing = false;
                OnResume?.Invoke();
            }
        }
    }

    #endregion
}
