using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAttica.Model
{
    public class ElementInstrumentToUpload
    {
        public int Id { get; set; }

        public InstrumnetHeader InstrumnetHeader { get; set; }

        public InstrumentNomenclature Nomenclature { get; set; }
        public string XKey { get; set; }
        public HoldInstrument HoldInstrument { get; set; }

        public string ImagePhoneSource { get; set; }
        public bool IsLoaded { get; set; }
        public string UserName { get; set; }



    }
}
