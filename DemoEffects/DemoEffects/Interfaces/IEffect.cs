using DemoEffects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEffects
{
    interface IEffect
    {
        void DoEffect();
        List<PixelPoint> GetPixels();

    }
}
