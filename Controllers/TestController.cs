using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WeChat.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public JsonResult GetAllStudents()
        {
            var students = new List<Student>
            {
                new Student(){ID  =1,Name = "张三",Age =20, Birthday = DateTime.Now},
                new Student(){ID  =2,Name = "李四",Age =20, Birthday = DateTime.Now}
            };

            var result = new JsonResult();
            result.Data = students;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
