using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderFast1.Common;
using OrderFast1.Models;

namespace OrderFast1.DataAccess
{
    public class OrderDA : IOrderDA
    {
        public List<Order> GetOrder()
        {
            DataTable dt = DBCommon.GetResultDataTableBySql("GetOrders");
            List<Order> order = new List<Order>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Order or = new Order();
                or.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                or.OrderDate = Convert.ToDateTime(dt.Rows[i]["OrderDate"]);
                or.OrderedBy = Convert.ToString(dt.Rows[i]["OrderedBy"]);
                or.TotalBill = Convert.ToInt32(dt.Rows[i]["TotalBill"]);
                order.Add(or);
            }
            return order;
        }
        public List<Order> GetOrderById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            });
            DataTable dt = DBCommon.GetResultDataTableBySql("GetOrderById @Id", parameters);
            List<Order> order = new List<Order>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Order or = new Order();
                or.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                or.OrderDate = Convert.ToDateTime(dt.Rows[i]["OrderDate"]);
                or.OrderedBy = Convert.ToString(dt.Rows[i]["OrderedBy"]);
                or.TotalBill = Convert.ToInt32(dt.Rows[i]["TotalBill"]);
                order.Add(or);
            }
             return order;
            
        }
        public int AddOrder(Order or)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = or.Id
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = or.OrderDate
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderedBy",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = or.OrderedBy
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@TotalBill",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input,
                Value = or.TotalBill
            });
            string sql = "AddOrder @Id,@OrderDate,@OrderedBy,@TotalBill";
            return DBCommon.ExecuteNonQuerySql(sql, parameters);
        }

        public int DeleteOrder(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            });
            return DBCommon.ExecuteNonQuerySql("DeleteOrder @Id",parameters);  
        }

        public int UpdateOrder(Order or)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = or.Id
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = or.OrderDate
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderedBy",
                SqlDbType = SqlDbType.Text,
                Direction = ParameterDirection.Input,
                Value = or.OrderedBy
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@TotalBill",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input,
                Value = or.TotalBill
            });
            string sql = "UpdateOrder @Id,@OrderDate,@OrderedBy,@TotalBill";
            return DBCommon.ExecuteNonQuerySql(sql, parameters);
        }
    }
}
