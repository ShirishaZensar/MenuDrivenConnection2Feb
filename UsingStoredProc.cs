using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Work2Feb
{
	class SP_Update
	{
		SqlConnection sqlc = null;
		SqlCommand scmd = null;
		SqlDataReader dr = null;
		public int ShowDatas()
		{
			Console.WriteLine("\n");
			sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
			scmd = new SqlCommand("Select * from Employees", sqlc);
			sqlc.Open();
			dr = scmd.ExecuteReader();
			while (dr.Read())
			{
				Console.WriteLine($"{dr["Eid"]}\t{dr["EmpName"]}\t {dr["Salary"]} \t {dr["DeptNo"]}");
			}
			return 0;
		}
		public int InsertProcedure()
		{
			try
			{
				//For user defined values
				Console.WriteLine("Enter EmpName : ");
				var EmpNames = Console.ReadLine();
				Console.WriteLine("Enter Salary : ");
				var Salarys = Convert.ToSingle(Console.ReadLine());
				Console.WriteLine("Enter DeptNo : ");
				var DeptNos = Convert.ToInt32(Console.ReadLine());

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("Sp_InsertEmp", sqlc);
				scmd.CommandType = CommandType.StoredProcedure;
				scmd.Parameters.Add("@EmpName", SqlDbType.VarChar, 20).Value = EmpNames;
				scmd.Parameters.Add("@esal", SqlDbType.Float).Value = Salarys;
				scmd.Parameters.Add("@edept", SqlDbType.Int).Value = DeptNos;
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				ShowDatas();
				return i;
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.Message);
				return 1;
			}
			finally
			{
				sqlc.Close();
			}
		}

		public int DelProcedure()
		{
			try
			{
				Console.WriteLine("Enter EmpName : ");
				var EmpNames = Console.ReadLine();
				Console.WriteLine("Enter Salary : ");
				var Salarys = Convert.ToSingle(Console.ReadLine());
				Console.WriteLine("Enter DeptNo : ");
				var DeptNos = Convert.ToInt32(Console.ReadLine());

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("Sp_DelEmp", sqlc);
				scmd.CommandType = CommandType.StoredProcedure;
				scmd.Parameters.Add("@EmpName", SqlDbType.VarChar, 20).Value = EmpNames;
				scmd.Parameters.Add("@esal", SqlDbType.Float).Value = Salarys;
				scmd.Parameters.Add("@edept", SqlDbType.Int).Value = DeptNos;
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				ShowDatas();
				return i;
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.Message);
				return 1;
			}
			finally
			{
				sqlc.Close();
			}
		}
		public int UpdateProcedure()
		{
			try
			{
				//For user defined values
				Console.WriteLine("Enter EMPID : ");
				var Eids = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Enter EmpName : ");
				var EmpNames = Console.ReadLine();
				Console.WriteLine("Enter Salary : ");
				var Salarys = Convert.ToSingle(Console.ReadLine());
				Console.WriteLine("Enter DeptNo : ");
				var DeptNos = Convert.ToInt32(Console.ReadLine());

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("sp_UpdateEmp", sqlc);
				scmd.CommandType = CommandType.StoredProcedure;
				scmd.Parameters.Add("@EmpName", SqlDbType.VarChar, 20).Value = EmpNames;
				scmd.Parameters.Add("@esal", SqlDbType.Float).Value = Salarys;
				scmd.Parameters.Add("@edept", SqlDbType.Int).Value = DeptNos;
				scmd.Parameters.Add("@empid", SqlDbType.Int).Value = Eids;
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				ShowDatas();
				return i;
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.Message);
				return 1;
			}
			finally
			{
				sqlc.Close();
			}
		}
	}
	class UsingStoredProc
	{
		static void Main()
		{
			SP_Update sps = new SP_Update();
			sps.ShowDatas();
			Console.WriteLine("**************************");
			var ch = 'y';
			while (true)
			{
				Console.Write("Select the options as :\n");
				Console.Write("1-INSERT \n2-DELETE \n3-UPDATE \n4-SEARCH \n5-Exit.\n");
				Console.Write("\nEnter your choice :");
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						Console.WriteLine("********INSERT********");
						if (ch == 'y') { sps.InsertProcedure(); }
						break;
					case 2:
						if (ch == 'y') { sps.DelProcedure(); }
						break;
					case 3:
						if (ch == 'y') { sps.UpdateProcedure(); }
						break;
					case 4:
						Console.WriteLine("Exit Application\n");
						break;

					default:
						Console.WriteLine("Invalid Input\n");
						break;
				}
			}
		}
	}
}