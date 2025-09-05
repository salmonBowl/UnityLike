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
            rigidbody.linearVelocity = ((Vector3Instance)vRigidbody.GetMember("velocity")).AsVector3();
            GameObjectInstance vGameObject = (GameObjectInstance)gameObjectVariable.Value;
            gameObject.SetActive(((BoolInstance)vGameObject.GetMember("activeSelf")).AsBool());
        }
    }
}
