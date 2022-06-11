using System.Collections.Generic;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        private string material;
        private int capacity;

        public Net(string material, int capacity)
        {
            this.material = material;
            this.capacity = capacity;
        }
    }
}
