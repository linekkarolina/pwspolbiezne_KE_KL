using System;
using PW.Logika;

namespace PW.Model
{
    public class Model : ModelAbstractApi
    {
        public override void Start()
        {
            Random random = new Random();
            Ball newBall = new Ball(random.Next(100, 400 - 100), random.Next(100, 400 - 100)) { Diameter = 20 };
            Balls.Add(newBall);
        }
    }


}
