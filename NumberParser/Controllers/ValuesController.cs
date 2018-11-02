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

        // POST api/values
        [HttpPost]
        public Consumer SubmitValues(Consumer consumer)
        {
            try
            {

                if(true)
                {
                    bool isparsingSucess = double.TryParse(consumer.Number, out double number);
                    if (isparsingSucess)
                    {
                        consumer.NumberInWords = _helper.ConvertNumberToString(number);
                        consumer.IsSuccess = true;
                    } else
                    {
                        consumer.NumberInWords = " INCORRECT";
                    }

                    return consumer;
                }
            }
            catch (Exception ex)
            {
                consumer.NumberInWords = " NOT PROCESSED.";
                return consumer;
            }            
        }
    }
}
