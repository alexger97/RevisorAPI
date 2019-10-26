using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAttica.Model
{
    public class TransactInstrument
    {
        public int Id { get; set; }
        public ElementInstrumentToUpload ElementInstrumentToUpload { get; set; }

        public byte[] Image { get; set; }
    }
}
