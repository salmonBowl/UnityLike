using UnityEngine;

namespace UnityLike.Application
{
    public class TitleSceneMain : Main
    {
        [SerializeField] TitleSceneApplicationFactory application;

        // C#ƒNƒ‰ƒX‚Ì‰Šú‰»‚ğ‚µ‚Ü‚·
        protected override void Awake()
        {
            currentScene.Is(new TitleScene(application));
        }
    }
}
