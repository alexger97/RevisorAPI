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
    public class InventoryObjectsController : ControllerBase
    {
        private readonly ServerContext _context;

        public InventoryObjectsController(ServerContext context)
        {
            _context = context;
        }

         
        [HttpGet("GetAllInventoryObject")]
        public List<InventoryObject> GetInventoryObjectsMain()
        {
            try
            {
                var tt = _context.InventoryObjectsMain.Include(y => y.HoldInstruments).Include(z => z.HoldMaterials).ToList();
                return tt;
            }
            catch (Exception x) { return null; }


        }


         

        [HttpPost("PostNewInstrumentHold/{Id}")]
        public ActionResult PostNewInstrumentHold([FromRoute]int id, [FromBody] string s)
        {
            try
            {
                _context.InventoryObjectsMain.Include(z => z.HoldInstruments).First(x => x.Id == id).HoldInstruments.Add(new HoldInstrument() { Name = s });
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest();

            }

        }

        [HttpPost("PostNewMaterialHold/{Id}")]
        public ActionResult PostNewMaterialHold([FromRoute]int id, [FromBody] string s)
        {
            try
            {
                _context.InventoryObjectsMain.Include(z => z.HoldMaterials).First(x => x.Id == id).HoldMaterials.Add(new HoldMaterial() { Name = s });
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest();

            }

        }


 
        [HttpPost("AddNewObject")]
        public ActionResult AddNewObject([FromBody] string s)
        {
            try
            {
                _context.InventoryObjectsMain.Add(new InventoryObject() { Name = s, HoldInstruments = new List<HoldInstrument>(), HoldMaterials = new List<HoldMaterial>() });
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest();
            }



        }
         /* 
        // DELETE: api/InventoryObjects/5
        [HttpDelete("{id}")]
        public ActionResult DeleteInventoryObject([FromRoute] int id)
        {
            try
            {
              if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var inventoryObject = _context.InventoryObjectsMain.Find(id);
                if (inventoryObject == null)
                {
                    return NotFound();
                }

                foreach (var instumenthold in inventoryObject.HoldInstruments)
                {
                   var tt= _context.TransactInstruments.Select(x => x.ElementInstrumentToUpload.HoldInstrument.Id==instumenthold.Id).ToList();

                    foreach (var element in tt)
                        _context.Remove(element);

                }
                foreach (var materialhold in inventoryObject.HoldInstruments)
                {
                    var tt = _context.TransactInstruments.Select(x => x.ElementInstrumentToUpload.HoldInstrument.Id == instumenthold.Id).ToList();

                    foreach (var element in tt)
                        _context.Remove(element);

                }

                _context.InventoryObjectsMain.Remove(inventoryObject);



           _context.SaveChanges();

                return Ok(inventoryObject);/*
            }
            catch(Exception x)
            {
                return BadRequest();
            }
           
        }*/

        private bool InventoryObjectExists(int id)
        {
            return _context.InventoryObjectsMain.Any(e => e.Id == id);
        }
    }
}
