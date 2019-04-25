using SFML.Graphics;

namespace DemoEffects
{
    interface IEffect
    {
        void DoEffect();
        Image GetPixels();

    }
}
