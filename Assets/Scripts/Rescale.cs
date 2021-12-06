using UnityEngine;

namespace DefaultNamespace
{
    public class Rescale : Command
    {
        private int Width;
        private int Height;
        
        public Rescale(Transform cubeAffected, Color previousColor, int width, int height) : base(cubeAffected, previousColor)
        {
            Height = height;
            Width = width;
        }

        public override void Do()
        {
            throw new System.NotImplementedException();
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}