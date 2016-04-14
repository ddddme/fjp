using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using yangNetCl;
using _D = yangNetCl.Cl_DataMag;
namespace d_fjp
{   
	/// <summary>
	 	///用户表
	/// </summary>
	public class tb_user
	{
      	private int _tb_user_id;
		private string _tb_user_wxbs="";
		private string _tb_user_sfz="";
		private string _tb_user_phone="";
		private string _tb_user_dz="";
		private string _tb_user_email="";
		private string _tb_user_name="";
		      	/// <summary>
		/// 主键
        /// </summary>		
        public int tb_user_ID
        {
            get{ return _tb_user_id; }
            set{ _tb_user_id = value; }
        }        
		/// <summary>
		/// 微信标识
        /// </summary>		
        public string tb_user_wxbs
        {
            get{ return _tb_user_wxbs; }
            set{ _tb_user_wxbs = value; }
        }        
		/// <summary>
		/// 身份证号
        /// </summary>		
        public string tb_user_sfz
        {
            get{ return _tb_user_sfz; }
            set{ _tb_user_sfz = value; }
        }        
		/// <summary>
		/// 电话
        /// </summary>		
        public string tb_user_phone
        {
            get{ return _tb_user_phone; }
            set{ _tb_user_phone = value; }
        }        
		/// <summary>
		/// 地址
        /// </summary>		
        public string tb_user_dz
        {
            get{ return _tb_user_dz; }
            set{ _tb_user_dz = value; }
        }        
		/// <summary>
		/// 邮箱
        /// </summary>		
        public string tb_user_email
        {
            get{ return _tb_user_email; }
            set{ _tb_user_email = value; }
        }        
		/// <summary>
		/// 姓名
        /// </summary>		
        public string tb_user_name
        {
            get{ return _tb_user_name; }
            set{ _tb_user_name = value; }
        }        
		        /// <summary>
        /// 通过GID返回实体对象
        /// </summary>
        public static tb_user getNewModel(int pId, _D.myTransaction mt = null)
        {
            StringBuilder strSql = new StringBuilder();
			strSql.Append("select tb_user_ID, tb_user_wxbs, tb_user_sfz, tb_user_phone, tb_user_dz, tb_user_email, tb_user_name  ");			
			strSql.Append("  from tb_user ");
            strSql.Append(" where tb_user_ID='"+pId+"'");

            DataTable dt = _D.getDb(strSql.ToString(),pMt:mt);
            if (dt.Rows.Count> 0)
            {
                tb_user model = new tb_user();
		      	if(dt.Rows[0]["tb_user_ID"] != null&&dt.Rows[0]["tb_user_ID"].ToString()!="")model.tb_user_ID=Convert.ToInt32(dt.Rows[0]["tb_user_ID"].ToString());		      	
		      	if(dt.Rows[0]["tb_user_wxbs"] != null&&dt.Rows[0]["tb_user_wxbs"].ToString()!="")model.tb_user_wxbs=dt.Rows[0]["tb_user_wxbs"].ToString();		      	
		      	if(dt.Rows[0]["tb_user_sfz"] != null&&dt.Rows[0]["tb_user_sfz"].ToString()!="")model.tb_user_sfz=dt.Rows[0]["tb_user_sfz"].ToString();		      	
		      	if(dt.Rows[0]["tb_user_phone"] != null&&dt.Rows[0]["tb_user_phone"].ToString()!="")model.tb_user_phone=dt.Rows[0]["tb_user_phone"].ToString();		      	
		      	if(dt.Rows[0]["tb_user_dz"] != null&&dt.Rows[0]["tb_user_dz"].ToString()!="")model.tb_user_dz=dt.Rows[0]["tb_user_dz"].ToString();		      	
		      	if(dt.Rows[0]["tb_user_email"] != null&&dt.Rows[0]["tb_user_email"].ToString()!="")model.tb_user_email=dt.Rows[0]["tb_user_email"].ToString();		      	
		      	if(dt.Rows[0]["tb_user_name"] != null&&dt.Rows[0]["tb_user_name"].ToString()!="")model.tb_user_name=dt.Rows[0]["tb_user_name"].ToString();		      	
		      	return model;                
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 插入一条数据
        /// </summary>
        public void add(_D.myTransaction mt = null){
            StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tb_user(");			
            strSql.Append("tb_user_wxbs,tb_user_sfz,tb_user_phone,tb_user_dz,tb_user_email,tb_user_name");
			strSql.Append(") values (");
            strSql.Append("@tb_user_wxbs,@tb_user_sfz,@tb_user_phone,@tb_user_dz,@tb_user_email,@tb_user_name");            
            strSql.Append(") ");       
			SqlParameter[] parameters = {
			            new SqlParameter("@tb_user_wxbs", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_sfz", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_phone", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_dz", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_email", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_name", SqlDbType.VarChar,8000)             
              
            };
                        
            parameters[0].Value =this.tb_user_wxbs;                        
            parameters[1].Value =this.tb_user_sfz;                        
            parameters[2].Value =this.tb_user_phone;                        
            parameters[3].Value =this.tb_user_dz;                        
            parameters[4].Value =this.tb_user_email;                        
            parameters[5].Value =this.tb_user_name;            

            tb_user_ID=_D.dbExe(strSql.ToString(), parameters,pMt:mt);
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(string strWhere="", _D.myTransaction mt = null)
        {
            StringBuilder strSql = new StringBuilder();
			strSql.Append("update tb_user set ");         
            strSql.Append(" tb_user_wxbs = @tb_user_wxbs , ");         
            strSql.Append(" tb_user_sfz = @tb_user_sfz , ");         
            strSql.Append(" tb_user_phone = @tb_user_phone , ");         
            strSql.Append(" tb_user_dz = @tb_user_dz , ");         
            strSql.Append(" tb_user_email = @tb_user_email , ");         
            strSql.Append(" tb_user_name = @tb_user_name  ");            	
            if (strWhere.Trim() == "")
                strWhere = "where tb_user_ID='" + this.tb_user_ID + "'";
            else
            {
                if (strWhere.Trim().Substring(0, 5).ToLower() != "where")
                {
                    if (strWhere.Trim().Substring(0, 3).ToLower() != "and")
                        strWhere = " where " + strWhere;
                    else
                        strWhere = " where 1=1 " + strWhere;
                }
            }
            strSql.Append(strWhere);
			SqlParameter[] parameters = {
			            new SqlParameter("@tb_user_wxbs", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_sfz", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_phone", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_dz", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_email", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_user_name", SqlDbType.VarChar,8000)             
              
            };
                        
            parameters[0].Value =this.tb_user_ID;                        
            parameters[1].Value =this.tb_user_wxbs;                        
            parameters[2].Value =this.tb_user_sfz;                        
            parameters[3].Value =this.tb_user_phone;                        
            parameters[4].Value =this.tb_user_dz;                        
            parameters[5].Value =this.tb_user_email;                        
            parameters[6].Value =this.tb_user_name;            

            int rows = _D.dbExe(strSql.ToString(), parameters,pMt:mt);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        public bool Delete(_D.myTransaction mt = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_user ");
            strSql.Append("where tb_user_ID='" + this.tb_user_ID + "'");

            int rows = _D.dbExe(strSql.ToString(),pMt:mt);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere = "",string pColumns="",string pOrder="", _D.myTransaction mt = null)
        {
            StringBuilder strSql = new StringBuilder();
            if(string.IsNullOrEmpty(pColumns))
				strSql.Append("select  tb_user_ID, tb_user_wxbs, tb_user_sfz, tb_user_phone, tb_user_dz, tb_user_email, tb_user_name ");			
			else
				strSql.Append("select " + pColumns);
			strSql.Append("  from tb_user ");
            if (strWhere.Trim() != "")
            {
                if (strWhere.Trim().Substring(0, 5).ToLower() != "where")
                {
                    if (strWhere.Trim().Substring(0, 3).ToLower() != "and")
                        strWhere = " where " + strWhere;
                    else
                        strWhere = " where 1=1 " + strWhere;
                }
                strSql.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(pOrder))
                strSql.Append(" order by " + pOrder);
            return _D.getDb(strSql.ToString(),pMt:mt);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<tb_user> GetModelList(string strWhere="",string pColumns="",string pOrder="",_D.myTransaction mt = null)
		{
			DataTable dt =GetList(strWhere,pColumns,pOrder,mt);
			return DataTableToList(dt);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<tb_user> DataTableToList(DataTable dt)
		{
			List<tb_user> modelList = new List<tb_user>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				tb_user model;
				for (int n = 0; n < rowsCount; n++)
				{
				    model = new tb_user();
				    if(dt.Columns.Contains("tb_user_ID")){if(dt.Rows[n]["tb_user_ID"] != null&&dt.Rows[n]["tb_user_ID"].ToString()!="")model.tb_user_ID=Convert.ToInt32(dt.Rows[n]["tb_user_ID"].ToString());};
					if(dt.Columns.Contains("tb_user_wxbs")){if(dt.Rows[n]["tb_user_wxbs"] != null&&dt.Rows[n]["tb_user_wxbs"].ToString()!="")model.tb_user_wxbs=dt.Rows[n]["tb_user_wxbs"].ToString();};
					if(dt.Columns.Contains("tb_user_sfz")){if(dt.Rows[n]["tb_user_sfz"] != null&&dt.Rows[n]["tb_user_sfz"].ToString()!="")model.tb_user_sfz=dt.Rows[n]["tb_user_sfz"].ToString();};
					if(dt.Columns.Contains("tb_user_phone")){if(dt.Rows[n]["tb_user_phone"] != null&&dt.Rows[n]["tb_user_phone"].ToString()!="")model.tb_user_phone=dt.Rows[n]["tb_user_phone"].ToString();};
					if(dt.Columns.Contains("tb_user_dz")){if(dt.Rows[n]["tb_user_dz"] != null&&dt.Rows[n]["tb_user_dz"].ToString()!="")model.tb_user_dz=dt.Rows[n]["tb_user_dz"].ToString();};
					if(dt.Columns.Contains("tb_user_email")){if(dt.Rows[n]["tb_user_email"] != null&&dt.Rows[n]["tb_user_email"].ToString()!="")model.tb_user_email=dt.Rows[n]["tb_user_email"].ToString();};
					if(dt.Columns.Contains("tb_user_name")){if(dt.Rows[n]["tb_user_name"] != null&&dt.Rows[n]["tb_user_name"].ToString()!="")model.tb_user_name=dt.Rows[n]["tb_user_name"].ToString();};
										
				modelList.Add(model);
				}
			}
			return modelList;
		}
	}
}