using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POEapi.Models;

namespace POEapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StashesController : ControllerBase
    {
        private readonly StashesContext _context;

        public StashesController(StashesContext context)
        {
            _context = context;
        }

        // GET: api/Stashes
        [HttpGet]
        public async Task<List<Stash>> Get()
        {
            StashRootObject stashRootObject = new StashRootObject();
            using (var client = new HttpClient())
            {
                try
                {
                    string responseBody = await client.GetStringAsync("http://api.pathofexile.com/public-stash-tabs");

                    stashRootObject = JsonConvert.DeserializeObject<StashRootObject>(responseBody);

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }

            return stashRootObject.stashes;

        }

        // GET: api/Stashes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stashes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Stashes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/Items
        [HttpGet("/api/items")]
        public async Task<List<ItemDTO>> GetAllItems()
        {
            StashRootObject stashRootObject = new StashRootObject();
            List<ItemDTO> pricedItems = new List<ItemDTO>();
            using (var client = new HttpClient())
            {
                try
                {
                    string responseBody = await client.GetStringAsync("http://api.pathofexile.com/public-stash-tabs");

                    stashRootObject = JsonConvert.DeserializeObject<StashRootObject>(responseBody);
                    foreach (var stash in stashRootObject.stashes)
                    {
                        if (stash.stash != null)
                            if (stash.stash.ToString().Contains("~"))
                            {
                                // from stash 
                                var items = new List<ItemDTO>();
                                foreach (var item in stash.items)
                                {
                                    var i = item;
                                    i.note = stash.stash.ToString();
                                    items.Add(Helpers.HelperMethods.getInstance().MapToDTO(i));
                                }

                                pricedItems.AddRange(items); ;

                            }
                            else
                            {
                                // from item 
                                foreach (var item in stash.items)
                                {
                                    if (item.note != null)
                                    {
                                        if (item.note.Contains("~"))
                                        {
                                            var i = Helpers.HelperMethods.getInstance().MapToDTO(item);
                                            pricedItems.Add(i);
                                        }
                                    }
                                }
                            }
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }

            return pricedItems.ToList();
        }
    }
}
