using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LGEDSCHOOL.Data.Model;
using LGEDSCHOOL.Models.View_Models;

namespace LGEDSCHOOL.Controllers
{
    public class TeacherInfoesController : Controller
    {
        private readonly LGEDSchoolContext _context;

        public TeacherInfoesController(LGEDSchoolContext context)
        {
            _context = context;
        }

        public TeacherInfo ConvertToTeacherInfo(TeacherInfoVM teacherInfoVM)
        {
            return new TeacherInfo
            {
                Id = teacherInfoVM.Id,
                InfrastructureInfo = teacherInfoVM.InfrastructureInfo,
                InfrastructureInfoId = teacherInfoVM.InfrastructureInfoId,
                MaleTeacherNum = teacherInfoVM.MaleTeacherNum,
                FemaleTeacherNum = teacherInfoVM.FemaleTeacherNum,
                AdditionalTeacher = teacherInfoVM.AdditionalTeacher,
                RecordYear = teacherInfoVM.RecordYear,
                IsMigrated = teacherInfoVM.IsMigrated,
                MigratedOn = teacherInfoVM.MigratedOn,
                CreatedOn = teacherInfoVM.CreatedOn,
                CreatedBy = teacherInfoVM.CreatedBy,
                UpdatedOn = teacherInfoVM.UpdatedOn,
                UpdatedBy = teacherInfoVM.UpdatedBy,
                IsDeleted = teacherInfoVM.IsDeleted,
                DeletedOn = teacherInfoVM.DeletedOn,
                DeletedBy = teacherInfoVM.DeletedBy
            };
        }

        public TeacherInfoVM ConvertToTeacherInfoVM(TeacherInfo teacherInfo)
        {
            return new TeacherInfoVM
            {
                Id = teacherInfo.Id,
                InfrastructureInfo = teacherInfo.InfrastructureInfo,
                InfrastructureInfoId = teacherInfo.InfrastructureInfoId,
                MaleTeacherNum = teacherInfo.MaleTeacherNum,
                FemaleTeacherNum = teacherInfo.FemaleTeacherNum,
                AdditionalTeacher = teacherInfo.AdditionalTeacher,
                RecordYear = teacherInfo.RecordYear,
                IsMigrated = teacherInfo.IsMigrated,
                MigratedOn = teacherInfo.MigratedOn,
                CreatedOn = teacherInfo.CreatedOn,
                CreatedBy = teacherInfo.CreatedBy,
                UpdatedOn = teacherInfo.UpdatedOn,
                UpdatedBy = teacherInfo.UpdatedBy,
                IsDeleted = teacherInfo.IsDeleted,
                DeletedOn = teacherInfo.DeletedOn,
                DeletedBy = teacherInfo.DeletedBy
            };
        }
        //dOn,UpdatedBy,IsDeleted,DeletedOn,DeletedBy
        // GET: TeacherInfoes
        public async Task<IActionResult> Index()
        {
            var vm = new List<TeacherInfoVM>();
            var lGEDSchoolContext = _context.TeacherInfo.Include(t => t.InfrastructureInfo).ToList();
            for (int i = 0; i < lGEDSchoolContext.Count; i++)
            {
                vm.Add(ConvertToTeacherInfoVM(lGEDSchoolContext[i]));
            }
            return View(vm);
        }

        // GET: TeacherInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.TeacherInfo
                .Include(t => t.InfrastructureInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherInfo == null)
            {
                return NotFound();
            }
            var teacherInfoVM = ConvertToTeacherInfoVM(teacherInfo);
            return View(teacherInfoVM);
        }


        public async Task<IActionResult> DetailsPV(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.TeacherInfo
                .Include(t => t.InfrastructureInfo)
                .FirstOrDefaultAsync(m => m.InfrastructureInfoId == id);
            if (teacherInfo == null)
            {
                return NotFound();
            }
            var teacherInfoVM = ConvertToTeacherInfoVM(teacherInfo);
            return PartialView(teacherInfoVM);
        }



        // GET: TeacherInfoes/Create
        public IActionResult Create()
        {
            ViewData["InfrastructureInfoId"] = new SelectList(_context.InfrastructureInfo, "Id", "EmisCode");
            return View();
        }


