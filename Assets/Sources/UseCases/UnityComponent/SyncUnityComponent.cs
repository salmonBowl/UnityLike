using System.Collections.Generic;
using UnityEngine;

using UnityLike.Entities.Symbol;

namespace UnityLike.UseCases.UnityComponent
{
    public class SyncUnityComponent
    {
        private readonly List<Variable> variables = new();

        private readonly GameObject gameObject;
        private readonly Transform transform;

        private readonly Variable transformVariable;

        public SyncUnityComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
            transform = gameObject.GetComponent<Transform>();

            transformVariable = new("transform", TransformClass.Single)
            {
                Value = new TransformInstance(transform)
            };
            variables.Add(transformVariable);
        }

        public List<Variable> GetVariables()
        {
            return variables;
        }

        private void GenerateInstances()
        {
            Variable transformVariable = new("transform", TransformClass.Single)
            {
                Value = new TransformInstance(transform)
            };
            variables.Add(transformVariable);

            /*
            Variable gameObjectVariable = new("gameObject", GameObjectClass.Single)
            {
                Value = new GameObjectClass(transformVariable)
            };
            variables.Add(gameObjectVariable);
            */
        }
        public void RenderUnityComponent()
        {
            TransformInstance vTransform = (TransformInstance)transformVariable.Value;
            transform.position = ((Vector3Instance)vTransform.GetMember("position")).AsVector3();
            transform.eulerAngles = ((Vector3Instance)vTransform.GetMember("eulerAngles")).AsVector3();
            transform.localScale = ((Vector3Instance)vTransform.GetMember("localScale")).AsVector3();
            Debug.Log(transform.position);
        }
    }
}
