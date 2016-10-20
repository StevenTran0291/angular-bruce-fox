using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using angularBruceFox.Models;

namespace angularBruceFox.Controllers
{
    public class TaskRecordsController : ApiController
    {
        private TaskRecordContext db = new TaskRecordContext();

        // GET: api/TaskRecords
        public IQueryable<TaskRecord> GetTaskss()
        {
            return db.Taskss;
        }

        // GET: api/TaskRecords/5

        [ResponseType(typeof(TaskRecord))]
        public IHttpActionResult GetTaskRecord(int id)
        {
            TaskRecord taskRecord = db.Taskss.Find(id);
            if (taskRecord == null)
            {
                return NotFound();
            }

            return Ok(taskRecord);
        }

        // PUT: api/TaskRecords/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskRecord(int id, TaskRecord taskRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskRecord.Task_Id)
            {
                return BadRequest();
            }

            db.Entry(taskRecord).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskRecordExists(id))
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

        // POST: api/TaskRecords
        [ResponseType(typeof(TaskRecord))]
        public IHttpActionResult PostTaskRecord(TaskRecord taskRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Taskss.Add(taskRecord);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taskRecord.Task_Id }, taskRecord);
        }

        // DELETE: api/TaskRecords/5
        [ResponseType(typeof(TaskRecord))]
        public IHttpActionResult DeleteTaskRecord(int id)
        {
            TaskRecord taskRecord = db.Taskss.Find(id);
            if (taskRecord == null)
            {
                return NotFound();
            }

            db.Taskss.Remove(taskRecord);
            db.SaveChanges();

            return Ok(taskRecord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskRecordExists(int id)
        {
            return db.Taskss.Count(e => e.Task_Id == id) > 0;
        }
    }
}