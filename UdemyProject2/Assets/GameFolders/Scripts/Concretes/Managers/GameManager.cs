using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Utilities;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class GameManager : SingletonBehaviorObject<GameManager>
    {
        private void Awake()
        {
            SingletonThisObject(this);           
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
        }
    }
}

