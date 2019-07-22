using Libraries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.IDAL
{
    public interface IDALBase
    {
        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : BaseModel;

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> FindAll<T>() where T : BaseModel;

        void Update<T>(T data) where T : BaseModel;


        void Insert<T>(T data) where T : BaseModel;














    }
}