        // GET: CreatePV-------------------
        public IActionResult CreatePV([FromQuery]int infrastructureId)
        {
            ViewData["InfrastructureInfoId"] = new SelectList(_context.InfrastructureInfo, "Id", "EmisCode", infrastructureId);
            return PartialView();
        }
        // POST: TeacherInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InfrastructureInfoId,MaleTeacherNum,FemaleTeacherNum,AdditionalTeacher,RecordYear,IsMigrated,MigratedOn,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,IsDeleted,DeletedOn,DeletedBy")] TeacherInfoVM teacherInfoVM)
        {

            bool IsExist = _context.TeacherInfo.Any(X => X.InfrastructureInfoId == teacherInfoVM.InfrastructureInfoId);

            if (IsExist == true)
            {
                ModelState.AddModelError("InfrastructureInfoId", " This School EMIS Code Already Exist.");
            }

            if (teacherInfoVM.RecordYear > DateTime.Now.Year)
            {
                ModelState.AddModelError("RecordYear", "Record Year Can't be greater than Current Year..");
            }

            if (teacherInfoVM.MaleTeacherNum < 0)
            {
                ModelState.AddModelError("MaleTeacherNum", "Negative Value not allowed here.");
            }

            if (teacherInfoVM.FemaleTeacherNum < 0)
            {
                ModelState.AddModelError("FemaleTeacherNum", "Negative Value not allowed here.");
            }

            if (ModelState.IsValid)

            {
                teacherInfoVM.CreatedOn = DateTime.Now;
                _context.Add(ConvertToTeacherInfo(teacherInfoVM));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InfrastructureInfoId"] = new SelectList(_context.InfrastructureInfo, "Id", "EmisCode", teacherInfoVM.InfrastructureInfoId);
            return View(teacherInfoVM);
        }

        //POST CreatePV-------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePV([Bind("Id,InfrastructureInfoId,MaleTeacherNum,FemaleTeacherNum,AdditionalTeacher,RecordYear,IsMigrated,MigratedOn,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,IsDeleted,DeletedOn,DeletedBy")] TeacherInfoVM teacherInfoVM)
        {

            bool IsExist = _context.TeacherInfo.Any(X => X.InfrastructureInfoId == teacherInfoVM.InfrastructureInfoId);

            if (IsExist == true)
            {
                ModelState.AddModelError("InfrastructureInfoId", " This School EMIS Code Already Exist.");
                return BadRequest(new ServerResponse(data: ModelState, isSuccess: false));
            }

            if (teacherInfoVM.RecordYear > DateTime.Now.Year)
            {
                ModelState.AddModelError("RecordYear", "Record Year Can't be greater than Current Year..");
                return BadRequest(new ServerResponse(data: ModelState, isSuccess: false));
            }

            if (teacherInfoVM.MaleTeacherNum < 0)
            {
                ModelState.AddModelError("MaleTeacherNum", "Negative Value not allowed here.");
                return BadRequest(new ServerResponse(data: ModelState, isSuccess: false));
            }

            if (teacherInfoVM.FemaleTeacherNum < 0)
            {
                ModelState.AddModelError("FemaleTeacherNum", "Negative Value not allowed here.");
                return BadRequest(new ServerResponse(data: ModelState, isSuccess: false));
            }

            if (ModelState.IsValid)

            {
                teacherInfoVM.CreatedOn = DateTime.Now;
                _context.Add(ConvertToTeacherInfo(teacherInfoVM));
                await _context.SaveChangesAsync();
                return Ok(new ServerResponse(message: "Teacher information saved successfully"));
            }
            return BadRequest(new ServerResponse(data: ModelState, isSuccess: false));
        }

        // GET: TeacherInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.TeacherInfo.FindAsync(id);
            var teacherInfoVM = ConvertToTeacherInfoVM(teacherInfo);
            if (teacherInfoVM == null)
            {
                return NotFound();
            }
            ViewData["InfrastructureInfoId"] = new SelectList(_context.InfrastructureInfo, "Id", "EmisCode", teacherInfoVM.InfrastructureInfoId);
            return View(teacherInfoVM);
        }

        //GET EditPV =====================
        public async Task<IActionResult> EditPV(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.TeacherInfo.Include(l => l.InfrastructureInfo).FirstOrDefaultAsync(x => x.InfrastructureInfoId == id);
            //var teacherInfo = await _context.TeacherInfo.FindAsync(id);
            var teacherInfoVM = ConvertToTeacherInfoVM(teacherInfo);
            if (teacherInfoVM == null)
            {
                return NotFound();
            }
            ViewData["InfrastructureInfoId"] = new SelectList(_context.InfrastructureInfo, "Id", "EmisCode", teacherInfoVM.InfrastructureInfoId);
            return PartialView(teacherInfoVM);
        }

