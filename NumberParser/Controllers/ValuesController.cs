using System;
using System.Web.Http;
using NumberParser.Models;
using NumberParser.ServiceClass.Interface;

namespace NumberParser.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly INumberToWordsService _helper;
        public ValuesController(INumberToWordsService wordHelper)
        {
            _helper = wordHelper;
        }        

        /// <summary>
        /// Post call where submitted values will be in UserDetails
        /// </summary>
        /// <param name="consumer">Submitted model</param>
        /// <returns>Returns the model with parsered value</returns>
        [HttpPost]
        public UserDetails SubmitValues(UserDetails consumer)
        {
            try
            {         
                // Checking whether the numebr passed is valid number
                bool isParsingSucess = double.TryParse(consumer.Number, out double number);
                if (isParsingSucess)
                {
                    consumer.NumberInWords = _helper.ConvertNumberToString(number);
                } else
                {
                    // Error message when invalid number is entered
                    consumer.NumberInWords = "INCORRECT";                     
                }

                return consumer;                
            }
            catch (Exception ex)
            {
                // Error message when there is an exception
                consumer.NumberInWords = "NOT PROCESSED.";
                return consumer;
            }            
        }
    }
}
