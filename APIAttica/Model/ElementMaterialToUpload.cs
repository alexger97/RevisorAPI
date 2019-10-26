using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAttica.Model
{
    public class ElementMaterialToUpload
    {
        public int Id { get; set; }
        public HoldMaterial HoldMaterial { get; set; }
        public MaterialNomenclature MaterialNomenclature { get; set; }

        public string Name { get; set; }
        public string Units { get; set; }

        public double Count { get; set; }
        public bool IsLoaded { get; set; }

        public string UserName { get; set; }
    }
}
