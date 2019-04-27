using SFML.Graphics;

namespace DemoEffects
{
    interface IEffect
    {
        void DoEffect();
        Sprite GetCurrentFrame();
        void SetPosition(int x, int y);

    }
}
