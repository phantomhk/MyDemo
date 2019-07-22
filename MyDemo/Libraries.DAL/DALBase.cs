using Libraries.Model;
using ProjectK.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectK.Framework.AttributeExtend;
using Libraries.IDAL;

namespace Libraries.DAL
{
    public class DALBase:IDALBase
    {
        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string strColumn = string.Join(",", type.GetProperties().Select(p => $"[{p.GetColumnName()}]"));
            string sql = $"select {strColumn} from [{type.Name}] where id={id} ";
            T t = (T)Activator.CreateInstance(type);

            using (SqlConnection conn = new SqlConnection(StaticConstant.strSqlServerConnection))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<T> result = this.ReaderToList<T>(reader);
                t = result.FirstOrDefault();

                //if (reader.Read())
                //{
                //    foreach (var prop in type.GetProperties())
                //    {
                //        prop.SetValue(t, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                //    }
                //}


            }
            return t;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> FindAll<T>() where T : BaseModel
        {
            Type type = typeof(T);
            string strColumn = string.Join(",", type.GetProperties().Select(p => $"[{p.GetColumnName()}]"));
            string sql = $"select {strColumn} from [{type.Name}]  ";
            List<T> result = new List<T>();

            using (SqlConnection conn = new SqlConnection(StaticConstant.strSqlServerConnection))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                result = this.ReaderToList<T>(reader);
                //while (reader.Read())
                //{
                //    T data = (T)Activator.CreateInstance(type);
                //    foreach (var prop in type.GetProperties())
                //    {
                //        prop.SetValue(data, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                //    }

                //    result.Add(data);
                //}
            }
            return result;
        }


        private List<T> ReaderToList<T>(SqlDataReader reader) where T : BaseModel
        {
            Type type = typeof(T);
            List<T> result = new List<T>();

            while (reader.Read())
            {
                T data = (T)Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties())
                {
                    object obj = reader[prop.GetColumnName()];
                    if (obj is DBNull)
                        obj = null;

                    prop.SetValue(data, obj);
                }

                result.Add(data);

            }

            return result;
        }


        public void Update<T>(T data) where T : BaseModel
        {
            Type type = typeof(T);
            var propArray = type.GetProperties().Where(p => !p.Name.Equals("Id"));
            string strColumn = string.Join(",", propArray.Select(p => $"[{p.GetColumnName()}]= @{p.GetColumnName()}"));
            var parameters = propArray.Select(p => new SqlParameter($"@{p.GetColumnName()}", p.GetValue(data) ?? DBNull.Value)).ToArray();

            string sql = $"update {type.Name} set {strColumn} where id={data.Id}  ";
            using (SqlConnection conn = new SqlConnection(StaticConstant.strSqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    int rowCount = cmd.ExecuteNonQuery();

                    if (rowCount == 0)
                        throw new Exception("修改的数据不存在");
                }
            }

        }


        public void Insert<T>(T data) where T : BaseModel
        {
            Type type = typeof(T);
            var propArray = type.GetProperties().Where(p => p.GetColumnName() != "Id");
            string strColum = string.Join(",", propArray.Select(p => $"[{p.GetColumnName()}]"));
            string strValue = string.Join(",", propArray.Select(p => $"@{p.GetColumnName() }"));
            string sql = $"insert into {type.Name}({strColum}) values({strValue})";

            var parameters = propArray.Select(p => new SqlParameter($"@{p.GetColumnName()}", p.GetValue(data) ?? DBNull.Value)).ToArray();

            using (SqlConnection conn = new SqlConnection(StaticConstant.strSqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    int rowCount = cmd.ExecuteNonQuery();

                    if (rowCount == 0)
                        throw new Exception("添加数据失败");
                }
            }
        }














    }
}
