using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSVWebApplication.Data;
using CSVWebApplication.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CSVWebApplication.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerContext _context;
        //private ICustomerService _service;

        private readonly IConfiguration _configuration;

        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            //var model = List<Customer>();
            List<Customer> customerList = new List<Customer>();
            string connectionString = _configuration["ConnectionStrings:CustomerContext"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From CUSTOMER"; SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CUST_CODE = Convert.ToString(dataReader["CUST_CODE"]);
                        customer.CUST_NAME = Convert.ToString(dataReader["CUST_NAME"]);
                        customer.CUST_CITY = Convert.ToString(dataReader["CUST_CITY"]);
                        customer.WORKING_AREA = Convert.ToString(dataReader["WORKING_AREA"]);
                        customer.CUST_COUNTRY = Convert.ToString(dataReader["CUST_COUNTRY"]);
                        customer.GRADE = Convert.ToDecimal(dataReader["GRADE"]);
                        customer.OPENING_AMT = Convert.ToDecimal(dataReader["OPENING_AMT"]);
                        customer.RECEIVE_AMT = Convert.ToDecimal(dataReader["RECEIVE_AMT"]);
                        customer.PAYMENT_AMT = Convert.ToDecimal(dataReader["PAYMENT_AMT"]);
                        customer.OUTSTANDING_AMT = Convert.ToDecimal(dataReader["OUTSTANDING_AMT"]);
                        customer.PHONE_NO = Convert.ToString(dataReader["PHONE_NO"]);
                        customerList.Add(customer);
                    }
                }
                connection.Close();
            }

            return View(customerList);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            Customer customer = new Customer();
            string connectionString = _configuration["ConnectionStrings:CustomerContext"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = $"Select * From CUSTOMER Where CUST_CODE = '{id}'"; SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        customer = new Customer();
                        customer.CUST_CODE = Convert.ToString(dataReader["CUST_CODE"]);
                        customer.CUST_NAME = Convert.ToString(dataReader["CUST_NAME"]);
                        customer.CUST_CITY = Convert.ToString(dataReader["CUST_CITY"]);
                        customer.WORKING_AREA = Convert.ToString(dataReader["WORKING_AREA"]);
                        customer.CUST_COUNTRY = Convert.ToString(dataReader["CUST_COUNTRY"]);
                        customer.GRADE = Convert.ToDecimal(dataReader["GRADE"]);
                        customer.OPENING_AMT = Convert.ToDecimal(dataReader["OPENING_AMT"]);
                        customer.RECEIVE_AMT = Convert.ToDecimal(dataReader["RECEIVE_AMT"]);
                        customer.PAYMENT_AMT = Convert.ToDecimal(dataReader["PAYMENT_AMT"]);
                        customer.OUTSTANDING_AMT = Convert.ToDecimal(dataReader["OUTSTANDING_AMT"]);
                        customer.PHONE_NO = Convert.ToString(dataReader["PHONE_NO"]);
                    }
                }
                connection.Close();
            }


            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration["ConnectionStrings:CustomerContext"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into CUSTOMER ([CUST_CODE],[CUST_NAME],[CUST_CITY],[WORKING_AREA],[CUST_COUNTRY],[GRADE],[OPENING_AMT],[RECEIVE_AMT],[PAYMENT_AMT],[OUTSTANDING_AMT],[PHONE_NO]) "
                                +$"Values ('{customer.CUST_CODE}', '{customer.CUST_NAME}','{customer.CUST_CITY}','{customer.WORKING_AREA}','{customer.CUST_COUNTRY}',{customer.GRADE},'{customer.OPENING_AMT}','{customer.RECEIVE_AMT}','{customer.PAYMENT_AMT}','{customer.OUTSTANDING_AMT}','{customer.PHONE_NO}')";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return RedirectToAction("Index");
                }
            }
            else
                return View();
        }
    

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            Customer customer = new Customer();
            string connectionString = _configuration["ConnectionStrings:CustomerContext"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = $"Select * From CUSTOMER Where CUST_CODE = '{id}'"; SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        customer = new Customer();
                        customer.CUST_CODE = Convert.ToString(dataReader["CUST_CODE"]);
                        customer.CUST_NAME = Convert.ToString(dataReader["CUST_NAME"]);
                        customer.CUST_CITY = Convert.ToString(dataReader["CUST_CITY"]);
                        customer.WORKING_AREA = Convert.ToString(dataReader["WORKING_AREA"]);
                        customer.CUST_COUNTRY = Convert.ToString(dataReader["CUST_COUNTRY"]);
                        customer.GRADE = Convert.ToDecimal(dataReader["GRADE"]);
                        customer.OPENING_AMT = Convert.ToDecimal(dataReader["OPENING_AMT"]);
                        customer.RECEIVE_AMT = Convert.ToDecimal(dataReader["RECEIVE_AMT"]);
                        customer.PAYMENT_AMT = Convert.ToDecimal(dataReader["PAYMENT_AMT"]);
                        customer.OUTSTANDING_AMT = Convert.ToDecimal(dataReader["OUTSTANDING_AMT"]);
                        customer.PHONE_NO = Convert.ToString(dataReader["PHONE_NO"]);
                    }
                }
                connection.Close();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer customer)
        {
            string connectionString = _configuration["ConnectionStrings:CustomerContext"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update CUSTOMER SET CUST_NAME='{customer.CUST_NAME}', CUST_CITY='{customer.CUST_CITY}', WORKING_AREA='{customer.WORKING_AREA}', CUST_COUNTRY='{customer.CUST_COUNTRY}', GRADE = {customer.GRADE}, OPENING_AMT = '{customer.OPENING_AMT}' , RECEIVE_AMT = '{customer.RECEIVE_AMT}' , PAYMENT_AMT = '{customer.PAYMENT_AMT}' , OUTSTANDING_AMT = '{customer.OUTSTANDING_AMT}' , PHONE_NO = '{customer.PHONE_NO}' Where CUST_CODE='{customer.CUST_CODE}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            Customer customer = new Customer();
            string connectionString = _configuration["ConnectionStrings:CustomerContext"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = $"Select * From CUSTOMER Where CUST_CODE = '{id}'"; SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        customer = new Customer();
                        customer.CUST_CODE = Convert.ToString(dataReader["CUST_CODE"]);
                        customer.CUST_NAME = Convert.ToString(dataReader["CUST_NAME"]);
                        customer.CUST_CITY = Convert.ToString(dataReader["CUST_CITY"]);
                        customer.WORKING_AREA = Convert.ToString(dataReader["WORKING_AREA"]);
                        customer.CUST_COUNTRY = Convert.ToString(dataReader["CUST_COUNTRY"]);
                        customer.GRADE = Convert.ToDecimal(dataReader["GRADE"]);
                        customer.OPENING_AMT = Convert.ToDecimal(dataReader["OPENING_AMT"]);
                        customer.RECEIVE_AMT = Convert.ToDecimal(dataReader["RECEIVE_AMT"]);
                        customer.PAYMENT_AMT = Convert.ToDecimal(dataReader["PAYMENT_AMT"]);
                        customer.OUTSTANDING_AMT = Convert.ToDecimal(dataReader["OUTSTANDING_AMT"]);
                        customer.PHONE_NO = Convert.ToString(dataReader["PHONE_NO"]);
                    }
                }
                connection.Close();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Customer customer)
        {
            string connectionString = _configuration["ConnectionStrings:CustomerContext"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete From CUSTOMER Where CUST_CODE='{customer.CUST_CODE}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        ViewBag.Result = "Operation got error:" + ex.Message;
                    }
                    connection.Close();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.CUST_CODE == id);
        }

    }
}