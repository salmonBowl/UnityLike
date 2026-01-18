using UnityLike.UI;

namespace UnityLike
{
    public interface ITitleSceneApplicationFactory
    {
        IUnityIconEntity ConnectUnityIconEntity(UnityIcon unityIcon);
        ILoadWindowEntity ConnectLoadWindowEntity(LoadWindow loadWindow)
    }
}
