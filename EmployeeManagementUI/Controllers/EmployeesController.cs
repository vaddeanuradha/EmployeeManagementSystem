using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem;
using EmployeeManagementSystemDbContext;
using Microsoft.AspNetCore.Authorization;
namespace EmployeeManagementUI.Controllers
{
    public class EmployeesController : Controller
    {
       
        [Authorize]
        // GET: Employees
        public  IActionResult Index()
        {
            return View(EmployeeManager.GetAllEmployees(HttpContext.User.Identity.Name));

        }

        // GET: Employees/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = EmployeeManager.GetEmployeeDetails(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);

            
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmpId,EManagerId,Email,EmpName,Address,WageRate,Contact,Department,JoinDate,Designation")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeManager.AddEmployee(employee);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = EmployeeManager.GetEmployeeDetails(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EmpId,EManagerId,Email,EmpName,Address,WageRate,Contact,Department,JoinDate,Designation")] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeManager.EditEmployee(employee);


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeManager.EmployeeExists(employee.EmpId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = EmployeeManager.GetEmployeeDetails(id.Value);
            if (employee == null)
            {
                return NotFound();
            }


            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            EmployeeManager.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return EmployeeManager.EmployeeExists(id);
        }
    }
}
