using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAttica.Model
{
    public class InventoryObject
    {
         
        public int Id { get; set; }

        public string Name { get; set; }


        public List<HoldInstrument> HoldInstruments { get; set; }

        public List<HoldMaterial> HoldMaterials { get; set; }

    }
}
