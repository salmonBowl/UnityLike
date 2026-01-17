using UnityEngine;
using UnityEngine.UI;

namespace UnityLike.Application
{
    public class TitleSceneApplicationFactory : ApplicationFactoryBase, ITitleSceneApplicationFactory
    {
        [SerializeField] UnityIconBehaviour unityIcon;
        [SerializeField] ButtonBehaviour newGameButton;
        [SerializeField] ButtonBehaviour loadGameButton;

        public IUnityIconEntity ConnectUnityIconEntity(UnityIcon unityIcon)
        {
            return this.unityIcon.Initialize(unityIcon);
        }
        public IButtonEntity ConnectNewGameButton(out IButtonInput buttonInput)
        {
            buttonInput = GetClass<ButtonInput>(newGameButton.gameObject);

            return newGameButton.Initialize();
        }
    }
}
