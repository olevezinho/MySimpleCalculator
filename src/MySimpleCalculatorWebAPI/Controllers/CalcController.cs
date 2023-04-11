﻿namespace MyCalculatorWebApp.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using MySimpleCalculator;
    using MySimpleCalculatorWebAPI.Extensions;

    /// <summary>Calculator controller class: Two methods</summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly ICalculator calculator;

        /// <summary>
        /// Constructor for the calculator controller
        /// </summary>
        /// <param name="calculator"></param>
        public CalcController(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// Add two numbers and return the result
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>200 OK; 404 Bad Request</returns>
        // POST api/values
        [HttpPost("add/{n1}/{n2}")]
        public ActionResult<string> PostNumbersAdd(int n1, int n2)
        {
            try
            {
                return new ObjectResult(calculator.Add(n1, n2).ToString());
            }
            catch (ArgumentNullException ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Subtract two numbers and return the result
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>200 OK; 404 Bad Request</returns>
        // POST api/values
        [HttpPost("sub/{n1}/{n2}")]
        public ActionResult<string> PostNumbersSub(int n1, int n2)
        {
            try
            {
                return new ObjectResult(calculator.Subtract(n1, n2).ToString());
            }
            catch (ArgumentNullException ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// Multiply two numbers and return the result
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>200 OK; 404 Bad Request</returns>
        // POST api/values
        [HttpPost("mul/{n1}/{n2}")]
        public ActionResult<string> PostNumbersMul(int n1, int n2)
        {
            try
            {
                return new ObjectResult(calculator.Multiply(n1, n2).ToString());
            }
            catch (ArgumentNullException ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Divide two numbers and return the result
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>200 OK; 404 Bad Request</returns>
        // POST api/values
        [HttpPost("div/{n1}/{n2}")]
        public ActionResult<string> PostNumbersDiv(int n1, int n2)
        {
            try
            {
                return new ObjectResult(calculator.Divide(n1, n2).ToString());
            }
            catch (DivideByZeroException ex)
            {
                return ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Divide two numbers and return the result
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>200 OK; 404 Bad Request</returns>
        // POST api/values
        [HttpPost("mod/{n1}/{n2}")]
        public ActionResult<string> PostNumbersMod(int n1, int n2)
        {
            try
            {
                return new ObjectResult(calculator.Mod(n1, n2).ToString());
            }
            catch (DivideByZeroException ex)
            {
                return ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                return ex.Message;
            }
        }
    }
}
