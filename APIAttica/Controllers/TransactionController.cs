using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAttica.Context;
using APIAttica.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAttica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ServerContext _context;

        public TransactionController(ServerContext context)
        {
            _context = context;
        }


        #region GetData


        [HttpGet("GetInstruments/{id1}")]
        public List<ElementInstrumentToUpload> GetElements(int id1)
        {

            try
            {
                var t = _context.TransactInstruments.Select(x => x.ElementInstrumentToUpload).Where(y => y.HoldInstrument.Id == id1).Include(u => u.HoldInstrument)
                    .Include(y => y.InstrumnetHeader).ThenInclude(x => x.Nomenclature)
                    .Include(o => o.Nomenclature);
                var tt = t.ToList();
                return tt;
            }
            catch (Exception x)
            {
                return null;
            }

        }

        [HttpGet("GetMaterials/{id1}")]
        public List<ElementMaterialToUpload> GetMaterials(int id1)
        {

            try
            {
                var t = _context.ElementMaterialToUploads.Include(z => z.HoldMaterial).Include(y => y.MaterialNomenclature).Where(x => x.HoldMaterial.Id == id1).ToList();


                return t;
            }
            catch (Exception x)
            {
                return null;
            }

        }




        [HttpGet("GetAllMaterialNomenclature")]
        public List<MaterialNomenclature> GetAllMaterialNomenclature()
        {
            if (_context.MaterialNomenclatures != null) return _context.MaterialNomenclatures.ToList();

            return new List<MaterialNomenclature>();
        }



        [HttpGet("GetAllInstrumentNomenclature")]
        public List<InstrumentNomenclature> GetAllInstrumentNomenclature()
        {
            if (_context.InstrumentNomenclatures != null) return _context.InstrumentNomenclatures.ToList();

            return new List<InstrumentNomenclature>();
        }

        [HttpGet("GetAllInstrumentHeader")]
        public List<InstrumnetHeader> GetAllInstrumentHeader()
        {
            if (_context.InstrumnetHeader != null) return _context.InstrumnetHeader.Include(x => x.Nomenclature).ToList();

            return new List<InstrumnetHeader>();

        }
        #endregion


        [HttpPost("PostElementInstrumnetToUpload")]
        public ActionResult PostElementInstrumnetToUpload([FromBody]  TransactInstrument transactInstrument)
        {
            try
            {
                if (transactInstrument.ElementInstrumentToUpload.InstrumnetHeader != null)
                {
                    _context.TransactInstruments.Add(new TransactInstrument()
                    {
                        ElementInstrumentToUpload = new ElementInstrumentToUpload()
                        {
                            HoldInstrument = _context.HoldsInstrument.Find(transactInstrument.ElementInstrumentToUpload.HoldInstrument.Id),
                            InstrumnetHeader = _context.InstrumnetHeader.Find(transactInstrument.ElementInstrumentToUpload.InstrumnetHeader.Id),

                        },
                        Image = transactInstrument.Image
                    }); ;
                }
                else
                {
                    _context.TransactInstruments.Add(new TransactInstrument()
                    {
                        ElementInstrumentToUpload = new ElementInstrumentToUpload()
                        {
                            HoldInstrument = _context.HoldsInstrument.Find(transactInstrument.ElementInstrumentToUpload.HoldInstrument.Id),
                            Nomenclature = _context.InstrumentNomenclatures.Find(transactInstrument.ElementInstrumentToUpload.Nomenclature.Id),
                            XKey = transactInstrument.ElementInstrumentToUpload.XKey
                        },
                        Image = transactInstrument.Image
                    }); ;
                }


                _context.SaveChanges();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest();
            }

        }


        [HttpPost("PostElementMaterialToUpload")]
        public ActionResult PostElementMaterialToUpload([FromBody] ElementMaterialToUpload elementMaterialToUpload)
        {
            try
            {
                if (elementMaterialToUpload.MaterialNomenclature == null)
                {
                    _context.ElementMaterialToUploads.Add(new ElementMaterialToUpload() { Count = elementMaterialToUpload.Count, HoldMaterial = _context.HoldsMaterial.Find(elementMaterialToUpload.HoldMaterial.Id), Name = elementMaterialToUpload.Name, Units = elementMaterialToUpload.Units, UserName = elementMaterialToUpload.UserName });
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    _context.ElementMaterialToUploads.Add(new ElementMaterialToUpload() { Count = elementMaterialToUpload.Count, HoldMaterial = _context.HoldsMaterial.Find(elementMaterialToUpload.HoldMaterial.Id), MaterialNomenclature = _context.MaterialNomenclatures.Find(elementMaterialToUpload.MaterialNomenclature.Id), UserName = elementMaterialToUpload.UserName });
                    _context.SaveChanges();
                    return Ok();
                }

            }
            catch (Exception x)
            {
                return BadRequest();
            }

        }



        [HttpPost("AddNewMaterialNomeclature")]
        public ActionResult Post([FromBody] string[] op) // 
        {
            if (op[0] != null && op[1] != null)
            {


                try
                {

                    _context.MaterialNomenclatures.Add(new MaterialNomenclature { Name = op[0], Units = op[1] });
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception x)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }




        [HttpPost("AddNewInstrumentNomeclature")]
        public ActionResult PostInstrumentNomenclature([FromBody] string value) // 
        {
            try
            {
                _context.InstrumentNomenclatures.Add(new InstrumentNomenclature() { Name = value });
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest();
            }
        }






        [HttpPost("AddNewElementHeader/{id1}/{id2}")]
        public ActionResult PostNewElementHeader([FromRoute] int id1, [FromRoute] int id2, [FromBody] string value) // 
        {
            try
            {
                if (id1 == -1)
                {
                    _context.InstrumnetHeader.Add(new InstrumnetHeader() { Nomenclature = _context.InstrumentNomenclatures.Find(id2), XKey = value });
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    _context.TransactInstruments.Include(x => x.ElementInstrumentToUpload).Select(t => t.ElementInstrumentToUpload).First(x => x.Id == id1).InstrumnetHeader = new InstrumnetHeader() { Nomenclature = _context.InstrumentNomenclatures.Find(id2), XKey = value };
                    _context.SaveChanges();
                    return Ok();
                }



            }
            catch (Exception x)
            {
                return BadRequest();
            }
        }


        [HttpGet("GetImage/{id}")]

        public byte[] GetImage([FromRoute] int id)
        {
            try
            {
                return _context.TransactInstruments.Where(x => x.ElementInstrumentToUpload.Id == id).First().Image;
            }
            catch (Exception x)
            {
                return null;
            }
        }




        [HttpPost("AddNewUser")]
        public ActionResult PostUser([FromBody] string[] ss) // 
        {
            try
            {
                _context.Users.Add(new  User() { Name = ss[0], Password = ss[1] });
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest();
            }
        }



        [HttpPost("LoginUser")] 
        public User GetUser([FromBody] string[] data)
        {

            try
            {
                var login = data[0];
                var pass = data[1];
                var t = _context.Users.First(x=>x.Name==login&&x.Password==pass);


                return t;
            }
            catch (Exception x)
            {
                return null;
            }

        }

        [HttpGet("GetUsers")]
        public List<User> GetUsers()
        {

            try
            {
                var t = _context.Users.ToList();


                return t;
            }
            catch (Exception x)
            {
                return null;
            }

        }


    }
}
