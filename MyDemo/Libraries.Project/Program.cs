using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries.Factory;
using Libraries.IDAL;
using Libraries.Model;
using ProjectK.Framework.AttributeExtend;

namespace Libraries.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("this is homework");

                //Company comp = new DALBase().Find<Company>(1);
                //IDALBase iDal = DALFactory.CreateInstance();
                //List<User> listUser = iDal.FindAll<User>();

                //Company comp = new Company();
                //comp.Id = 4;
                //comp.Name = "路虎";
                //comp.CreateTime = DateTime.Now;
                //comp.LastModifyTime = DateTime.Now;


                //Company comp1 = new Company();
                //comp.Id = 5;
                //comp.Name = "捷豹";
                //comp.CreateTime = DateTime.Now;
                //comp.LastModifyTime = DateTime.Now;

                //iDal.Update<Company>(comp);

                {
                    User u = new User();
                    u.Name = "123";
                    u.Account = "99";

                  bool isPass=  u.Validate<User>();
                }

            }
            catch (Exception ex)
            {

                throw;
            }




        }
    }
}
