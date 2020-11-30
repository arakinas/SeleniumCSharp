using System;
using System.IO;
using System.Text;

namespace SeleniumNet5.Selenium
{
    public class LogActions
    {
        private string BrowserType;
        private string url;
        private DateTime date;
        private StringBuilder reportcsv;
        private string directory = @"F:\SeleniumOutPut\"; //Local file system - you will need to change this
        private string filePath;
        private string fileName;

        public LogActions(string BrowserType)
        {       
            CreateLog(BrowserType);
        }

        internal void AddLog(string description, string result = null, string exception = null)
        {
            reportcsv.Append(description + ",");
            if(!(string.IsNullOrEmpty(result))){ reportcsv.Append(result + ",");}
            if(!(string.IsNullOrEmpty(exception))){ reportcsv.Append(exception + ",");}
            {reportcsv.Append(Environment.NewLine);}
            File.WriteAllText(filePath, reportcsv.ToString());
        }

        private void CreateCSVFile()
        {
            File.AppendAllText(filePath, reportcsv.ToString());
            AddLog("StepDescription", "Pass/Fail", "Exception");
        }

        public void CreateLog(string BrowserType)
        {
            this.BrowserType = BrowserType;
            date = DateTime.Now;
            fileName = FormatDateTime(date);
            reportcsv = new StringBuilder();           
            filePath = directory + fileName + ".csv";
            CreateCSVFile();  
        }

        private string FormatDateTime(DateTime date)
        {
            string day = date.Date.Date.Day.ToString() + "_" + date.Date.Date.Month.ToString() + "_" + date.Date.Date.Year.ToString();
            string hour = date.TimeOfDay.Hours.ToString();
            string minute = date.TimeOfDay.Minutes.ToString();
            string currentDate = day + hour + minute;

            return currentDate;
        }
    }
}
