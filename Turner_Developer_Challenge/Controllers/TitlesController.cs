using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Turner_Developer_Challenge.Models.Data;

namespace Turner_Developer_Challenge.Controllers
{
    public class TitlesController : ApiController
    {
        private readonly TitlesContext db = new TitlesContext();

        // GET: api/titles
        [HttpGet]
        [Route("api/titles")]
        public IQueryable GetTitles()
        {
            var json = db.Titles.Select(title => new {
                title.TitleId,
                title.TitleName,
                title.TitleNameSortable,
                title.TitleTypeId,
                title.ReleaseYear,
                title.ProcessedDateTimeUTC
            });

            return json;
        }

        // GET: api/titles/Disturbia
        [HttpGet]
        [Route("api/titles/{titleName}")]
        public IQueryable GetTitle(string titleName)
        {
            var title = db.Titles.Select(t => new {
                t.TitleId,
                t.TitleName,
                t.TitleNameSortable,
                t.TitleTypeId,
                t.ReleaseYear,
                t.ProcessedDateTimeUTC
            }).Where( t => t.TitleName == titleName);

            return title;
        }

        // PUT: api/Titles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTitle(int id, Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != title.TitleId)
            {
                return BadRequest();
            }

            db.Entry(title).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Titles
        [ResponseType(typeof(Title))]
        public async Task<IHttpActionResult> PostTitle(Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Titles.Add(title);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitleExists(title.TitleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = title.TitleId }, title);
        }

        // DELETE: api/Titles/5
        [ResponseType(typeof(Title))]
        public async Task<IHttpActionResult> DeleteTitle(int id)
        {
            Title title = await db.Titles.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            db.Titles.Remove(title);
            await db.SaveChangesAsync();

            return Ok(title);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TitleExists(int id)
        {
            return db.Titles.Count(e => e.TitleId == id) > 0;
        }
    }
}