using System.Collections.Generic;

using UnityLike.Entities.Symbol;
using UnityLike.UseCases.UnityComponent;

namespace UnityLike.InterfaceAdapters.CodeManagement
{
    public class InitalMemberManager
    {
        public SyncUnityComponent UnityComponent { get; }
        private List<Variable> initalVariables;

        public InitalMemberManager(UnityEngine.GameObject gameObject)
        {
            UnityComponent = new SyncUnityComponent(gameObject);
            initalVariables = UnityComponent.GetVariables();
        }

        public void InitializeList()
        {
            initalVariables = UnityComponent.GetVariables();
        }
        public void SetList(List<Variable> variables)
        {
            initalVariables = variables;
        }
        public List<Variable> GetList()
        {
            return initalVariables;
        }
    }
}
