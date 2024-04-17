using System;

namespace PW.Model
{
    public abstract class ModelAbstractApi
    {
        public static ModelAbstractApi CreateApi()
        {
            Model model = new Model();
            return model;
        }

        public abstract void Start();
    }
}
