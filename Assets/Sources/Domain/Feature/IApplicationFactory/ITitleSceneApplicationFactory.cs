using UnityLike.UI;

namespace UnityLike
{
    public interface ITitleSceneApplicationFactory
    {
        IUnityIconEntity ConnectUnityIconEntity(UnityIcon unityIcon);
        ICreateWindowEntity ConnectCreateWindowEntity(CreateWindow createWindow);
        ILoadWindowEntity ConnectLoadWindowEntity(LoadWindow loadWindow);
        IButtonInput GetCreateWindowButtonInput();
        IButtonInput GetLoadWindowButtonInput();
    }
}
