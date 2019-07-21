using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    //[Obsolete("错误",true)]
    [StudentAttribute]//特性命名时建议加后缀Attribute。使用时，可以不加后缀
    public class Student
    {
        public string ID { get; set; }

        [StudentName("John")]
        public string Name { get; set; }
    }

    enum ChineseStudent
    {
        [StudentName("张三")]
        ZhangSan=1,

        [StudentName("李四")]
        LiSi = 2

    }
}
