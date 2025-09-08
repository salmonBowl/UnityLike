using System.Collections.Generic;
using UnityEngine;

using UnityLike.Entities.Symbol;

namespace UnityLike.UseCases.UnityComponent
{
    public class SyncUnityComponent
    {
        private readonly List<Variable> variables = new();

        private readonly Transform transform;
        private readonly Rigidbody rigidbody;
        private readonly GameObject gameObject;

        private readonly Variable transformVariable;
        private readonly Variable rigidbodyVariable;
        private readonly Variable gameObjectVariable;

        public SyncUnityComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
            transform = gameObject.GetComponent<Transform>();
            rigidbody = gameObject.GetComponent<Rigidbody>();

            transformVariable = new("transform", TransformClass.Single)
            {
                Value = new TransformInstance(transform)
            };
            variables.Add(transformVariable);
            rigidbodyVariable = new("rigidbody", RigidbodyClass.Single)
            {
                Value = new RigidbodyInstance(rigidbody)
            };
            variables.Add(rigidbodyVariable);
            gameObjectVariable = new("gameObject", GameObjectClass.Single)
            {
                Value = new GameObjectInstance(transformVariable, rigidbodyVariable)
            };
            variables.Add(gameObjectVariable);

            // --- ëºèâä˙ïœêî ---

            Variable space = new("Space", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.Space)
            };
            Variable rightArrow = new("RightArrow", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.RightArrow)
            };
            Variable leftArrow = new("LeftArrow", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.LeftArrow)
            };
            Variable upArrow = new("UpArrow", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.UpArrow)
            };
            Variable downArrow = new("DownArrow", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.DownArrow)
            };
            Variable keyW = new("W", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.W)
            };
            Variable keyA = new("A", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.A)
            };
            Variable keyS = new("S", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.S)
            };
            Variable keyD = new("D", KeyCodeClass.Single)
            {
                Value = new KeyCodeInstance(KeyCode.D)
            };
            variables.Add(space);
            variables.Add(rightArrow);
            variables.Add(leftArrow);
            variables.Add(upArrow);
            variables.Add(downArrow);
            variables.Add(keyW);
            variables.Add(keyA);
            variables.Add(keyS);
            variables.Add(keyD);
        }

        public List<Variable> GetVariables()
        {
            return variables;
        }

        public void RenderUnityComponent()
        {
            TransformInstance vTransform = (TransformInstance)transformVariable.Value;
            transform.position = ((Vector3Instance)vTransform.GetMember("position")).AsVector3();
            transform.eulerAngles = ((Vector3Instance)vTransform.GetMember("eulerAngles")).AsVector3();
            transform.localScale = ((Vector3Instance)vTransform.GetMember("localScale")).AsVector3();
            RigidbodyInstance vRigidbody = (RigidbodyInstance)rigidbodyVariable.Value;
            rigidbody.mass = ((FloatInstance)vRigidbody.GetMember("mass")).AsFloat();
            rigidbody.useGravity = ((BoolInstance)vRigidbody.GetMember("useGravity")).AsBool();
            rigidbody.isKinematic = ((BoolInstance)vRigidbody.GetMember("isKinematic")).AsBool();
            if (!rigidbody.isKinematic) rigidbody.linearVelocity = ((Vector3Instance)vRigidbody.GetMember("velocity")).AsVector3();
            GameObjectInstance vGameObject = (GameObjectInstance)gameObjectVariable.Value;
            gameObject.SetActive(((BoolInstance)vGameObject.GetMember("activeSelf")).AsBool());
        }
    }
}
