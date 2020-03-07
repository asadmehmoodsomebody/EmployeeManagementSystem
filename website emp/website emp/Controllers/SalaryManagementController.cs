using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;
using website_emp.Models.ApiModels;
using website_emp.Models.ViewModels;

namespace website_emp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class SalaryManagementController : Controller
    {
        Context context = new Context();
        public ActionResult AssignSalary(long? departmentid,string employename,int? pagenumber)
        {
            var departments = (from i in context.department
                               where i.IsDeleted == false
                               select new SelectListItem
                               {
                                   Value = i.DepartmentId.ToString(),
                                   Text = i.DepartmentName
                               }
                               ).ToList();
            var employes = (from i in context.employe
                            where i.IsDeleted == false
                            && i.IsActive == true
                            select i
                            ).ToList();
            departments.Insert(0, new SelectListItem { Value = "0", Text = "Select Department" });
            SelectList list = new SelectList(departments, "Value", "Text");
            
            if (!string.IsNullOrEmpty(employename))
            {
                ViewData["search"] = employename;
                employes = employes.Where(p => p.FirstName.Contains(employename)).Select(p=>p).ToList();
            }
            if (departmentid.HasValue && departmentid.Value!=0)
            {
                ViewData["departmentid"] = departmentid.Value;
                employes = employes.Where(p => p.Departmentid==departmentid.Value).Select(p => p).ToList();
                foreach(var item in list)
                {
                    if (item.Value == departmentid.Value.ToString())
                        item.Selected = true;
                }
            }
            foreach (var item in employes)
            {
                item.department = context.department.Find(item.Departmentid);
                item.designation = context.designation.Find(item.Designationid);
            }
            ViewData["Departments"] = list;
            if (!pagenumber.HasValue) pagenumber = 1;
            return View(Pagination<Employe>.Paged(employes,pagenumber.Value,10));
        }
        [HttpPost]
        public ActionResult AssignSalary(Employe employe)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Employe tempemp = context.employe.Find(employe.EmployeId);
            tempemp.Salary = employe.Salary;
            tempemp.ModifiedBy = emp.EmployeId;
            tempemp.Modifiedon = DateTime.Now;
            context.Entry(tempemp).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("AssignSalary", "SalaryManagement");
        }
       public ActionResult ManageBonus(string search,int? pagenumber)
        {
            var bonus = (from i in context.earning
                          where i.IsDeleted == false
                          select i
                          ).ToList();
            foreach (var item in bonus)
            {
                item.employe = context.employe.Find(item.EmployeId);
                item.employe.designation = context.designation.Find(item.employe.Designationid);
                item.employe.department = context.department.Find(item.employe.Departmentid);
            }
            bonus = (from i in bonus
                     where i.employe.IsDeleted == false
                     select i
                     ).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                bonus = bonus.Where(p => p.employe.UserName.Contains(search)).Select(p => p).ToList();
            }
            //bonus = bonus.Where(p => (p.ForMonth.Value.Month - 1 > DateTime.Now.Month && p.ForMonth.Value.Year >= DateTime.Now.Year)).Select(p => p).ToList();
            List<Earning> filteredlist = new List<Earning>();
            foreach (var item in bonus)
            {
                var invoices = context.invoice.Where(p=>p.EmployeId==item.EmployeId).Select(p=>p).ToList();
                bool Exist = false;
                foreach (var it in invoices)
                {
                    if (item.ForMonth.Value<=it.ForMonth.Value)
                    {
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    filteredlist.Add(item);
                }
                Exist = false;
            }
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            return View(Pagination<Earning>.Paged(filteredlist,pagenumber.Value,10));
        }
        public ActionResult AddBonus()
        {
            var employe = (from i in context.employe
                           where i.IsDeleted == false
                           && i.IsActive == true
                           select new SelectListItem
                           {
                               Value = i.EmployeId.ToString(),
                               Text = i.UserName
                           }
                           ).ToList();
            ViewData["EmployeId"] = new SelectList(employe, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult AddBonus(Earning earning)
        {
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Earning").Select(p => p).FirstOrDefault();
            Employe admin = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            counter.Count++;
            earning.EarningId = counter.Count;
            earning.CreatedBy = admin.EmployeId;
            earning.CreatedOn = DateTime.Now;
            earning.IsDeleted = false;
            context.earning.Add(earning);
            context.SaveChanges();
            return RedirectToAction("AddBonus");
        }
        public ActionResult EditBonus(long bonusid)
        {
            Earning earning = context.earning.Find(bonusid);
            earning.employe = context.employe.Find(earning.EmployeId);
            earning.employe.department = context.department.Find(earning.employe.Departmentid);
            earning.employe.designation = context.designation.Find(earning.employe.Designationid);
            return View(earning);
        }
        [HttpPost]
        public ActionResult EditBonus(Earning earning)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Earning earn = context.earning.Find(earning.EarningId);
            earn.ModifiedBy = emp.EmployeId;
            earn.Modifiedon = DateTime.Now;
            earn.ComName = earning.ComName;
            earn.Amount = earning.Amount;
            earn.ForMonth = earning.ForMonth;
            context.Entry(earn).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("ManageBonus");
        }
        public ActionResult ManageLoan(string search ,int? pagenumber)
        {
            var loans = (from i in context.loan
                         where i.IsDeleted == false
                         select i
                         ).ToList();
            foreach(var item in loans)
            {
                item.employe = context.employe.Find(item.EmployeId);
                item.employe.designation = context.designation.Find(item.employe.Designationid);
            }
            if (!string.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                loans = (from i in loans
                         where i.employe.FirstName.Contains(search)
                         select i
                         ).ToList();
            }
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            ViewData["pagenumber"] = pagenumber.Value;
            return View(Pagination<Loan>.Paged(loans,pagenumber.Value,10));
        }
        public ActionResult AddLoan()
        {
            return View();
        }
        public ActionResult EditLoan(long LoanId)
        {
            Loan loan = context.loan.Find(LoanId);
            loan.employe = context.employe.Find(loan.EmployeId);
            return View(loan);
        }
        [HttpPost]
        public ActionResult EditLoan(Loan loan,bool? Accepted =null)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Loan prevLoan = context.loan.Find(loan.LoanId);
            loan.installments = (from i in context.loaninstallment
                                 where (i.IsDeleted.Value == false)
                                 && (i.LoanId == loan.LoanId)
                                 && i.IsPaid == true
                                 select i
                                 ).ToList();
            double amount = 0;
            if (loan.installments.Count > 0)
            {
                foreach(var ins in loan.installments)
                {
                    amount += ins.Amount;
                }
            }
            if (loan.AllotedAmount < amount)
            {
                ViewBag.error = "Wrong value";
            }
            else
            {
                var loansint = (from i in context.loaninstallment
                                where i.IsDeleted.Value == false
                                && i.IsPaid == false && i.LoanId == loan.LoanId
                                select i
                                ).ToList() ;
                foreach (var item in loansint)
                {
                    item.IsDeleted = true;
                    item.ModifiedBy = emp.EmployeId;
                    item.Modifiedon = DateTime.Now;
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                loan.Remaining = loan.AllotedAmount - amount;
                double tempremaining = loan.Remaining;
                double reductionamount = (loan.ReductionAmount / 100.0) * loan.AllotedAmount;
                DateTime time = DateTime.Now.Add(TimeSpan.FromDays(30));
                while (tempremaining > 0)
                {
                    MentainanceCounter counter = context.counter.Where(p => p.TableName == "LoanInstallment").Select(p => p).FirstOrDefault();
                    counter.Count++;
                    double leftamount = (tempremaining-(tempremaining - reductionamount));
                    if (leftamount<=0)
                    {
                        leftamount = tempremaining;
                    }
                    LoanInstallment installment = new LoanInstallment
                    {
                        Amount = leftamount,
                        LoanId = loan.LoanId,
                        loan = context.loan.Find(loan.LoanId),
                        InstallmentId = counter.Count,
                        IsDeleted = false,
                        IsPaid = false,
                        PaidOn = time,
                        CreatedBy = emp.EmployeId,
                        CreatedOn = DateTime.Now
                    };
                    context.loaninstallment.Add(installment);
                    time = time.Add(TimeSpan.FromDays(30));
                    tempremaining = tempremaining - leftamount;
                }
                prevLoan.ModifiedBy = emp.EmployeId;
                prevLoan.Modifiedon = DateTime.Now;
                prevLoan.AllotedAmount = loan.AllotedAmount;
                prevLoan.DateStartLoan = loan.DateStartLoan;
                prevLoan.Remaining = loan.Remaining;
                prevLoan.LaonTitle = loan.LaonTitle;
                prevLoan.ReductionAmount = loan.ReductionAmount;
                prevLoan.LoanDescription = loan.LoanDescription;
                if (Accepted != null) prevLoan.Accepted = Accepted.Value;
                context.Entry(prevLoan).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                
            }
            return RedirectToAction("ManageLoan");
        }
        public ActionResult ManageDeduction(string search,int? pagenumber)
        {
            var deduction = (from i in context.deduction
                         where i.IsDeleted == false
                         select i
                         ).ToList();
            foreach (var item in deduction)
            {
                item.employe = context.employe.Find(item.EmployeId);
                item.employe.designation = context.designation.Find(item.employe.Designationid);
                item.employe.department = context.department.Find(item.employe.Departmentid);
            }
            deduction = (from i in deduction
                     where i.employe.IsDeleted == false
                     select i
                     ).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                deduction = deduction.Where(p => p.employe.UserName.Contains(search)).Select(p => p).ToList();
            }
            //bonus = bonus.Where(p => (p.ForMonth.Value.Month - 1 > DateTime.Now.Month && p.ForMonth.Value.Year >= DateTime.Now.Year)).Select(p => p).ToList();
            List<Deduction> filteredlist = new List<Deduction>();
            foreach (var item in deduction)
            {
                var invoices = context.invoice.Where(p => p.EmployeId == item.EmployeId).Select(p => p).ToList();
                bool Exist = false;
                foreach (var it in invoices)
                {
                    if (item.ForMonth.Value <= it.ForMonth.Value)
                    {
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    filteredlist.Add(item);
                }
                Exist = false;
            }
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            return View(Pagination<Deduction>.Paged(filteredlist, pagenumber.Value, 10));
        }
        public ActionResult AddDeduction()
        {
            var employe = (from i in context.employe
                           where i.IsDeleted == false
                           && i.IsActive == true
                           select new SelectListItem
                           {
                               Value = i.EmployeId.ToString(),
                               Text = i.UserName
                           }
                          ).ToList();
            ViewData["EmployeId"] = new SelectList(employe, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult AddDeduction(Deduction deduction)
        {
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Deduction").Select(p => p).FirstOrDefault();
            Employe admin = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            counter.Count++;
            deduction.DeductionId = counter.Count;
            deduction.CreatedBy = admin.EmployeId;
            deduction.CreatedOn = DateTime.Now;
            deduction.IsDeleted = false;
            context.deduction.Add(deduction);
            context.SaveChanges();
            return RedirectToAction("ManageDeduction");
        }
        public ActionResult EditDeduction(long deductionid)
        {
            Deduction deduction = context.deduction.Find(deductionid);
            deduction.employe = context.employe.Find(deduction.EmployeId);
            deduction.employe.department = context.department.Find(deduction.employe.Departmentid);
            deduction.employe.designation = context.designation.Find(deduction.employe.Designationid);
            return View(deduction);
        }
        [HttpPost]
        public ActionResult EditDeduction(Deduction deduction)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Deduction _deduction = context.deduction.Find(deduction.DeductionId);
            _deduction.ModifiedBy = emp.EmployeId;
            _deduction.Modifiedon = DateTime.Now;
            _deduction.ComName = deduction.ComName;
            _deduction.Amount = deduction.Amount;
            _deduction.ForMonth = deduction.ForMonth;
            context.Entry(_deduction).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("ManageDeduction");
        }
        public ActionResult ManageIncrement(string search,int? pagenumber)
        {
            var increments = (from i in context.increment
                              where i.IsDeleted == false
                              select i
                             ).ToList();
            foreach (var i in increments)
            {
                i.employe = context.employe.Find(i.EmployeId);
            }
            if (!string.IsNullOrEmpty(search))
            {
                increments = increments.Where(p => p.employe.FirstName.Contains(search)).Select(p => p).ToList();
                ViewData["search"] = search;
            }
            if (!pagenumber.HasValue)
            {
                pagenumber = 1;
            }
            ViewData["pagenumber"] = pagenumber.Value;
            return View(Pagination<Increment>.Paged(increments,pagenumber.Value,10));
        }
        public ActionResult AddIncrement()
        {
            var employes = (from i in context.employe
                            where i.IsActive == true
                            && i.IsDeleted == false
                            select new SelectListItem
                            {
                                Value=i.EmployeId.ToString(),
                                Text = i.UserName.ToString()
                            }
                            ).ToList();
            ViewData["employeid"] = new SelectList(employes, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult AddIncrement(Increment increment)
        {
            Employe Admin = context.employe.Where(e => e.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Employe emp = context.employe.Find(increment.EmployeId);
            emp.Salary += increment.Amount;
            emp.Modifiedon = DateTime.Now;
            emp.ModifiedBy = Admin.EmployeId;
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Increment").Select(p => p).FirstOrDefault();
            counter.Count++;
            increment.IncreamentId = counter.Count;
            increment.CreatedBy = Admin.EmployeId;
            increment.CreatedOn = DateTime.Now;
            increment.employe = emp;
            context.SaveChanges();
            return RedirectToAction("AddIncrement");
        }
        public ActionResult EditIncrement(long IncrementId)
        {
            Increment inc = context.increment.Find(IncrementId);
            inc.employe = context.employe.Find(inc.EmployeId);
            return View(inc);
        }
        [HttpPost]
        public ActionResult EditIncrement(Increment increment)
        {
            Employe Admin = context.employe.Where(e => e.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Employe emp = context.employe.Find(increment.EmployeId);
            Increment prevIncrement = context.increment.Find(increment.IncreamentId);
            emp.Salary -= prevIncrement.Amount;
            emp.Salary += increment.Amount;
            prevIncrement.IncrementDescription = increment.IncrementDescription;
            prevIncrement.ModifiedBy = Admin.EmployeId;
            prevIncrement.Modifiedon = DateTime.Now;
            prevIncrement.Amount = increment.Amount;
            emp.Modifiedon = DateTime.Now;
            emp.ModifiedBy = Admin.EmployeId;
            context.Entry(prevIncrement).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("ManageIncrement");
        }
        public ActionResult GeneratePaySlip(long? departmentid)
        {
            var Deps = (from i in context.department
                        where i.IsDeleted == false
                        select new SelectListItem
                        {
                            Value = i.DepartmentId.ToString(),
                            Text = i.DepartmentName
                        }
                        ).ToList();
            Deps.Insert(0, new SelectListItem { Value = "-1", Text = "Select Department" });
            Deps.Insert(0, new SelectListItem { Value = "0", Text = "All" });
            ViewData["DepartmentId"] = (departmentid.HasValue) ? new SelectList(Deps, "Value", "Text", departmentid.Value) : new SelectList(Deps, "Value", "Text", "-1");
            return View();
        }
        public ActionResult EmployeeSalaries(int? pagenumber,string search)
        {
            Employe employe = context.employe.Where(emp => emp.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var invoices = (from i in context.invoice
                            where i.IsDeleted == false
                            && i.EmployeId == employe.EmployeId
                            select i
                            ).ToList();
            foreach (var item in invoices)
            {
                item.employe = employe;
            }
            if (!string.IsNullOrEmpty(search))
            {
                DateTime tempdate = DateTime.Parse(search); 
                ViewData["search"] = search;
                invoices = (from i in invoices
                            where i.ForMonth.Value.Month == tempdate.Month
                            && i.ForMonth.Value.Year == tempdate.Year
                            && i.IsDeleted == false
                            select i).ToList();
            }
            if (!pagenumber.HasValue)
            {
                pagenumber = 1;
            }
            return View(Pagination<Invoice>.Paged(invoices,pagenumber.Value,10));
        }
        public ActionResult EmployeeSalaryDetails(long invoiceid)
        {
            Invoice invoice = context.invoice.Find(invoiceid);
            Employe employe = context.employe.Find(invoice.EmployeId);
            employe.designation = context.designation.Find(employe.Designationid);
            employe.department = context.department.Find(employe.Departmentid);
            var deductions = (from i in context.deduction
                            where i.IsDeleted == false
                            && i.EmployeId == invoice.EmployeId
                            && i.ForMonth.Value >= invoice.FromMonth.Value
                            && i.ForMonth.Value <= invoice.ToMonth.Value
                              select i
                            ).ToList();
            var earnings = (from i in context.earning
                            where i.IsDeleted == false
                            && i.EmployeId == invoice.EmployeId
                            && i.ForMonth.Value >= invoice.FromMonth.Value
                            && i.ForMonth.Value <= invoice.ToMonth.Value
                            select i
                            ).ToList();
            //double tearning = 0;
            //double tdeduction = 0;
            //foreach (var item in earnings)
            //{
            //    tearning += item.Amount;
            //}
            //foreach (var item in deductions)
            //{
            //    tdeduction += item.Amount;
            //}
            //double netsalary = employe.Salary -tdeduction + tearning;
            //ViewData["TotalEarning"] = tearning;
            //ViewData["TotalDeduction"] = tdeduction;
            //ViewData["NetSalary"] = netsalary;
            InvoiceEmployeEarningDeductionViewModel model = new InvoiceEmployeEarningDeductionViewModel
            {
                invoice = invoice,
                employe = employe,
                earning = earnings,
                deduction = deductions
            };
            return View(model);
        }
        public ActionResult SalaryReport(int? month,int? year,string username,int? pagenumber)
        {
           string[] months =new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            month = (month.HasValue) ? month.Value : DateTime.Now.Month;
            year = (year.HasValue) ? year.Value : DateTime.Now.Year;
            ViewData["year"] = year;
            ViewData["month"] = month;
            username = (!string.IsNullOrEmpty(username)) ? username : "";
            ViewData["username"] = username;
            var salary = (from i in context.invoice
                          where i.IsDeleted == false
                          && i.ForMonth.Value.Month == month
                          && i.ForMonth.Value.Year == year
                          select i
                          ).ToList();
            foreach (var item in salary)
            {
                item.employe = context.employe.Find(item.EmployeId);
            }
            salary = (from i in salary
                      where i.employe.FirstName.Contains(username)
                      select i
                      ).ToList();
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            return View(Pagination<Invoice>.Paged(salary,pagenumber.Value,10));
        }
        public ActionResult LoanRequest(string returnurl)
        {
            if (!string.IsNullOrEmpty(returnurl))
                ViewData["returnurl"] = returnurl;
            else
                ViewData["returnurl"] = Url.Action("Index", "DashBoard");
            return View();
        }
        [HttpPost]
        public ActionResult LoanRequest(Loan loan)
        {
            Employe emp = context.employe.Where(e => e.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Loan").Select(p => p).FirstOrDefault();
            counter.Count++;
            loan.LoanId = counter.Count;
            loan.CreatedBy = emp.EmployeId;
            loan.employe = context.employe.Find(emp.EmployeId);
            loan.EmployeId = emp.EmployeId;
            loan.CreatedOn = DateTime.Now;
            loan.IsFinished = false;
            loan.RequestDate = DateTime.Now;
            loan.IsDeleted = false;
            context.loan.Add(loan);
            context.SaveChanges();
            return View();
        }
        public ActionResult MyLoan(int? pagenumber)
        {
            Employe emp = context.employe.Where(e => e.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var loans = (from i in context.loan
                         where i.IsDeleted == false
                         && i.EmployeId == emp.EmployeId
                         select i
                         ).ToList();
            foreach (var item in loans)
            {
                item.employe = context.employe.Find(item.EmployeId);
            }
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            return View(Pagination<Loan>.Paged(loans,pagenumber.Value,10));
        }
        public ActionResult MyLoanDetail(long LoanId,int? pagenumber)
        {
            var installments = (from i in context.loaninstallment
                                where i.IsDeleted == false &&
                                i.LoanId == LoanId
                                select i
                                ).ToList();
            foreach(var item in installments)
            {
                item.loan = context.loan.Find(item.LoanId);
                item.loan.employe = context.employe.Find(item.loan.EmployeId);
            }
            ViewData["loanid"] = LoanId;
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            Pagination<LoanInstallment> inst = Pagination<LoanInstallment>.Paged(installments, pagenumber.Value, 10);
            return View(Pagination<LoanInstallment>.Paged(installments,pagenumber.Value,10));
        }


        [HttpPost]
        public ActionResult GetUnpaidList(long DepartmentId,string search)
        {
            DateTime time= DateTime.Now;
            IEnumerable<EmployeInvoiceViewModel> Employes; 
            if (DepartmentId == 0)
            {
                Employes = (from i in context.employe
                           where i.IsDeleted == false && i.IsActive==true
                            select new EmployeInvoiceViewModel
                            {
                                employe = i
                            }
                            
                            ).ToList();
            }
            else
            {
                Employes = (from i in context.employe
                            where i.IsDeleted == false && i.IsActive == true
                            && i.Departmentid == DepartmentId
                            select new EmployeInvoiceViewModel
                            {
                                employe = i
                            }).ToList();
            }
            foreach (var item in Employes)
            {
                var result = (from i in context.invoice
                              where i.IsDeleted == false &&
                               i.EmployeId == item.employe.EmployeId
                               && i.ForMonth.Value.Month == time.Month
                               && i.ForMonth.Value.Year == time.Year
                              select i
                              ).FirstOrDefault();
                if (result == null) item.invoice = null;
                else
                {
                    item.invoice = new List<Invoice>();
                    item.invoice.Add(result);
                }
                item.employe.department = context.department.Find(item.employe.Departmentid);
                item.employe.designation = context.designation.Find(item.employe.Designationid);
            }
            var employes = (from i in Employes
                            where i.invoice == null
                            select new GeneratePaySlipApiModel
                            {
                                EmployeId = i.employe.EmployeId,
                                DepartmentName = i.employe.department.DepartmentName,
                                DesignationName = i.employe.designation.DesignationName,
                                EmployeName = i.employe.FirstName,
                                fromdate = null,
                                todate = null
                            }
                            ).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                employes = employes.Where(p => p.EmployeName.Contains(search)).Select(p => p).ToList();
            }
            return Json(new { data = employes });
        }
        [HttpPost]
        public ActionResult GeneratePaySlip(long EmployeId,DateTime? fromdate,DateTime? todate)
        {
            Employe Admin = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Employe emp = context.employe.Where(p => p.EmployeId == EmployeId).Select(p => p).FirstOrDefault();
            MentainanceCounter Invoicecount = context.counter.Where(p => p.TableName == "Invoice").Select(p => p).FirstOrDefault();
            MentainanceCounter DeductionCount = context.counter.Where(p => p.TableName == "Deduction").Select(p => p).FirstOrDefault();
            Invoicecount.Count++;
            Loan ploan = context.loan.Where(p => p.Remaining > 0 && p.EmployeId == emp.EmployeId).Select(p => p).FirstOrDefault();
            if (ploan != null)
            {
                var loan = (from i in context.loaninstallment
                            where i.IsDeleted == false && i.IsPaid == false
                            && ploan.LoanId == i.LoanId
                            && i.PaidOn.Value <= DateTime.Now
                            select i
                             ).FirstOrDefault();

                if (loan != null)
                {
                    loan.PaidOn = DateTime.Now;
                    loan.ModifiedBy = Admin.EmployeId;
                    loan.Modifiedon = DateTime.Now;
                    loan.IsPaid = true;
                    context.Entry(loan).State = System.Data.Entity.EntityState.Modified;
                    DeductionCount.Count++;
                    Deduction deduction = new Deduction()
                    {
                        Amount = (long)loan.Amount,
                        ComName = "Loan Installment",
                        CreatedBy = Admin.EmployeId,
                        CreatedOn = DateTime.Now,
                        EmployeId = emp.EmployeId,
                        employe = context.employe.Find(emp.EmployeId),
                        ForMonth = loan.PaidOn,
                        DeductionId = DeductionCount.Count,
                        IsDeleted = false,
                    };
                    context.deduction.Add(deduction);
                    Loan lp = context.loan.Find(loan.LoanId);
                    lp.Remaining -= loan.Amount;
                    lp.ModifiedBy = Admin.EmployeId;
                    lp.Modifiedon = DateTime.Now;
                    if (lp.Remaining <= 0) lp.IsFinished = true;
                    context.Entry(lp).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
            long DeductionAmount = 0;
            long EarningAmounut = 0;
            var deductions = (from i in context.deduction
                              where i.IsDeleted == false && i.EmployeId == emp.EmployeId
                              && i.ForMonth.Value.Month == DateTime.Now.Month
                              && i.ForMonth.Value.Year == DateTime.Now.Year
                               select i).ToList();
            foreach (var i in deductions)
            {
                DeductionAmount += i.Amount;
            }
            var earnings = (from i in context.earning
                            where i.IsDeleted == false && i.EmployeId == emp.EmployeId
                             && i.ForMonth.Value.Month == DateTime.Now.Month
                              && i.ForMonth.Value.Year == DateTime.Now.Year
                            select i).ToList();
            foreach (var i in earnings)
            {
                EarningAmounut += (long)i.Amount;
            }
            Invoice invoice = new Invoice()
            {
                employe = context.employe.Find(EmployeId),
                EmployeId = EmployeId,
                CreatedBy = Admin.EmployeId,
                CreatedOn = DateTime.Now,
                ForMonth = DateTime.Now,
                FromMonth = fromdate,
                ToMonth = todate,
                IsDeleted = false,
                InvoiceId = Invoicecount.Count,
                Salary = emp.Salary,
                Deduction = DeductionAmount,
                Earning = EarningAmounut,
                NetSalary = emp.Salary-DeductionAmount+EarningAmounut
            };
            try
            {
                context.invoice.Add(invoice);
                context.SaveChanges();
                return Json("Ok");
            }catch(Exception ex)
            {
                return Json("Error");
            }

        }
        public ActionResult GeneratePaySlipMany(string EmployesId)
        {
            String[] Ids = EmployesId.Split(new char[] {',' },StringSplitOptions.RemoveEmptyEntries);
            foreach (var i in Ids)
            {
                long id = long.Parse(i);
                GeneratePaySlip(id,null, null);
            }
            return Json("Ok");
        }
    }
}