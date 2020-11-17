using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public enum TransitionParameter
    {
        Move,
    }

    public class CharacterControl : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if (VirtualInputManager.Instance.MoveLeft && VirtualInputManager.Instance.MoveRight)
            {
                _animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!(VirtualInputManager.Instance.MoveLeft && VirtualInputManager.Instance.MoveRight))
            {
                _animator.SetBool(TransitionParameter.Move.ToString(), false);
            }

            if (VirtualInputManager.Instance.MoveRight)
            {
                this.gameObject.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                _animator.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                this.gameObject.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                _animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
        }
    }
}
