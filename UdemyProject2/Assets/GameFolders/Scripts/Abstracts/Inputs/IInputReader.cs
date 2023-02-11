using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProject2.Abstracts.Inputs
{
    public interface IInputReader 
    {
       float Horizontal { get; }
       bool isJump { get; }
    }
}

