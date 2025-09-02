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

        public SyncUnityComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
            transform = gameObject.GetComponent<Transform>();

            GenerateInstances();
        }

        public List<Variable> GetVariables()
        {
            return variables;
        }

        private void GenerateInstances()
        {
            /*
            Variable transformVariable = new("transform", TransformClass.Single)
            {
                Value = new TransformInstance(transform)
            };
            variables.Add(transformVariable);

            Variable gameObjectVariable = new("gameObject", GameObjectClass.Single)
            {
                Value = new GameObjectClass(transformVariable)
            };
            variables.Add(gameObjectVariable);
            */
        }
        public void RenderUnityComponent()
        {

        }
    }
}