        // POST: TeacherInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InfrastructureInfoId,MaleTeacherNum,FemaleTeacherNum,AdditionalTeacher,RecordYear,IsMigrated,MigratedOn,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,IsDeleted,DeletedOn,DeletedBy")] TeacherInfoVM teacherInfoVM)
        {
            if (id != teacherInfoVM.Id)
            {
                return NotFound();
            }

            if (teacherInfoVM.RecordYear > DateTime.Now.Year)
            {
                ModelState.AddModelError("RecordYear", "Record Year Can't be greater than Current Year..");
            }

            if (teacherInfoVM.MaleTeacherNum < 0)
            {
                ModelState.AddModelError("MaleTeacherNum", "Negative Value not allowed here.");
            }

            if (teacherInfoVM.FemaleTeacherNum < 0)
            {
                ModelState.AddModelError("FemaleTeacherNum", "Negative Value not allowed here.");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    var teacherInfoUpdate = await _context.TeacherInfo.FindAsync(id);
                    teacherInfoUpdate.FemaleTeacherNum = teacherInfoVM.FemaleTeacherNum;
                    teacherInfoUpdate.MaleTeacherNum = teacherInfoVM.MaleTeacherNum;
                    teacherInfoUpdate.AdditionalTeacher = teacherInfoVM.AdditionalTeacher;
                    teacherInfoUpdate.RecordYear = teacherInfoVM.RecordYear;
                    teacherInfoUpdate.UpdatedOn = DateTime.Now;
                    _context.Update(teacherInfoUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherInfoExists(teacherInfoVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InfrastructureInfoId"] = new SelectList(_context.InfrastructureInfo, "Id", "EmisCode", teacherInfoVM.InfrastructureInfoId);
            return View(teacherInfoVM);
        }


        //POST EditPV=======================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPV(int id, [Bind("Id,InfrastructureInfoId,MaleTeacherNum,FemaleTeacherNum,AdditionalTeacher,RecordYear,IsMigrated,MigratedOn,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,IsDeleted,DeletedOn,DeletedBy")] TeacherInfoVM teacherInfoVM)
        {
            if (id != teacherInfoVM.Id)
            {
                return NotFound();
            }

            if (teacherInfoVM.RecordYear > DateTime.Now.Year)
            {
                ModelState.AddModelError("RecordYear", "Record Year Can't be greater than Current Year..");
            }

            if (teacherInfoVM.MaleTeacherNum < 0)
            {
                ModelState.AddModelError("MaleTeacherNum", "Negative Value not allowed here.");
            }

            if (teacherInfoVM.FemaleTeacherNum < 0)
            {
                ModelState.AddModelError("FemaleTeacherNum", "Negative Value not allowed here.");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    var teacherInfoUpdate = await _context.TeacherInfo.Include(l => l.InfrastructureInfo).FirstOrDefaultAsync(x => x.InfrastructureInfoId == id);
                    teacherInfoUpdate.FemaleTeacherNum = teacherInfoVM.FemaleTeacherNum;
                    teacherInfoUpdate.MaleTeacherNum = teacherInfoVM.MaleTeacherNum;
                    teacherInfoUpdate.AdditionalTeacher = teacherInfoVM.AdditionalTeacher;
                    teacherInfoUpdate.RecordYear = teacherInfoVM.RecordYear;
                    teacherInfoUpdate.UpdatedOn = DateTime.Now;
                    _context.Update(teacherInfoUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherInfoExists(teacherInfoVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new ServerResponse(message: "Teacher information Updated successfully", isSuccess: true));
            }
            return BadRequest(new ServerResponse(isSuccess: false, data: ModelState));

        }


        // GET: TeacherInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.TeacherInfo
                .Include(t => t.InfrastructureInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherInfo == null)
            {
                return NotFound();
            }
            var teacherInfoVM = ConvertToTeacherInfoVM(teacherInfo);
            return View(teacherInfoVM);
        }

        // POST: TeacherInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherInfo = await _context.TeacherInfo.FindAsync(id);
            _context.TeacherInfo.Remove(teacherInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherInfoExists(int id)
        {
            return _context.TeacherInfo.Any(e => e.Id == id);
        }
    }
}
