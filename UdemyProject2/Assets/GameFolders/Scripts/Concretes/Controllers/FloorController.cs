using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class FloorController : MonoBehaviour
    {
        Material _material;
        [Range(0.2f, 2f)]
        [SerializeField] float _moveSpeed=5f;
       
        void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        void Update()
        {
            _material.mainTextureOffset += Vector2.down * Time.deltaTime * _moveSpeed;
        }
    }
}

