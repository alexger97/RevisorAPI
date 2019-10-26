using APIAttica.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAttica.Context
{
    public class ServerContext : DbContext
    {

        public ServerContext(DbContextOptions<ServerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<InstrumentNomenclature> InstrumentNomenclatures { get; set; }

        public DbSet<MaterialNomenclature> MaterialNomenclatures { get; set; }
        public DbSet<InstrumnetHeader> InstrumnetHeader { get; set; }

        public DbSet<InventoryObject> InventoryObjectsMain { get; set; }

        public DbSet<TransactInstrument> TransactInstruments { get; set; }
        public DbSet<HoldInstrument> HoldsInstrument { get; set; }
        public DbSet<HoldMaterial> HoldsMaterial { get; set; }
        public DbSet<ElementMaterialToUpload> ElementMaterialToUploads { get; set; }
        public DbSet<User> Users { get; set; }




    }
}
