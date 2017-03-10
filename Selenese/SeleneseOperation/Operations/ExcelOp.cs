using SeleneseOperation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace SeleneseOperation.Operations
{
    public class ExcelOp
    {
        private const string defaultPassword = "acesso2016";

        public static List<Person> GetData(DataSet people)
        {
            List<Person> returnedList = new List<Person>();
            var peopleToConvert = people.Tables[0].Rows;
            int index = 0;

            try
            {
                while (CheckLine(peopleToConvert[index]))
                {
                    Person per = new Person()
                    {
                        Name = peopleToConvert[index].ItemArray[0].ToString(),
                        Role = peopleToConvert[index].ItemArray[1].ToString(),
                        Status = peopleToConvert[index].ItemArray[2].ToString(),
                        UserName = DealWithSpecialChars(peopleToConvert[index].ItemArray[3].ToString()),
                        Password = defaultPassword,
                        Position = peopleToConvert[index].ItemArray[4].ToString()
                    };
                    returnedList.Add(per);

                    index++;
                }
                people.Dispose();
                return returnedList;
            }
            catch (Exception)
            {
                people.Dispose();
                return returnedList;
            }
        }

        private static string DealWithSpecialChars(string v)
        {
            return Regex.Replace(v, @"[^\d]", "");
        }

        private static bool CheckLine(DataRow row)
        {
            var valueToCheck = row.ItemArray[0];
            if (valueToCheck.Equals(DBNull.Value))
                return false;
            return true;
        }
    }
}
