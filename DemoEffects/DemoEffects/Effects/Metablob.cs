using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEffects.Effects
{
    public class MetaBlobModel
    {
        public int scaleX;
        public int scaleY;
        public double speed;
        public int x;
        public int y;
    }


    public class Metablob : BaseEffect, IEffect
    {
        private Random random = new Random();
        private MetaBlobModel[] blobs = new MetaBlobModel[5];
        private const int BlobCount = 5;
        double shift = 0;
        public Metablob(int w, int h) : base(w, h)
        {
            InitBlobs();
        }

        private void InitBlobs()
        {
            for(int i = 0; i < BlobCount; i++)
            {
                blobs[i] =  new MetaBlobModel()
                {
                    scaleX = random.Next(10, 100),
                    scaleY = random.Next(10, 100),
                    speed = random.Next(10, 100) * Math.PI * 32 - Math.PI * 16,
                    x = 0,
                    y = 0
                };
            }
        }

        public void DoEffect()
        {
            float time = Program.GetTime() / 50000;
            
            foreach(var blob in blobs.ToList())
            {

                MetaBlobModel newB = blobs.Where(x => x == blob).FirstOrDefault();

                newB.x = Convert.ToInt32(Math.Sin((time + shift) * Math.PI * blob.speed) * base.EffectWidth * blob.scaleX + base.EffectWidth / 2);
                newB.y = Convert.ToInt32(Math.Cos((time + shift) * Math.PI * blob.speed) * base.EffectHeight * blob.scaleY + base.EffectHeight / 2);
                shift += 0.5;
            }

            for(int y = 0; y < base.EffectHeight; y++)
            {
                for(int x = 0; x < base.EffectWidth; x++)
                {
                    double dSq = 1;
                    foreach(var blob in blobs.ToList())
                    {
                        var xSq = (x - blob.x) * (x - blob.x);
                        var ySq = (y - blob.y) * (y - blob.y);
                        dSq *= Math.Sqrt(xSq + ySq);
                    }
                    var pix = Convert.ToInt32(Math.Max(Math.Min(Math.Floor(1024 - (dSq / 3e8)), 255), 0));
                    base.currentFrame.SetPixel((uint)x, (uint)y, GetColor(pix));
                }
            }


        }
    }
}
