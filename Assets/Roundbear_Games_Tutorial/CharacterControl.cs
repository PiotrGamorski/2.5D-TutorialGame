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
        [SerializeField] private Material _material;

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

        public void ChangeMaterial()
        {
            if (this._material == null)
            {
                Debug.Log("No material");
            }

            Renderer[] arrMaterials = this.gameObject.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in arrMaterials)
            {
                //this.gameObject refers to "SuitedMan"
                if (r.gameObject != this.gameObject) 
                {
                    r.material = this._material;
                }
            }
        }
    }
}
